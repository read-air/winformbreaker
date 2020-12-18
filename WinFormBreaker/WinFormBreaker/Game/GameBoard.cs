using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormBreaker.Controls;
using WinFormBreaker.Interface;

namespace WinFormBreaker.Game {
    /// <summary>
    /// ゲームボード
    /// </summary>
    public class GameBoard : IDisposable {
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
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GameBoard(Panel panel, GameScrollBar scrollBar, Timer timer) {
            this.BasePanel = panel ?? throw new ArgumentNullException(nameof(panel));
            this.ScrollBar = scrollBar ?? throw new ArgumentNullException(nameof(scrollBar));
            this.GameTimer = timer ?? throw new ArgumentNullException(nameof(timer));
            this.BlockRegion = new Region();
            this.Blocks = new List<IBlock>();
            this.Balls = new List<IBall>();
            this.GameInfo = new GameInfo();
            this.CorrectBlocksFromPanel(panel);
        }
        #endregion

        #region 外部プロパティ
        /// <summary>
        /// ベースとなるパネル
        /// </summary>
        public Panel BasePanel {
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
        /// ブロック全体の領域
        /// </summary>
        public Region BlockRegion {
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
                // ボールの移動先を取得する
                ball.MoveNext();
                bool moved = false;
                if (!moved) {
                    bool hitBlock = this.CheckBlockHit(ball);
                    if (hitBlock) {
                        moved = true;
                    }
                }
                if (!moved) {
                    bool hitBall = this.CheckBarHit(ball);
                    if (hitBall) {
                        moved = true;
                    }
                }
                if (!moved) {
                    bool fall = this.CheckFall(this.ScrollBar, ball);
                    if (fall) {
                        fallBalls.Add(ball);
                        moved = true;
                    }
                }
                if (!moved) {
                    var last = ball.MoveInfo.BallMoves.LastOrDefault();
                    if (last != null) {
                        ball.MoveTo(last.Center);
                    }
                }
            }
            // 落下したボールを削除する
            foreach(var fallBall in fallBalls) {
                this.RemoveBall(fallBall);
            }
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
                // 領域チェックを行う
                bool blockHit = this.BlockRegion.IsVisible(point.HitCheck);
                if (!blockHit) {
                    continue;
                }
                // 領域が当たっているなら、各ブロックの当たり判定を行う
                foreach (var block in this.Blocks) {
                    bool regionHit = block.Region.IsVisible(point.HitCheck);
                    if (regionHit) {
                        // 当たったブロックが見つかったら、ブロックに攻撃
                        var reflect = block.Attack(point.HitCheck, ball.Power);
                        Debug.WriteLine($"Hit:({point.HitCheck.X},{point.HitCheck.Y} Center:({point.Center.X},{point.Center.Y}), Reflect:{reflect.Direction}");
                        // ボールの移動と反射を行う
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
            var info = CheckBarReflection(this.BasePanel.ClientRectangle, this.ScrollBar, ball);
            ball.Reflect(info);
            return info != null && info.Direction != Direction.None;
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
                this.BasePanel.Controls.Add(ball);
                // ゲームが停止していたらスタートする
                if (!this.GameEnabled) {
                    this.GameEnabled = true;
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
            this.BasePanel.Controls.Remove(ball as Control);
            // 盤面上のボールがなくなったらゲームを停止する
            if (!this.Balls.Any() && this.GameEnabled) {
                this.GameEnabled = false;
            }
        }

        /// <summary>
        /// 破棄
        /// </summary>
        public void Dispose() {
            if (this.BlockRegion != null) {
                this.BlockRegion.Dispose();
                this.BlockRegion = null;
            }
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
        #endregion

        #region 内部メソッド
        /// <summary>
        /// パネルにある表示からブロック情報を作成する
        /// </summary>
        /// <param name="panel">ブロックが配置されたパネル</param>
        private void CorrectBlocksFromPanel(Panel panel) {
            foreach (var control in panel.Controls) {
                if (control is IBlock block) {
                    if (block.Region != null) {
                        block.Enabled = false;
                        block.Broken += Block_Broken;
                        this.Blocks.Add(block);
                        this.BlockRegion.Union(block.Region);
                    }
                }
            }
        }

        /// <summary>
        /// ブロックが破壊されたときのいべんと　
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void Block_Broken(object sender, EventArgs e) {
            // ブロックの一覧から取り除く
            if (sender is IBlock block) {
                this.Blocks.Remove(block);
            }
            if (sender is Control control) {
                this.BasePanel.Controls.Remove(control);
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
            var rect = ball.RegionRectangle;
            int ballBottom = rect.Bottom;
            int barTop = bar.Top;
            // 地面にぶつかったかチェック
            if (ballBottom >= barTop) {
                // バーが範囲内かチェック
                int barLeft = bar.BarLeft, barRight = bar.BarRight;
                int ballCenter = (rect.Left + rect.Right) / 2;
                if (ballCenter >= barLeft && ballCenter <= barLeft + SIDE_WIDTH) {
                    Debug.WriteLine("左端");
                    // 左端で反射したら左上に吹っ飛ぶ
                    info = new ReflectionInfo() {
                        ReflectionType = ReflectionType.Constant,
                        CoefficientX = 1.0,
                        CoefficientY = 1.0,
                        Direction = Direction.Top | Direction.Left,
                    };
                } else if (ballCenter >= barRight - SIDE_WIDTH && ballCenter <= barRight) {
                    Debug.WriteLine("右端");
                    // 右端で反射したら右上に吹っ飛ぶ
                    info = new ReflectionInfo() {
                        ReflectionType = ReflectionType.Constant,
                        CoefficientX = 1.0,
                        CoefficientY = 1.0,
                        Direction = Direction.Top | Direction.Right,
                    };
                } else if (ballCenter >= barLeft && ballCenter <= barRight) {
                    Debug.WriteLine("中央");
                    // バーの中央部にあったらそのまま跳ね返る
                    info = new ReflectionInfo() {
                        ReflectionType = ReflectionType.Multiply,
                        CoefficientX = 1.0,
                        CoefficientY = 1.0,
                        Direction = Direction.Top,
                    };
                } else if (ballCenter < bar.ButtonWidth) {
                    Debug.WriteLine("左ボタン");
                    // 左端のボタンに当たった場合、右上に吹っ飛ぶ
                    info = new ReflectionInfo() {
                        ReflectionType = ReflectionType.Multiply,
                        CoefficientX = 1.2,
                        CoefficientY = 1.2,
                        Direction = Direction.Top | Direction.Right,
                    };
                } else if (ballCenter > area.Width - bar.ButtonWidth) {
                    Debug.WriteLine("右ボタン");
                    // 右端のボタンに当たった場合、左上に吹っ飛ぶ
                    info = new ReflectionInfo() {
                        ReflectionType = ReflectionType.Multiply,
                        CoefficientX = 1.2,
                        CoefficientY = 1.2,
                        Direction = Direction.Top | Direction.Left,
                    };
                } else {
                    // DO NOTHING
                    info = new ReflectionInfo();
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
            var rect = ball.RegionRectangle;
            int ballBottom = rect.Bottom;
            int barTop = bar.Top;
            return ballBottom >= barTop;
        }
        #endregion
    }
}
