using System;
using System.Drawing;
using WinFormBreaker.Game;

namespace WinFormBreaker.Interface {
    /// <summary>
    /// ブロックを示すインターフェース
    /// </summary>
    public interface IBlock {
        #region イベント
        /// <summary>
        /// ブロックが破壊されたことを通知するイベント
        /// </summary>
        event EventHandler Broken;
        #endregion

        #region プロパティ
        /// <summary>
        /// ブロックのリージョン
        /// </summary>
        Region Region {
            get;
        }

        bool Enabled {
            get;
            set;
        }
        #endregion

        #region メソッド
        /// <summary>
        /// 命中したかチェックを行います。
        /// </summary>
        /// <param name="point">チェックする座標</param>
        /// <returns>命中したかどうか</returns>
        bool CheckHit(Point point);

        /// <summary>
        /// このブロックを壊す。
        /// </summary>
        /// <param name="point">座標</param>
        /// <returns>ブロックの反射情報</returns>
        ReflectionInfo Attack(IBall ball, Point point);
        #endregion
    }
}
