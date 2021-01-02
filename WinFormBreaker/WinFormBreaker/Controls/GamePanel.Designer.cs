
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
            this.scbBar = new WinFormBreaker.Controls.GameScrollBar();
            this.SuspendLayout();
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 20;
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
            this.Controls.Add(this.scbBar);
            this.Name = "GamePanel";
            this.Size = new System.Drawing.Size(480, 640);
            this.Load += new System.EventHandler(this.GamePanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrUpdate;
        private GameScrollBar scbBar;
    }
}
