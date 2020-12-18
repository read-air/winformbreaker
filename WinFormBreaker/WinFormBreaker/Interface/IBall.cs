using System.Collections.Generic;
using System.Drawing;
using WinFormBreaker.Game;

namespace WinFormBreaker.Interface {
    /// <summary>
    /// ボールを示すインターフェース
    /// </summary>
    public interface IBall {
        #region メソッド
        /// <summary>
        /// 移動先と当たり判定の位置のリストを取得する
        /// </summary>
        /// <returns>リスト</returns>
        void MoveNext();

        /// <summary>
        /// 移動先を設定する
        /// </summary>
        /// <param name="point">移動先の座標</param>
        void MoveTo(Point point);

        /// <summary>
        /// ボールを反射する
        /// </summary>
        /// <param name="reflection">反射情報</param>
        void Reflect(ReflectionInfo reflection);
        #endregion

        #region プロパティ
        /// <summary>
        /// ボールが有効か
        /// </summary>
        bool IsAvailable {
            get;
        }

        /// <summary>
        /// 最後に命中したアイテム
        /// </summary>
        object LastHitObject {
            get;
            set;
        }

        /// <summary>
        /// ボールのパワー
        /// </summary>
        int Power {
            get;
        }

        /// <summary>
        /// ボールのY軸速度
        /// </summary>
        double SpeedY {
            get;
            set;
        }

        /// <summary>
        /// ボールのX軸速度
        /// </summary>
        double SpeedX {
            get;
            set;
        }

#if false
        /// <summary>
        /// ボールの領域
        /// </summary>
        Region Region {
            get;
        }

        /// <summary>
        /// ボールの領域を表す矩形
        /// </summary>
        Rectangle RegionRectangle {
            get;
        }
#endif

        /// <summary>
        /// 現在の進行方向
        /// </summary>
        Direction Direction {
            get;
        }

        /// <summary>
        /// 移動先の候補情報
        /// </summary>
        BallMoveInfo MoveInfo {
            get;
        }
        #endregion
    }
}
