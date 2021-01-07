
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
            this.labelBlock1 = new WinFormBreaker.Controls.LabelBlock();
            this.labelBlock2 = new WinFormBreaker.Controls.LabelBlock();
            this.textBoxBlock1 = new WinFormBreaker.Controls.TextBoxBlock();
            this.textBoxBlock2 = new WinFormBreaker.Controls.TextBoxBlock();
            this.buttonBlock1 = new WinFormBreaker.Controls.ButtonBlock();
            this.SuspendLayout();
            // 
            // labelBlock1
            // 
            this.labelBlock1.AutoSize = true;
            this.labelBlock1.Location = new System.Drawing.Point(101, 228);
            this.labelBlock1.Name = "labelBlock1";
            this.labelBlock1.Size = new System.Drawing.Size(52, 12);
            this.labelBlock1.TabIndex = 4;
            this.labelBlock1.Text = "ログインID";
            // 
            // labelBlock2
            // 
            this.labelBlock2.AutoSize = true;
            this.labelBlock2.Location = new System.Drawing.Point(101, 255);
            this.labelBlock2.Name = "labelBlock2";
            this.labelBlock2.Size = new System.Drawing.Size(52, 12);
            this.labelBlock2.TabIndex = 4;
            this.labelBlock2.Text = "パスワード";
            // 
            // textBoxBlock1
            // 
            this.textBoxBlock1.InputText = "mailadress@example.com";
            this.textBoxBlock1.Location = new System.Drawing.Point(159, 225);
            this.textBoxBlock1.Name = "textBoxBlock1";
            this.textBoxBlock1.Size = new System.Drawing.Size(186, 19);
            this.textBoxBlock1.TabIndex = 5;
            // 
            // textBoxBlock2
            // 
            this.textBoxBlock2.InputText = "************";
            this.textBoxBlock2.Location = new System.Drawing.Point(159, 250);
            this.textBoxBlock2.Name = "textBoxBlock2";
            this.textBoxBlock2.Size = new System.Drawing.Size(186, 19);
            this.textBoxBlock2.TabIndex = 5;
            // 
            // buttonBlock1
            // 
            this.buttonBlock1.Location = new System.Drawing.Point(196, 275);
            this.buttonBlock1.Name = "buttonBlock1";
            this.buttonBlock1.Size = new System.Drawing.Size(75, 23);
            this.buttonBlock1.TabIndex = 6;
            this.buttonBlock1.Text = "ログイン";
            this.buttonBlock1.UseVisualStyleBackColor = true;
            // 
            // Stage1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonBlock1);
            this.Controls.Add(this.textBoxBlock2);
            this.Controls.Add(this.textBoxBlock1);
            this.Controls.Add(this.labelBlock2);
            this.Controls.Add(this.labelBlock1);
            this.Name = "Stage1";
            this.Controls.SetChildIndex(this.labelBlock1, 0);
            this.Controls.SetChildIndex(this.labelBlock2, 0);
            this.Controls.SetChildIndex(this.textBoxBlock1, 0);
            this.Controls.SetChildIndex(this.textBoxBlock2, 0);
            this.Controls.SetChildIndex(this.buttonBlock1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LabelBlock labelBlock1;
        private LabelBlock labelBlock2;
        private TextBoxBlock textBoxBlock1;
        private TextBoxBlock textBoxBlock2;
        private ButtonBlock buttonBlock1;
    }
}
