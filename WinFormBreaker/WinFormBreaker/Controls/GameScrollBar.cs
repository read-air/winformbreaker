using System;
using System.Windows.Forms;

namespace WinFormBreaker.Controls {
    /// <summary>
    /// バーの役割を持つスクロールバー
    /// </summary>
    public class GameScrollBar : HScrollBar {
        #region 定数
        private const int BUTTON_SIZE = 16;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GameScrollBar() {
            this.LastValue = -1;
        }
        #endregion

        #region メンバ変数
        /// <summary>
        /// バーの左座標
        /// </summary>
        private int barLeft;
        /// <summary>
        /// バーの右座標
        /// </summary>
        private int barRight;
        #endregion

        #region 外部プロパティ
        /// <summary>
        /// バーの左座標を取得します。
        /// </summary>
        public int BarLeft {
            get {
                this.UpdateLocation();
                return this.barLeft;
            }
        }

        /// <summary>
        /// バーの右座標を取得します。
        /// </summary>
        public int BarRight {
            get {
                this.UpdateLocation();
                return this.barRight;
            }
        }

        /// <summary>
        /// 左右のボタンの幅
        /// </summary>
        public int ButtonWidth {
            get {
                return BUTTON_SIZE;
            }
        }
        #endregion

        #region 内部プロパティ
        /// <summary>
        /// 直前の値
        /// </summary>
        private int LastValue {
            get;
            set;
        }
        #endregion

        #region 外部メソッド
        /// <summary>
        /// 表示変更時の処理を行います。
        /// </summary>
        /// <param name="e">イベントパラメータ</param>
        protected override void OnVisibleChanged(EventArgs e) {
            base.OnVisibleChanged(e);
            // 表示時更新する
            if (this.Visible) {
                this.LastValue = this.Value;
                this.CalculateLocation();
            }
        }
        #endregion

        #region 内部メソッド
        /// <summary>
        /// バーの座標を更新します。
        /// </summary>
        private void UpdateLocation() {
            // 値を更新する
            if (this.LastValue != this.Value) {
                this.LastValue = this.Value;
                // 計算を行う
                this.CalculateLocation();
            }
        }

        /// <summary>
        /// プロパティからバーの座標を計算します。
        /// </summary>
        private void CalculateLocation() {
            double largeChange = this.LargeChange;
            double max = this.Maximum;
            double min = this.Minimum;
            double value = this.Value;
            double width = this.Width;
            // 1目盛りあたりのピクセル長は、幅 / (最大値 - 最小値 + 1スクロールの量(LargeChange))
            double size = max - min;
            double ppc = (width - BUTTON_SIZE * 2) / size;
            // ピクセル長から左端の座標、右端の座標を計算する
            this.barLeft = BUTTON_SIZE + (int)(value * ppc);
            this.barRight = this.barLeft + (int)(largeChange * ppc);
        }
        #endregion
    }
}
