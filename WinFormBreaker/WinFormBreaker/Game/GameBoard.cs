//#define PREVENT_FALL

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormBreaker.Controls;
using WinFormBreaker.Interface;

namespace WinFormBreaker.Game {
    /// <summary>
    /// ゲームボード
    /// </summary>
    public class GameBoard : IDisposable {
        #region Enum
        /// <summary>
        /// ゲームの状態
        /// </summary>
        private enum Status {
            /// <summary>
            /// 状態なし
            /// </summary>
            None = 0,
            /// <summary>
            /// ゲーム停止中
            /// </summary>
            Stopped,
            /// <summary>
            /// ゲーム実行中
            /// </summary>
            Playing,
            /// <summary>
            /// ゲーム終了
            /// </summary>
            Finished,
        }
        #endregion Enum

        #region 定数
        /// <summary>
        /// 端の幅
        /// </summary>
        private const int SIDE_WIDTH = 20;
        #endregion

        #region メンバ変数
        /// <summary>
        /// ゲームの有効状態
        /// </summary>
        private bool gameEnabled;
        /// <summary>
        /// ゲームの状態
        /// </summary>
        private Status gameStatus;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GameBoard(UserControl control, GameScrollBar scrollBar, Timer timer) {
            this.BaseControl = control ?? throw new ArgumentNullException(nameof(control));
            this.ScrollBar = scrollBar ?? throw new ArgumentNullException(nameof(scrollBar));
            this.GameTimer = timer ?? throw new ArgumentNullException(nameof(timer));
            this.GameTimer.Tick += GameTimer_Tick;
            this.Blocks = new List<IBlock>();
            this.Balls = new List<IBall>();
            this.GameInfo = new GameInfo();
            this.CorrectBlocksFromControl(control);
            this.GameStatus = Status.Stopped;
        }
        #endregion

        #region イベント
        /// <summary>
        /// ゲームが完了した
        /// </summary>
        public event EventHandler GameFinished;
        #endregion イベント

        #region 外部プロパティ
        /// <summary>
        /// ベースとなるコントロール
        /// </summary>
        public UserControl BaseControl {
            get;
            private set;
        }

        /// <summary>
        /// バーとなるスクロールバー
        /// </summary>
        public GameScrollBar ScrollBar {
            get;
            private set;
        }

        /// <summary>
        /// ゲームを動作させるタイマー
        /// </summary>
        public Timer GameTimer {
            get;
            private set;
        }

        /// <summary>
        /// ブロックのリスト
        /// </summary>
        public List<IBlock> Blocks {
            get;
            private set;
        }

        /// <summary>
        /// ボールのリスト
        /// </summary>
        public List<IBall> Balls {
            get;
            private set;
        }

        /// <summary>
        /// ゲーム情報
        /// </summary>
        public GameInfo GameInfo {
            get;
            set;
        }
        #endregion

        #region 外部メソッド
        /// <summary>
        /// 状況を1チック進める
        /// </summary>
        public void Move() {
            var fallBalls = new List<IBall>();
            // 全ボールに対して動作を行う
            foreach (var ball in this.Balls) {
                // ボールが無効なら飛ばす
                if (!ball.IsAvailable) {
                    continue;
                }
                // 直前にヒットしたオブジェクトからの抜け出し判定
                if (ball.LastHitObject != null) {
                    bool slippedOut = this.CheckSlipOut(this.ScrollBar, ball);
                    if (slippedOut) {
                        ball.LastHitObject = null;
                    }
                }
                // ボールの移動先を取得する
                ball.MoveNext();
#if false
                var ballobj = (ball as BallRadioButton);
                var location = ballobj.Location;
                var ballFirst = ball.MoveInfo.BallMoves.First();
                var ballLast = ball.MoveInfo.BallMoves.Last();
                Debug.WriteLine($"({location.X},{location.Y}) FirstHitCheck:({ballFirst.HitCheck.X},{ballFirst.HitCheck.Y}) LastHitCheck({ballLast.HitCheck.X},{ballLast.HitCheck.Y})");
#endif
                bool moved = false;
                // ブロックヒット判定
                if (!moved) {
                    bool hitBlock = this.CheckBlockHit(ball);
                    if (hitBlock) {
                        moved = true;
                    }
                }
                // バーヒット判定
                if (!moved) {
                    bool hitBar = this.CheckBarHit(ball);
                    if (hitBar) {
                        moved = true;
                    }
                }
                // 壁ヒット判定
                if (!moved) {
                    bool hitWall = this.CheckWallHit(ball);
                    if (hitWall) {
                        moved = true;
                    }
                }
                // 落下判定
                if (!moved) {
                    bool fall = this.CheckFall(this.ScrollBar, ball);
                    if (fall) {
#if !PREVENT_FALL
                        fallBalls.Add(ball);
                        moved = true;
#else
                        Debug.WriteLine("落下判定あり");
#endif
                    }
                }
                // 移動判定
                if (!moved) {
                    var last = ball.MoveInfo.BallMoves.LastOrDefault();
                    if (last != null) {
                        ball.MoveTo(last.Center);
                    }
                }
            }
            // 落下したボールを削除する
            foreach (var fallBall in fallBalls) {
                this.RemoveBall(fallBall);
            }
            // ゲームの状態を確認する
            this.CheckGameStatus();
        }

        /// <summary>
        /// ボールのすり抜け判定
        /// </summary>
        /// <returns>すり抜け</returns>
        private bool CheckSlipOut(GameScrollBar bar, IBall ball) {
            var points = ball.MoveInfo.BallPoints;
            var lastHitObject = ball.LastHitObject;
            bool slippedOut = true;
            if (lastHitObject is IBlock block) {
                foreach (var point in points) {
                    // ブロックの当たり判定からすべて外れていることを確認する
                    bool regionHit = block.CheckHit(point);
                    if (regionHit) {
                        slippedOut = false;
                        break;
                    }
                }
            } else {
                int barTop = bar.Top;
                int barLeft = bar.BarLeft, barRight = bar.BarRight;
                if (lastHitObject == bar.LeftButtonObject) {
                    // 左バーの当たり判定からすべて外れていることを確認する
                    foreach (var point in points) {
                        bool hit = point.Y >= barTop && point.X < bar.ButtonWidth;
                        if (hit) {
                            slippedOut = false;
                            break;
                        }
                    }
                } else if (lastHitObject == bar.CenterButtonObject) {
                    // 中央バーの当たり判定からすべて外れていることを確認する
                    foreach (var point in points) {
                        bool hit = point.Y >= barTop && point.X >= barLeft && point.X <= barRight;
                        if (hit) {
                            slippedOut = false;
                            break;
                        }
                    }
                } else if (lastHitObject == bar.RightButtonObject) {
                    // 右バーの当たり判定からすべて外れていることを確認する
                    var area = this.BaseControl.ClientRectangle;
                    foreach (var point in points) {
                        bool hit = point.Y >= barTop && point.X > area.Width - bar.ButtonWidth;
                        if (hit) {
                            slippedOut = false;
                            break;
                        }
                    }
                }
            }
            return slippedOut;
        }

        /// <summary>
        /// ボールの当たり判定を行う
        /// </summary>
        /// <param name="ball">ボール</param>
        private bool CheckBlockHit(IBall ball) {
            bool hit = false;
            // ボールの当たり判定を行う
            var moves = ball.MoveInfo.BallMoves;
            foreach (var point in moves) {
                // 領域が当たっているなら、各ブロックの当たり判定を行う
                foreach (var block in this.Blocks) {
                    bool regionHit = block.CheckHit(point.HitCheck);
                    if (regionHit && ball.LastHitObject != block) {
                        // 当たったブロックが見つかったら、ブロックに攻撃
                        var reflect = block.Attack(ball, point.HitCheck);
                        Debug.WriteLine($"Block Hit:({point.HitCheck.X},{point.HitCheck.Y}) Center:({point.Center.X},{point.Center.Y}), Reflect:{reflect.Direction}");
                        // ボールの移動と反射を行う
                        ball.LastHitObject = block;
                        ball.MoveTo(point.Center);
                        ball.Reflect(reflect);
                        hit = true;
                        break;
                    }
                }
                break;
            }
            return hit;
        }

        /// <summary>
        /// バーの当たり判定を行う
        /// </summary>
        /// <param name="ball">ボール</param>
        /// <returns>当たったかどうか</returns>
        private bool CheckBarHit(IBall ball) {
            var info = CheckBarReflection(this.BaseControl.ClientRectangle, this.ScrollBar, ball);
            ball.Reflect(info);
            return info != null && info.Direction != Direction.None;
        }

        /// <summary>
        /// 壁との当たり判定を行う
        /// </summary>
        /// <param name="ball">ボール</param>
        /// <returns>当たったかどうか</returns>
        private bool CheckWallHit(IBall ball) {
            bool moved = false;
            var area = this.BaseControl.ClientRectangle;
            // ボールの当たり判定を行う
            var moves = ball.MoveInfo.BallMoves;
            foreach (var point in moves) {
                var hit = point.HitCheck;
                Direction direction = Direction.None;
                // 左右に当たったかチェック
                if (hit.X <= 0) {
                    direction = Direction.Right;
                } else if (hit.X >= area.Width) {
                    direction = Direction.Left;
                }
                // 上に当たったかチェック
                if (hit.Y <= 0) {
                    direction = Direction.Bottom;
                }
#if PREVENT_FALL
                else if (hit.Y >= area.Height) {
                    direction = Direction.Top;
                }
#endif
                // どこかに当たったらそこに移動する
                if (direction != Direction.None) {
                    ball.MoveTo(point.Center);
                    ball.Reflect(new ReflectionInfo() {
                        ReflectionType = ReflectionType.Multiply,
                        CoefficientX = 1.0,
                        CoefficientY = 1.0,
                        Direction = direction
                    });
                    Debug.WriteLine($"Wall Hit:({point.HitCheck.X},{point.HitCheck.Y} Center:({point.Center.X},{point.Center.Y}), Reflect:{direction}");
                    moved = true;
                    break;
                }
            }
            return moved;
        }

        /// <summary>
        /// ボールを追加する
        /// </summary>
        /// <param name="point">追加する位置</param>
        public bool AddBall(Point point) {
            // 残りのボール数をチェック
            bool added = false;
            if (this.GameInfo.RestBalls > 0) {
                this.GameInfo.RestBalls--;
                // ボールを追加
                var ball = new BallRadioButton() {
                    Location = point,
                    Visible = true,
                };
                this.Balls.Add(ball);
                this.BaseControl.Controls.Add(ball);
                // ゲームが停止していたらスタートする
                if (this.GameStatus == Status.Stopped) {
                    this.GameStatus = Status.Playing;
                }
                added = true;
            }
            return added;
        }

        /// <summary>
        /// ボールを削除する
        /// </summary>
        /// <param name="ball">削除するボール</param>
        private void RemoveBall(IBall ball) {
            this.Balls.Remove(ball);
            this.BaseControl.Controls.Remove(ball as Control);
            // 盤面上のボールがなくなったらゲームを停止する
            if (!this.Balls.Any() && this.GameEnabled) {
                if (this.GameStatus == Status.Playing) {
                    this.GameStatus = Status.Stopped;
                }
            }
        }

        /// <summary>
        /// 破棄
        /// </summary>
        public void Dispose() {
            // DO NOTHING
        }
        #endregion

        #region 内部プロパティ
        /// <summary>
        /// ゲームの有効状態
        /// </summary>
        private bool GameEnabled {
            get {
                return this.gameEnabled;
            }
            set {
                if (this.gameEnabled != value) {
                    this.gameEnabled = value;
                    foreach (var block in this.Blocks) {
                        block.Enabled = value;
                    }
                    this.GameTimer.Enabled = value;
                }
            }
        }

        /// <summary>
        /// ゲームの状態
        /// </summary>
        private Status GameStatus {
            get {
                return this.gameStatus;
            }
            set {
                if(this.gameStatus != value) {
                    this.gameStatus = value;
                    switch (value) {
                        case Status.None:
                            this.GameEnabled = false;
                            break;
                        case Status.Playing:
                            this.GameTimer.Interval = 20;
                            this.GameEnabled = true;
                            break;
                        case Status.Stopped:
                            this.GameEnabled = false;
                            break;
                        case Status.Finished:
                            this.GameEnabled = false;
                            this.GameTimer.Interval = 3000;
                            this.GameTimer.Start();
                            break;  
                        default:
                            break;
                    }
                }
            }
        }
        #endregion

        #region 内部メソッド
        /// <summary>
        /// パネルにある表示からブロック情報を作成する
        /// </summary>
        /// <param name="control">ブロックが配置されたパネル</param>
        private void CorrectBlocksFromControl(UserControl control) {
            foreach (var item in control.Controls) {
                if (item is IBlock block) {
                    block.Enabled = false;
                    block.Broken += Block_Broken;
                    this.Blocks.Add(block);
                }
            }
        }

        /// <summary>
        /// ブロックが破壊されたときのイベント
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void Block_Broken(object sender, EventArgs e) {
            // ブロックの一覧から取り除く
            if (sender is IBlock block) {
                this.Blocks.Remove(block);
            }
            if (sender is Control control) {
                this.BaseControl.Controls.Remove(control);
            }
        }

        /// <summary>
        /// バーの反射チェック
        /// </summary>
        /// <param name="area">ゲーム領域</param>
        /// <param name="bar">バー</param>
        /// <param name="ball">ボール</param>
        /// <returns>反射情報</returns>
        private ReflectionInfo CheckBarReflection(Rectangle area, GameScrollBar bar, IBall ball) {
            ReflectionInfo info = null;
            int barTop = bar.Top;
            foreach (var point in ball.MoveInfo.BallMoves) {
                bool hit = true;
                int ballY = point.HitCheck.Y;
                // 地面にぶつかったかチェック
                if (ballY >= barTop) {
                    // バーが範囲内かチェック
                    int barLeft = bar.BarLeft, barRight = bar.BarRight;
                    int ballX = point.HitCheck.X;
                    if (ballX >= barLeft && ballX <= barLeft + SIDE_WIDTH && ball.LastHitObject != bar.CenterButtonObject) {
                        Debug.WriteLine("左端");
                        // 左端で反射したら左上に吹っ飛ぶ
                        info = new ReflectionInfo() {
                            ReflectionType = ReflectionType.Constant,
                            CoefficientX = 1.0,
                            CoefficientY = 1.0,
                            Direction = Direction.Top | Direction.Left,
                        };
                        ball.LastHitObject = bar.CenterButtonObject;
                    } else if (ballX >= barRight - SIDE_WIDTH && ballX <= barRight && ball.LastHitObject != bar.CenterButtonObject) {
                        Debug.WriteLine("右端");
                        // 右端で反射したら右上に吹っ飛ぶ
                        info = new ReflectionInfo() {
                            ReflectionType = ReflectionType.Constant,
                            CoefficientX = 1.0,
                            CoefficientY = 1.0,
                            Direction = Direction.Top | Direction.Right,
                        };
                        ball.LastHitObject = bar.CenterButtonObject;
                    } else if (ballX >= barLeft && ballX <= barRight && ball.LastHitObject != bar.CenterButtonObject) {
                        Debug.WriteLine("中央");
                        // バーの中央部にあったらそのまま跳ね返る
                        info = new ReflectionInfo() {
                            ReflectionType = ReflectionType.Multiply,
                            CoefficientX = 1.0,
                            CoefficientY = 1.0,
                            Direction = Direction.Top,
                        };
                        ball.LastHitObject = bar.CenterButtonObject;
                    } else if (ballX < bar.ButtonWidth && ball.LastHitObject != bar.LeftButtonObject) {
                        Debug.WriteLine("左ボタン");
                        // 左端のボタンに当たった場合、右上に吹っ飛ぶ
                        info = new ReflectionInfo() {
                            ReflectionType = ReflectionType.Multiply,
                            CoefficientX = 1.2,
                            CoefficientY = 1.2,
                            Direction = Direction.Top | Direction.Right,
                        };
                        ball.LastHitObject = bar.LeftButtonObject;
                    } else if (ballX > area.Width - bar.ButtonWidth && ball.LastHitObject != bar.RightButtonObject) {
                        Debug.WriteLine("右ボタン");
                        // 右端のボタンに当たった場合、左上に吹っ飛ぶ
                        info = new ReflectionInfo() {
                            ReflectionType = ReflectionType.Multiply,
                            CoefficientX = 1.2,
                            CoefficientY = 1.2,
                            Direction = Direction.Top | Direction.Left,
                        };
                        ball.LastHitObject = bar.RightButtonObject;
                    } else {
                        // DO NOTHING
                        info = new ReflectionInfo();
                        hit = false;
                    }
                } else {
                    hit = false;
                }
                if (hit) {
                    ball.MoveTo(point.Center);
                    break;
                }
            }
            return info;
        }

        /// <summary>
        /// ボール落下チェック
        /// </summary>
        /// <param name="bar">バー</param>
        /// <param name="ball">ボール</param>
        /// <returns>true:落下判定座標より下にいる</returns>
        private bool CheckFall(GameScrollBar bar, IBall ball) {
            bool fall = false;
            var moves = ball.MoveInfo.BallMoves;
            if (moves.Any()) {
                int barLeft = bar.BarLeft, barRight = bar.BarRight;
                int bottomY = moves.Max(p => p.HitCheck.Y);
                int leftX = moves.Min(p => p.HitCheck.X);
                int rightX = moves.Max(p => p.HitCheck.X);
                int fallY = bar.Bottom;
                fall = bottomY >= fallY && ball.SpeedY > 0;
            }
            return fall;
        }

        /// <summary>
        /// ゲームのクリア、ゲームオーバーの状態を確認する
        /// </summary>
        private void CheckGameStatus() {
            // クリアチェック
            if (!this.Blocks.Any()) {
                // すべてのブロックが破壊されていればクリア
                this.GameStatus = Status.Finished;
            }
            // ゲームオーバーチェック
            else if(this.GameInfo.RestBalls <= 0 && !this.Balls.Any()) {
                // すべてのボールが使い切られていて、ボールがすべて落下していたらゲームオーバー
                this.GameStatus = Status.Finished;
            }
        }

        /// <summary>
        /// タイマーイベント
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void GameTimer_Tick(object sender, EventArgs e) {
            switch (this.GameStatus) {
                case Status.Playing:
                    this.Move();
                    break;
                case Status.Finished:
                    this.GameFinished?.Invoke(this, EventArgs.Empty);
                    break;
                case Status.None:
                case Status.Stopped:
                default:
                    break;
            }
        }
        #endregion
    }
}
