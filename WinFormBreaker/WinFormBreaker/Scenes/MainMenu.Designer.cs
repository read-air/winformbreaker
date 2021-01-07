
namespace WinFormBreaker.Scenes {
    partial class MainMenu {
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
            this.btnTutorial1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTutorial2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnDebug = new System.Windows.Forms.Button();
            this.btnStage1 = new System.Windows.Forms.Button();
            this.btnStage2 = new System.Windows.Forms.Button();
            this.btnStage6 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTutorial1
            // 
            this.btnTutorial1.Location = new System.Drawing.Point(26, 59);
            this.btnTutorial1.Name = "btnTutorial1";
            this.btnTutorial1.Size = new System.Drawing.Size(75, 23);
            this.btnTutorial1.TabIndex = 0;
            this.btnTutorial1.Tag = "101";
            this.btnTutorial1.Text = "操作説明";
            this.btnTutorial1.UseVisualStyleBackColor = true;
            this.btnTutorial1.Click += new System.EventHandler(this.Stage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ステージ";
            // 
            // btnTutorial2
            // 
            this.btnTutorial2.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.btnTutorial2.Location = new System.Drawing.Point(107, 59);
            this.btnTutorial2.Name = "btnTutorial2";
            this.btnTutorial2.Size = new System.Drawing.Size(75, 23);
            this.btnTutorial2.TabIndex = 0;
            this.btnTutorial2.Tag = "102";
            this.btnTutorial2.Text = "ブロックの種類";
            this.btnTutorial2.UseVisualStyleBackColor = true;
            this.btnTutorial2.Click += new System.EventHandler(this.Stage_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(188, 139);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Tag = "3";
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Stage_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(269, 139);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            this.button4.Tag = "4";
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Stage_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(350, 139);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 0;
            this.button5.Tag = "5";
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Stage_Click);
            // 
            // btnDebug
            // 
            this.btnDebug.Location = new System.Drawing.Point(350, 542);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(75, 23);
            this.btnDebug.TabIndex = 0;
            this.btnDebug.Tag = "-1";
            this.btnDebug.Text = "デバッグ";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Visible = false;
            this.btnDebug.Click += new System.EventHandler(this.Stage_Click);
            // 
            // btnStage1
            // 
            this.btnStage1.Location = new System.Drawing.Point(26, 139);
            this.btnStage1.Name = "btnStage1";
            this.btnStage1.Size = new System.Drawing.Size(75, 23);
            this.btnStage1.TabIndex = 0;
            this.btnStage1.Tag = "1";
            this.btnStage1.Text = "1";
            this.btnStage1.UseVisualStyleBackColor = true;
            this.btnStage1.Click += new System.EventHandler(this.Stage_Click);
            // 
            // btnStage2
            // 
            this.btnStage2.Location = new System.Drawing.Point(107, 139);
            this.btnStage2.Name = "btnStage2";
            this.btnStage2.Size = new System.Drawing.Size(75, 23);
            this.btnStage2.TabIndex = 0;
            this.btnStage2.Tag = "2";
            this.btnStage2.Text = "2";
            this.btnStage2.UseVisualStyleBackColor = true;
            this.btnStage2.Click += new System.EventHandler(this.Stage_Click);
            // 
            // btnStage6
            // 
            this.btnStage6.Location = new System.Drawing.Point(26, 194);
            this.btnStage6.Name = "btnStage6";
            this.btnStage6.Size = new System.Drawing.Size(75, 23);
            this.btnStage6.TabIndex = 0;
            this.btnStage6.Tag = "6";
            this.btnStage6.Text = "6";
            this.btnStage6.UseVisualStyleBackColor = true;
            this.btnStage6.Click += new System.EventHandler(this.Stage_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 517);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(399, 19);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "https://github.com/read-air/winformbreaker";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 499);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "拙いソースコードは以下からご自由に";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStage6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnStage2);
            this.Controls.Add(this.btnStage1);
            this.Controls.Add(this.btnTutorial2);
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.btnTutorial1);
            this.Name = "MainMenu";
            this.Size = new System.Drawing.Size(464, 601);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTutorial1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTutorial2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.Button btnStage1;
        private System.Windows.Forms.Button btnStage2;
        private System.Windows.Forms.Button btnStage6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}
