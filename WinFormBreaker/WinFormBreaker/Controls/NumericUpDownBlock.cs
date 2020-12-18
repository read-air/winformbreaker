using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormBreaker.Interface;
using WinFormBreaker.Game;

namespace WinFormBreaker.Controls {
    /// <summary>
    /// 数値入力ブロック
    /// </summary>
    public class NumericUpDownBlock : NumericUpDown, IBlock {
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
            // 数値入力は値が0になったら破壊される。
            // 破壊されたらボールは反射する
            var rectangle = new Rectangle(this.Location, this.ClientSize);
            var info = ReflectionHelper.CalculateReflection(rectangle, point);
            // ボールパワー分数値を減算する
            this.Value -= power;
            return info;
        }

        /// <summary>
        /// 数値変更時の動作
        /// </summary>
        /// <param name="e">イベントパラメータ</param>
        protected override void OnValueChanged(EventArgs e) {
            // 値が変化したとき0以下なら破壊
            if(this.Value <= 0M) {
                this.Broken?.Invoke(this, EventArgs.Empty);
            }
            base.OnValueChanged(e);
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
