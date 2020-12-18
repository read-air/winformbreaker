using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using WinFormBreaker.Interface;
using WinFormBreaker.Game;
using System.Diagnostics;

namespace WinFormBreaker.Controls {
    /// <summary>
    /// ボールの役割を持つラジオボタン
    /// </summary>
    public class BallRadioButton : RadioButton, IBall {

        #region 定数
        /// <summary>
        /// 速度初期値(X)
        /// </summary>
        private const int InitSpeedX = 2;
        /// <summary>
        /// 速度初期値(Y)
        /// </summary>
        private const int InitSpeedY = 5;
        /// <summary>
        /// 速度最大値(X)
        /// </summary>
        private const int MaxSpeedX = 20;
        /// <summary>
        /// 速度最大値(Y)
        /// </summary>
        private const int MaxSpeedY = 50;
        /// <summary>
        /// 加速度
        /// </summary>
        private const double Acceleration = -0.5;
        /// <summary>
        /// 反発係数
        /// </summary>
        private const double Restitution = 1;
        /// <summary>
        /// 移動の分割数
        /// </summary>
        private const int MoveDivide = 20;
        /// <summary>
        /// 係数
        /// </summary>
        private static readonly double Coefficient = Math.Sqrt(2.0) / 2;
        #endregion

        #region メンバ変数
        /// <summary>
        /// X軸速度
        /// </summary>
        private double speedX;
        /// <summary>
        /// Y軸速度
        /// </summary>
        private double speedY;
        #endregion メンバ変数

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BallRadioButton() : base() {
            this.SpeedX = InitSpeedX;
            this.SpeedY = InitSpeedY;
            this.Text = string.Empty;
            this.Visible = true;
            this.BallSize = new Size(this.Height, this.Height);
        }
        #endregion

        #region 外部プロパティ
        /// <summary>
        /// コントロールが有効か
        /// </summary>
        public bool IsAvailable {
            get {
                return !this.ClientArea.IsEmpty;
            }
        }

        /// <summary>
        /// ボールパワー
        /// </summary>
        public int Power {
            get {
                // チェックされていたら威力10倍
                return this.Checked ? 10 : 1;
            }
        }

        /// <summary>
        /// X軸速度
        /// </summary>
        public double SpeedX {
            get {
                return this.speedX;
            }
            set {
                this.speedX = value;
                if (this.speedX > MaxSpeedX) {
                    this.speedX = MaxSpeedX;
                } else if (this.speedX < -MaxSpeedX) {
                    this.speedX = -MaxSpeedX;
                }
            }
        }

        /// <summary>
        /// Y軸速度
        /// </summary>
        public double SpeedY {
            get {
                return this.speedY;
            }
            set {
                this.speedY = value;
                if (this.speedY > MaxSpeedY) {
                    this.speedY = MaxSpeedY;
                } else if (this.speedY < -MaxSpeedY) {
                    this.speedY = -MaxSpeedY;
                }
            }
        }

        /// <summary>
        /// 計算上のボール位置
        /// </summary>
        public Point BallLocation {
            get;
            private set;
        }

        /// <summary>
        /// 座標を設定
        /// </summary>
        public new Point Location {
            get {
                return base.Location;
            }
            set {
                base.Location = value;
                this.BallLocation = value;
            }
        }

        /// <summary>
        /// 領域を表す矩形
        /// </summary>
        public Rectangle RegionRectangle {
            get {
                return new Rectangle(this.BallLocation, this.BallSize);
            }
        }

        /// <summary>
        /// 現在の進行方向
        /// </summary>
        public Direction Direction {
            get {
                Direction direction = Direction.None;
                if (this.SpeedX > 0) {
                    direction |= Direction.Right;
                } else {
                    direction |= Direction.Left;
                }
                if (this.SpeedY > 0) {
                    direction |= Direction.Bottom;
                } else {
                    direction |= Direction.Top;
                }
                return direction;
            }
        }

        /// <summary>
        /// 移動先の情報
        /// </summary>
        public BallMoveInfo MoveInfo {
            get;
            private set;
        }

        /// <summary>
        /// 最後に命中したアイテム
        /// </summary>
        public object LastHitObject {
            get;
            set;
        }

        #endregion

        #region 外部メソッド
        /// <summary>
        /// 移動を行う
        /// </summary>
        public void SetMove() {
            // 領域が形成されるまで動作させない
            if (this.IsAvailable) {
                var location = this.BallLocation;
                // Yの加速を計算
                this.SpeedY -= Acceleration;
                // X,Y軸計算
                double locationX = location.X + this.SpeedX;
                double locationY = location.Y + this.SpeedY;
                int maxWidth = this.ClientArea.Width;
                int maxHeight = this.ClientArea.Height;
                // 位置を調整する
                int setLocationX = this.AdjustLocationX(locationX, maxWidth);
                int setLocationY = this.AdjustLocationY(locationY, maxHeight);
                this.BallLocation = new Point(setLocationX, setLocationY);
                // 座標を設定
                base.Location = new Point(this.BallLocation.X - this.BallSize.Width, this.BallLocation.Y - this.BallSize.Height);
            }
        }

        /// <summary>
        /// 次の座標の候補リストを取得する
        /// </summary>
        /// <returns>候補のリスト</returns>
        public void MoveNext() {
            // 現在位置を取得する
            var location = this.BallLocation;
            // Yの加速を計算
            this.SpeedY -= Acceleration;
            // X,Y軸計算
            double locationX = location.X + this.SpeedX;
            double locationY = location.Y + this.SpeedY;
            int maxWidth = this.ClientArea.Width;
            int maxHeight = this.ClientArea.Height;
            // 位置を調整する
            int setLocationX = this.AdjustLocationX(locationX, maxWidth);
            int setLocationY = this.AdjustLocationY(locationY, maxHeight);
            var info = this.CalculateMoveInfo(location.X, location.Y, setLocationX, setLocationY);
            this.MoveInfo = info;
        }

        /// <summary>
        /// 移動を行う
        /// </summary>
        /// <param name="point">移動先</param>
        public void MoveTo(Point point) {
            // Debug.WriteLine($"MoveTo:({point.X},{point.Y})");
            // 座標を記憶
            this.BallLocation = point;
            // 座標を設定
            base.Location = new Point(this.BallLocation.X - this.BallSize.Width, this.BallLocation.Y - this.BallSize.Height);
        }

        /// <summary>
        /// ボールを反射します。
        /// </summary>
        public void Reflect(ReflectionInfo reflection) {
            if (reflection != null) {
                var type = reflection.ReflectionType;
                var direction = reflection.Direction;
                switch (type) {
                    case ReflectionType.Constant:
                        if ((direction & Direction.Left) == Direction.Left) {
                            this.SpeedX = -MaxSpeedX * reflection.CoefficientX;
                        } else if ((direction & Direction.Right) == Direction.Right) {
                            this.SpeedX = MaxSpeedX * reflection.CoefficientX;
                        }
                        if ((direction & Direction.Top) == Direction.Top) {
                            this.SpeedX = -MaxSpeedY * reflection.CoefficientY;
                        } else if ((direction & Direction.Top) == Direction.Top) {
                            this.SpeedX = MaxSpeedY * reflection.CoefficientY;
                        }
                        break;
                    case ReflectionType.Multiply:
                        if (((direction & Direction.Left) == Direction.Left && this.SpeedX > 0) ||
                            ((direction & Direction.Right) == Direction.Right && this.SpeedX < 0)) {
                            this.SpeedX = -this.SpeedX * reflection.CoefficientX;
                        }
                        if (((direction & Direction.Top) == Direction.Top && this.SpeedY > 0) ||
                            ((direction & Direction.Bottom) == Direction.Bottom && this.SpeedY < 0)) {
                            this.SpeedY = -this.SpeedY * reflection.CoefficientY;
                        }
                        break;
                    case ReflectionType.None:
                    default:
                        // DO NOTHING
                        break;
                }
            }
        }
        #endregion

        #region 内部プロパティ
        /// <summary>
        /// クライアント領域の矩形
        /// </summary>
        private Rectangle ClientArea {
            get {
                return this.Parent?.ClientRectangle ?? Rectangle.Empty;
            }
        }

        /// <summary>
        /// ボールのサイズ
        /// </summary>
        private Size BallSize {
            get;
            set;
        }
        #endregion

        #region 内部メソッド
        /// <summary>
        /// X軸を調整する
        /// </summary>
        /// <param name="locationX">X軸の位置</param>
        /// <param name="maxWidth">最大幅</param>
        /// <returns>調整後のX軸</returns>
        private int AdjustLocationX(double locationX, int maxWidth) {
            if (locationX > maxWidth && this.SpeedX > 0) {
                // 左右端に当たったら反発
                this.SpeedX = -this.SpeedX;
            } else if (locationX < 0 && this.SpeedX < 0) {
                this.SpeedX = -this.SpeedX;
            }
            int setX = (int)locationX;
            if (setX > maxWidth) {
                setX = maxWidth;
            } else if (setX < 0) {
                setX = 0;
            }
            return setX;
        }

        /// <summary>
        /// X軸を調整する
        /// </summary>
        /// <param name="locationY">Y軸の位置</param>
        /// <param name="maxHeight">最大高さ</param>
        /// <returns>調整後のY軸</returns>
        private int AdjustLocationY(double locationY, int maxHeight) {
            if (locationY > maxHeight && this.SpeedY > 0) {
                // バーにぶつかったら係数を加算して反発
            } else if (locationY < 0 && this.SpeedY < 0) {
                // 天井にぶつかったらそのまま反発
                this.SpeedY = -this.SpeedY;
            }
            // 下から先には行かない
            int setY = (int)locationY;
            if (setY > maxHeight) {
                setY = maxHeight;
            } else if (setY < 0) {
                setY = 0;
            }
            return setY;
        }

        /// <summary>
        /// 移動先のリストを計算する
        /// </summary>
        /// <param name="fromX">移動元のX座標</param>
        /// <param name="fromY">移動元のY座標</param>
        /// <param name="toX">移動先のX座標</param>
        /// <param name="toY">移動先のY座標</param>
        /// <returns>リスト</returns>
        private BallMoveInfo CalculateMoveInfo(int fromX, int fromY, int toX, int toY) {
            // 中心座標のリストを計算する
            var centerList = new List<(double X, double Y)>();
            int width = toX - fromX, height = toY - fromY;
            for (int index = 0; index <= MoveDivide; index++) {
                double ratio = (double)index / MoveDivide;
                centerList.Add((fromX + width * ratio, fromY + height * ratio));
            }
            // 角度を計算
            double angle = Math.Atan2(height, width);
            double cos0 = Math.Cos(angle);
            double sin0 = Math.Sin(angle);
            // ±30°の点を追加する
            double angleP = angle + Math.PI / 6;
            double cosP = Math.Cos(angleP);
            double sinP = Math.Sin(angleP);
            double angleN = angle - Math.PI / 6;
            double cosN = Math.Cos(angleN);
            double sinN = Math.Sin(angleN);
            // リストを作成
            double ballHalfWidth = this.BallSize.Width / 2.0;
            double ballHalfHeight = this.BallSize.Height / 2.0;
            var info = new BallMoveInfo() {
                SpeedX = this.SpeedX,
                SpeedY = this.SpeedY,
            };
            foreach (var (x, y) in centerList) {
                var ballCenter = new Point((int)x, (int)y);
                var hitPoint = new Point((int)(x + ballHalfWidth * cos0), (int)(y - ballHalfHeight * sin0));
                info.Add(ballCenter, hitPoint);
                var hitPointP = new Point((int)(x + ballHalfWidth * cosP), (int)(y - ballHalfHeight * sinP));
                info.Add(ballCenter, hitPointP);
                var hitPointN = new Point((int)(x + ballHalfWidth * cosN), (int)(y - ballHalfHeight * sinN));
                info.Add(ballCenter, hitPointN);
            }
            return info;
        }
        #endregion
    }
}
