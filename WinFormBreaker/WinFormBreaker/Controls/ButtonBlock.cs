using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormBreaker.Game;
using WinFormBreaker.Interface;

namespace WinFormBreaker.Controls {
    public class ButtonBlock : Button, IBlock {
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
                if (this.region == null) {
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
            // ボタンは1回で破壊される
            // 破壊されたらボールは反射する
            var rectangle = new Rectangle(this.Location, this.ClientSize);
            var info = ReflectionHelper.CalculateReflection(rectangle, point);
            // 破壊イベントを送信
            this.Broken?.Invoke(this, EventArgs.Empty);
            return info;
        }

        /// <summary>
        /// クリック時のイベントを動作させる。
        /// </summary>
        /// <param name="e">イベントパラメータ</param>
        protected override void OnClick(EventArgs e) {
            // クリックしたときもどうように破壊される
            this.Broken?.Invoke(this, EventArgs.Empty);
            base.OnClick(e);
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
