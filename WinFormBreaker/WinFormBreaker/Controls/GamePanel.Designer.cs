
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
            this.lblClear = new System.Windows.Forms.Label();
            this.lblGameOver = new System.Windows.Forms.Label();
            this.lblBallRest = new System.Windows.Forms.Label();
            this.lblRestBallValue = new System.Windows.Forms.Label();
            this.bsGameInfo = new System.Windows.Forms.BindingSource(this.components);
            this.scbBar = new WinFormBreaker.Controls.GameScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.bsGameInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 20;
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblClear.Location = new System.Drawing.Point(119, 77);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(215, 33);
            this.lblClear.TabIndex = 2;
            this.lblClear.Text = "ステージクリア！";
            this.lblClear.Visible = false;
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblGameOver.Location = new System.Drawing.Point(119, 77);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(197, 33);
            this.lblGameOver.TabIndex = 2;
            this.lblGameOver.Text = "ゲームオーバー";
            this.lblGameOver.Visible = false;
            // 
            // lblBallRest
            // 
            this.lblBallRest.AutoSize = true;
            this.lblBallRest.Location = new System.Drawing.Point(4, 4);
            this.lblBallRest.Name = "lblBallRest";
            this.lblBallRest.Size = new System.Drawing.Size(49, 12);
            this.lblBallRest.TabIndex = 3;
            this.lblBallRest.Text = "残り玉数";
            // 
            // lblRestBallValue
            // 
            this.lblRestBallValue.AutoSize = true;
            this.lblRestBallValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsGameInfo, "RestBalls", true));
            this.lblRestBallValue.Location = new System.Drawing.Point(59, 4);
            this.lblRestBallValue.Name = "lblRestBallValue";
            this.lblRestBallValue.Size = new System.Drawing.Size(17, 12);
            this.lblRestBallValue.TabIndex = 3;
            this.lblRestBallValue.Text = "30";
            // 
            // bsGameInfo
            // 
            this.bsGameInfo.DataSource = typeof(WinFormBreaker.Game.GameInfo);
            // 
            // scbBar
            // 
            this.scbBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.scbBar.LargeChange = 25;
            this.scbBar.Location = new System.Drawing.Point(0, 623);
            this.scbBar.Name = "scbBar";
            this.scbBar.Size = new System.Drawing.Size(480, 17);
            this.scbBar.TabIndex = 1;
            // 
            // GamePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRestBallValue);
            this.Controls.Add(this.lblBallRest);
            this.Controls.Add(this.lblGameOver);
            this.Controls.Add(this.lblClear);
            this.Controls.Add(this.scbBar);
            this.Name = "GamePanel";
            this.Size = new System.Drawing.Size(480, 640);
            this.Load += new System.EventHandler(this.GamePanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsGameInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrUpdate;
        private GameScrollBar scbBar;
        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.Label lblBallRest;
        private System.Windows.Forms.Label lblRestBallValue;
        private System.Windows.Forms.BindingSource bsGameInfo;
    }
}
