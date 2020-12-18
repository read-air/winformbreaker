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
