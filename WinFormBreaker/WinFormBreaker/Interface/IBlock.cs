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
        /// このブロックを壊す。
        /// </summary>
        /// <param name="point">座標</param>
        /// <param name="power">ボールパワー</param>
        /// <returns>ブロックの反射情報</returns>
        ReflectionInfo Attack(Point point, int power);
        #endregion
    }
}
