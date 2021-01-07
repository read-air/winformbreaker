
namespace WinFormBreaker.Controls.Stages {
    partial class Stage6 {
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
            this.labelBlock1 = new WinFormBreaker.Controls.LabelBlock();
            this.lblPercentage = new WinFormBreaker.Controls.LabelBlock();
            this.SuspendLayout();
            // 
            // progressBarBlock1
            // 
            this.progressBarBlock1.Location = new System.Drawing.Point(93, 197);
            this.progressBarBlock1.Maximum = 20;
            this.progressBarBlock1.Name = "progressBarBlock1";
            this.progressBarBlock1.Size = new System.Drawing.Size(258, 23);
            this.progressBarBlock1.TabIndex = 4;
            this.progressBarBlock1.Broken += new System.EventHandler(this.progressBarBlock1_Broken);
            this.progressBarBlock1.ProgressChanged += new System.EventHandler(this.progressBarBlock1_ProgressChanged);
            // 
            // labelBlock1
            // 
            this.labelBlock1.AutoSize = true;
            this.labelBlock1.Location = new System.Drawing.Point(185, 173);
            this.labelBlock1.Name = "labelBlock1";
            this.labelBlock1.Size = new System.Drawing.Size(78, 12);
            this.labelBlock1.TabIndex = 5;
            this.labelBlock1.Text = "ダウンロード中...";
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Location = new System.Drawing.Point(357, 204);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(17, 12);
            this.lblPercentage.TabIndex = 5;
            this.lblPercentage.Text = "0%";
            // 
            // Stage6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.labelBlock1);
            this.Controls.Add(this.progressBarBlock1);
            this.Name = "Stage6";
            this.Controls.SetChildIndex(this.progressBarBlock1, 0);
            this.Controls.SetChildIndex(this.labelBlock1, 0);
            this.Controls.SetChildIndex(this.lblPercentage, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProgressBarBlock progressBarBlock1;
        private LabelBlock labelBlock1;
        private LabelBlock lblPercentage;
    }
}
