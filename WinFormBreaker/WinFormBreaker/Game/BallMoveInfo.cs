using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormBreaker.Game {
    /// <summary>
    /// ボール移動情報
    /// </summary>
    [DebuggerDisplay("SpeedX:{SpeedX} SpeedY:{SpeedY} Angle:{AngleDeg}")]
    public class BallMoveInfo {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BallMoveInfo() {
            this.BallMoves = new List<BallMove>();
        }

        /// <summary>
        /// リストに座標を追加する
        /// </summary>
        /// <param name="center">中心座標</param>
        /// <param name="hitCheck">当たり判定座標</param>
        public void Add(Point center, Point hitCheck) {
            this.BallMoves.Add(new BallMove() {
                Center = center,
                HitCheck = hitCheck,
            });
        }

        /// <summary>
        /// 移動情報
        /// </summary>
        public List<BallMove> BallMoves {
            get;
            private set;
        }

        /// <summary>
        /// X方向の現在のスピード
        /// </summary>
        public double SpeedX {
            get;
            set;
        }

        /// <summary>
        /// Y方向の現在のスピード
        /// </summary>
        public double SpeedY {
            get;
            set;
        }

        /// <summary>
        /// 方向の角度を取得する
        /// </summary>
        /// <returns>方向の角度(rad)</returns>
        public double GetDirectionAngle() {
            double angle = 0.0;
            if(this.SpeedX != 0.0) {
                angle = Math.Atan2(-this.SpeedY, this.SpeedX);
            }
            return angle;
        }

        /// <summary>
        /// 角度(deg)
        /// </summary>
        public double AngleDeg {
            get {
                return this.GetDirectionAngle() * 180.0 / Math.PI;
            }
        }
    }

    /// <summary>
    /// 移動情報
    /// </summary>
    [DebuggerDisplay("Center:({Center.X},{Center.Y}) HitCheck:({HitCheck.X},{HitCheck.Y})")]
    public class BallMove {
        /// <summary>
        /// 中心座標
        /// </summary>
        public Point Center {
            get;
            set;
        }

        /// <summary>
        /// 当たり判定座標
        /// </summary>
        public Point HitCheck {
            get;
            set;
        }
    }
}
