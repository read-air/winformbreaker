using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormBreaker.Controls;
using WinFormBreaker.Controls.Stages;

namespace WinFormBreaker {
    public partial class MainForm : Form {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm() {
            InitializeComponent();
        }

        /// <summary>
        /// 現在表示中のパネル
        /// </summary>
        private GamePanel GamePanel {
            get;
            set;
        }

        /// <summary>
        /// ロード時イベント
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void MainForm_Load(object sender, EventArgs e) {

        }

        /// <summary>
        /// ステージ番号選択イベント
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="stage">イベントパラメータ</param>
        private void MainMenu_StageSelected(object sender, int stage) {
            this.mainMenu.Visible = false;
            GamePanel gamePanel = null;
            // パネルを選択する
            switch (stage) {
                case 1:
                    gamePanel = new Stage1();
                    break;
                case 101:
                    // 101:チュートリアルステージ
                    break;
                default:
                    gamePanel = new DebugStage();
                    break;
            }
            // パネルをコントロールに追加してドックする
            if(gamePanel != null) {
                this.GamePanel = gamePanel;
                this.GamePanel.GameFinished += GamePanel_GameFinished;
                this.Controls.Add(gamePanel);
                gamePanel.Dock = DockStyle.Fill;
            }
        }

        /// <summary>
        /// ゲームが完了した
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="stage">イベントパラメータ</param>
        private void GamePanel_GameFinished(object sender, EventArgs e) {
            if(this.GamePanel != null) {
                this.GamePanel.GameFinished -= this.GamePanel_GameFinished;
                this.Controls.Remove(this.GamePanel);
                this.GamePanel.Dispose();
                this.GamePanel = null;
            }
            this.mainMenu.Show();
        }
    }
}
