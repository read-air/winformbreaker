using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using WinFormBreaker.Interface;
using WinFormBreaker.Game;

namespace WinFormBreaker.Controls {
    public partial class GamePanel : UserControl {
        /// <summary>
        /// 端の幅
        /// </summary>
        private const int SIDE_WIDTH = 20;

        /// <summary>
        /// コンストラクタ
        /// </summary>

        public GamePanel() {
            InitializeComponent();
        }

        /// <summary>
        /// ゲームが完了した
        /// </summary>
        public event EventHandler GameFinished;

        /// <summary>
        /// ボール
        /// </summary>
        private BallRadioButton BreakBall {
            get;
            set;
        }

        /// <summary>
        /// ゲームボード
        /// </summary>
        private GameBoard GameBoard {
            get;
            set;
        }

        /// <summary>
        /// ゲームの終了処理を行う
        /// </summary>
        protected void FinishGame() {
            this.GameFinished?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// マウスクリック
        /// </summary>
        /// <param name="e">イベント</param>
        protected override void OnMouseClick(MouseEventArgs e) {
            this.GameBoard.AddBall(new Point(e.X, e.Y));
        }

        /// <summary>
        /// ロード時イベント
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void GamePanel_Load(object sender, EventArgs e) {
            // デザイン中は動作させない
            if (!this.DesignMode) {
                this.GameBoard = new GameBoard(this, this.scbBar, this.tmrUpdate);
                this.GameBoard.GameFinished += GameBoard_GameFinished;
            }
        }

        /// <summary>
        /// ゲーム完了
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void GameBoard_GameFinished(object sender, EventArgs e) {
            // ゲーム完了処理を行う
            this.FinishGame();
        }
    }
}
