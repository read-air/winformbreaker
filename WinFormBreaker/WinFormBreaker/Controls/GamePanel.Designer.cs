
namespace WinFormBreaker.Controls {
    partial class GamePanel {
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
            this.components = new System.ComponentModel.Container();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.pnlGameArea = new System.Windows.Forms.Panel();
            this.progressBarBlock1 = new WinFormBreaker.Controls.ProgressBarBlock();
            this.checkBoxBlock1 = new WinFormBreaker.Controls.CheckBoxBlock();
            this.numericUpDownBlock2 = new WinFormBreaker.Controls.NumericUpDownBlock();
            this.numericUpDownBlock1 = new WinFormBreaker.Controls.NumericUpDownBlock();
            this.textBoxBlock2 = new WinFormBreaker.Controls.TextBoxBlock();
            this.textBoxBlock1 = new WinFormBreaker.Controls.TextBoxBlock();
            this.buttonBlock3 = new WinFormBreaker.Controls.ButtonBlock();
            this.buttonBlock2 = new WinFormBreaker.Controls.ButtonBlock();
            this.buttonBlock1 = new WinFormBreaker.Controls.ButtonBlock();
            this.labelBlock4 = new WinFormBreaker.Controls.LabelBlock();
            this.labelBlock3 = new WinFormBreaker.Controls.LabelBlock();
            this.labelBlock2 = new WinFormBreaker.Controls.LabelBlock();
            this.labelBlock1 = new WinFormBreaker.Controls.LabelBlock();
            this.scbBar = new WinFormBreaker.Controls.GameScrollBar();
            this.pnlGameArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlock2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlock1)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 20;
            this.tmrUpdate.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // pnlGameArea
            // 
            this.pnlGameArea.Controls.Add(this.progressBarBlock1);
            this.pnlGameArea.Controls.Add(this.checkBoxBlock1);
            this.pnlGameArea.Controls.Add(this.numericUpDownBlock2);
            this.pnlGameArea.Controls.Add(this.numericUpDownBlock1);
            this.pnlGameArea.Controls.Add(this.textBoxBlock2);
            this.pnlGameArea.Controls.Add(this.textBoxBlock1);
            this.pnlGameArea.Controls.Add(this.buttonBlock3);
            this.pnlGameArea.Controls.Add(this.buttonBlock2);
            this.pnlGameArea.Controls.Add(this.buttonBlock1);
            this.pnlGameArea.Controls.Add(this.labelBlock4);
            this.pnlGameArea.Controls.Add(this.labelBlock3);
            this.pnlGameArea.Controls.Add(this.labelBlock2);
            this.pnlGameArea.Controls.Add(this.labelBlock1);
            this.pnlGameArea.Controls.Add(this.scbBar);
            this.pnlGameArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGameArea.Location = new System.Drawing.Point(0, 0);
            this.pnlGameArea.Name = "pnlGameArea";
            this.pnlGameArea.Size = new System.Drawing.Size(480, 640);
            this.pnlGameArea.TabIndex = 1;
            this.pnlGameArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameArea_MouseClick);
            // 
            // progressBarBlock1
            // 
            this.progressBarBlock1.Location = new System.Drawing.Point(72, 315);
            this.progressBarBlock1.Maximum = 10;
            this.progressBarBlock1.Name = "progressBarBlock1";
            this.progressBarBlock1.Size = new System.Drawing.Size(299, 21);
            this.progressBarBlock1.TabIndex = 10;
            // 
            // checkBoxBlock1
            // 
            this.checkBoxBlock1.AutoSize = true;
            this.checkBoxBlock1.Checked = true;
            this.checkBoxBlock1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBlock1.Location = new System.Drawing.Point(72, 267);
            this.checkBoxBlock1.Name = "checkBoxBlock1";
            this.checkBoxBlock1.Size = new System.Drawing.Size(76, 16);
            this.checkBoxBlock1.TabIndex = 9;
            this.checkBoxBlock1.Text = "CheckBox";
            this.checkBoxBlock1.UseVisualStyleBackColor = true;
            // 
            // numericUpDownBlock2
            // 
            this.numericUpDownBlock2.Location = new System.Drawing.Point(198, 218);
            this.numericUpDownBlock2.Name = "numericUpDownBlock2";
            this.numericUpDownBlock2.Size = new System.Drawing.Size(120, 19);
            this.numericUpDownBlock2.TabIndex = 8;
            this.numericUpDownBlock2.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numericUpDownBlock1
            // 
            this.numericUpDownBlock1.Location = new System.Drawing.Point(72, 218);
            this.numericUpDownBlock1.Name = "numericUpDownBlock1";
            this.numericUpDownBlock1.Size = new System.Drawing.Size(120, 19);
            this.numericUpDownBlock1.TabIndex = 8;
            this.numericUpDownBlock1.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // textBoxBlock2
            // 
            this.textBoxBlock2.InputText = "Block";
            this.textBoxBlock2.Location = new System.Drawing.Point(178, 164);
            this.textBoxBlock2.Name = "textBoxBlock2";
            this.textBoxBlock2.Size = new System.Drawing.Size(100, 19);
            this.textBoxBlock2.TabIndex = 7;
            // 
            // textBoxBlock1
            // 
            this.textBoxBlock1.InputText = "Break";
            this.textBoxBlock1.Location = new System.Drawing.Point(72, 164);
            this.textBoxBlock1.Name = "textBoxBlock1";
            this.textBoxBlock1.Size = new System.Drawing.Size(100, 19);
            this.textBoxBlock1.TabIndex = 6;
            // 
            // buttonBlock3
            // 
            this.buttonBlock3.Location = new System.Drawing.Point(229, 418);
            this.buttonBlock3.Name = "buttonBlock3";
            this.buttonBlock3.Size = new System.Drawing.Size(75, 23);
            this.buttonBlock3.TabIndex = 5;
            this.buttonBlock3.Text = "buttonBlock1";
            this.buttonBlock3.UseVisualStyleBackColor = true;
            // 
            // buttonBlock2
            // 
            this.buttonBlock2.Location = new System.Drawing.Point(148, 418);
            this.buttonBlock2.Name = "buttonBlock2";
            this.buttonBlock2.Size = new System.Drawing.Size(75, 23);
            this.buttonBlock2.TabIndex = 5;
            this.buttonBlock2.Text = "buttonBlock1";
            this.buttonBlock2.UseVisualStyleBackColor = true;
            // 
            // buttonBlock1
            // 
            this.buttonBlock1.Location = new System.Drawing.Point(67, 418);
            this.buttonBlock1.Name = "buttonBlock1";
            this.buttonBlock1.Size = new System.Drawing.Size(75, 23);
            this.buttonBlock1.TabIndex = 5;
            this.buttonBlock1.Text = "buttonBlock1";
            this.buttonBlock1.UseVisualStyleBackColor = true;
            // 
            // labelBlock4
            // 
            this.labelBlock4.AutoSize = true;
            this.labelBlock4.Location = new System.Drawing.Point(275, 370);
            this.labelBlock4.Name = "labelBlock4";
            this.labelBlock4.Size = new System.Drawing.Size(64, 12);
            this.labelBlock4.TabIndex = 4;
            this.labelBlock4.Text = "labelBlock4";
            // 
            // labelBlock3
            // 
            this.labelBlock3.AutoSize = true;
            this.labelBlock3.Location = new System.Drawing.Point(205, 370);
            this.labelBlock3.Name = "labelBlock3";
            this.labelBlock3.Size = new System.Drawing.Size(64, 12);
            this.labelBlock3.TabIndex = 3;
            this.labelBlock3.Text = "labelBlock3";
            // 
            // labelBlock2
            // 
            this.labelBlock2.AutoSize = true;
            this.labelBlock2.Location = new System.Drawing.Point(135, 370);
            this.labelBlock2.Name = "labelBlock2";
            this.labelBlock2.Size = new System.Drawing.Size(64, 12);
            this.labelBlock2.TabIndex = 2;
            this.labelBlock2.Text = "labelBlock2";
            // 
            // labelBlock1
            // 
            this.labelBlock1.AutoSize = true;
            this.labelBlock1.Location = new System.Drawing.Point(65, 370);
            this.labelBlock1.Name = "labelBlock1";
            this.labelBlock1.Size = new System.Drawing.Size(64, 12);
            this.labelBlock1.TabIndex = 1;
            this.labelBlock1.Text = "labelBlock1";
            // 
            // scbBar
            // 
            this.scbBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.scbBar.LargeChange = 25;
            this.scbBar.Location = new System.Drawing.Point(0, 623);
            this.scbBar.Name = "scbBar";
            this.scbBar.Size = new System.Drawing.Size(480, 17);
            this.scbBar.TabIndex = 0;
            // 
            // GamePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlGameArea);
            this.Name = "GamePanel";
            this.Size = new System.Drawing.Size(480, 640);
            this.Load += new System.EventHandler(this.GamePanel_Load);
            this.pnlGameArea.ResumeLayout(false);
            this.pnlGameArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlock2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlock1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrUpdate;
        private GameScrollBar scbBar;
        private System.Windows.Forms.Panel pnlGameArea;
        private ProgressBarBlock progressBarBlock1;
        private CheckBoxBlock checkBoxBlock1;
        private NumericUpDownBlock numericUpDownBlock2;
        private NumericUpDownBlock numericUpDownBlock1;
        private TextBoxBlock textBoxBlock2;
        private TextBoxBlock textBoxBlock1;
        private ButtonBlock buttonBlock3;
        private ButtonBlock buttonBlock2;
        private ButtonBlock buttonBlock1;
        private LabelBlock labelBlock4;
        private LabelBlock labelBlock3;
        private LabelBlock labelBlock2;
        private LabelBlock labelBlock1;
    }
}
