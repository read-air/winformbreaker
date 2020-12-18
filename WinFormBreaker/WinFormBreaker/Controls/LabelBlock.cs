using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormBreaker.Interface;
using WinFormBreaker.Game;

namespace WinFormBreaker.Controls {
    public class LabelBlock : Label, IBlock {
        #region 
        /// <summary>
        /// 領域
        /// </summary>
        private Region region;
        #endregion

        #region イベント
        /// <summary>
        /// ブロックが破壊されたことを通知するイベント
        /// </summary>
        public event EventHandler Broken;
        #endregion

        #region 外部プロパティ
        /// <summary>
        /// ブロックのリージョン
        /// </summary>
        Region IBlock.Region {
            get {
                if(this.region == null) {
                    var rectangle = new Rectangle(this.Location, this.ClientSize);
                    this.region = new Region(rectangle);
                }
                return this.region;
            }
        }
        #endregion

        #region 外部メソッド
        /// <summary>
        /// このブロックを壊す。
        /// </summary>
        /// <param name="point">ヒットした座標</param>
        /// <param name="power">ボールパワー</param>
        /// <returns>ブロックの反射情報</returns>
        public ReflectionInfo Attack(Point point, int power) {
            // ラベルはパワーにかかわらず破壊される。
            // 破壊されても貫通する。
            var info = new ReflectionInfo();
            // 破壊イベントを送信
            this.Broken?.Invoke(this, EventArgs.Empty);
            return info;
        }

        /// <summary>
        /// リソース破棄時の動作を行う。
        /// </summary>
        /// <param name="disposing">リソースを破棄するか</param>
        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
            if (disposing) {
                // リソース破棄
                if (this.region != null) {
                    this.region.Dispose();
                    this.region = null;
                }
            }
        }
        #endregion
    }
}
