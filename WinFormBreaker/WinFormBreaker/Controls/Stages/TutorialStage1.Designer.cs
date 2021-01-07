
namespace WinFormBreaker.Controls.Stages {
    partial class TutorialStage1 {
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
            this.labelBlock3 = new WinFormBreaker.Controls.LabelBlock();
            this.labelBlock4 = new WinFormBreaker.Controls.LabelBlock();
            this.labelBlock5 = new WinFormBreaker.Controls.LabelBlock();
            this.labelBlock6 = new WinFormBreaker.Controls.LabelBlock();
            this.SuspendLayout();
            // 
            // labelBlock1
            // 
            this.labelBlock1.AutoSize = true;
            this.labelBlock1.Location = new System.Drawing.Point(37, 177);
            this.labelBlock1.Name = "labelBlock1";
            this.labelBlock1.Size = new System.Drawing.Size(411, 12);
            this.labelBlock1.TabIndex = 4;
            this.labelBlock1.Text = "画面上の好きなところをクリックすると、その場所にボールが現われてゲームが始まります。";
            // 
            // labelBlock2
            // 
            this.labelBlock2.AutoSize = true;
            this.labelBlock2.Location = new System.Drawing.Point(37, 233);
            this.labelBlock2.Name = "labelBlock2";
            this.labelBlock2.Size = new System.Drawing.Size(258, 12);
            this.labelBlock2.TabIndex = 4;
            this.labelBlock2.Text = "下にあるスクロールバーがボールに当たると反射します。";
            // 
            // labelBlock3
            // 
            this.labelBlock3.AutoSize = true;
            this.labelBlock3.Location = new System.Drawing.Point(37, 261);
            this.labelBlock3.Name = "labelBlock3";
            this.labelBlock3.Size = new System.Drawing.Size(267, 12);
            this.labelBlock3.TabIndex = 4;
            this.labelBlock3.Text = "ボールがバーに当たらず下に落ちてしまうとミスになります。";
            // 
            // labelBlock4
            // 
            this.labelBlock4.AutoSize = true;
            this.labelBlock4.Location = new System.Drawing.Point(37, 288);
            this.labelBlock4.Name = "labelBlock4";
            this.labelBlock4.Size = new System.Drawing.Size(247, 12);
            this.labelBlock4.TabIndex = 4;
            this.labelBlock4.Text = "すべてのボールをミスしてしまうとゲームオーバーです。";
            // 
            // labelBlock5
            // 
            this.labelBlock5.AutoSize = true;
            this.labelBlock5.Location = new System.Drawing.Point(37, 207);
            this.labelBlock5.Name = "labelBlock5";
            this.labelBlock5.Size = new System.Drawing.Size(402, 12);
            this.labelBlock5.TabIndex = 4;
            this.labelBlock5.Text = "画面上のこの文字がブロックです。ラベルブロックは当たると消え、ボールは貫通します。";
            // 
            // labelBlock6
            // 
            this.labelBlock6.AutoSize = true;
            this.labelBlock6.Location = new System.Drawing.Point(37, 320);
            this.labelBlock6.Name = "labelBlock6";
            this.labelBlock6.Size = new System.Drawing.Size(290, 12);
            this.labelBlock6.TabIndex = 4;
            this.labelBlock6.Text = "すべてのブロックを消すことができればステージクリアになります。";
            // 
            // TutorialStage1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelBlock6);
            this.Controls.Add(this.labelBlock4);
            this.Controls.Add(this.labelBlock3);
            this.Controls.Add(this.labelBlock5);
            this.Controls.Add(this.labelBlock2);
            this.Controls.Add(this.labelBlock1);
            this.Name = "TutorialStage1";
            this.Controls.SetChildIndex(this.labelBlock1, 0);
            this.Controls.SetChildIndex(this.labelBlock2, 0);
            this.Controls.SetChildIndex(this.labelBlock5, 0);
            this.Controls.SetChildIndex(this.labelBlock3, 0);
            this.Controls.SetChildIndex(this.labelBlock4, 0);
            this.Controls.SetChildIndex(this.labelBlock6, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LabelBlock labelBlock1;
        private LabelBlock labelBlock2;
        private LabelBlock labelBlock3;
        private LabelBlock labelBlock4;
        private LabelBlock labelBlock5;
        private LabelBlock labelBlock6;
    }
}
