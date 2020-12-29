
namespace WinFormBreaker.Controls.Stages {
    partial class Stage1 {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.progressBarBlock1 = new WinFormBreaker.Controls.ProgressBarBlock();
            this.SuspendLayout();
            // 
            // progressBarBlock1
            // 
            this.progressBarBlock1.Location = new System.Drawing.Point(83, 301);
            this.progressBarBlock1.Name = "progressBarBlock1";
            this.progressBarBlock1.Size = new System.Drawing.Size(310, 23);
            this.progressBarBlock1.TabIndex = 2;
            // 
            // Stage1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBarBlock1);
            this.Name = "Stage1";
            this.Controls.SetChildIndex(this.progressBarBlock1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ProgressBarBlock progressBarBlock1;
    }
}
