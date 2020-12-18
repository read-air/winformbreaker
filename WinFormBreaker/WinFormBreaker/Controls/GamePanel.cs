﻿using System;
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
        /// ロード時イベント
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void GamePanel_Load(object sender, EventArgs e) {
            // デザイン中は動作させない
            if (!this.DesignMode) {
                this.GameBoard = new GameBoard(this.pnlGameArea, this.scbBar, this.tmrUpdate);
            }
        }

        /// <summary>
        /// タイマーイベント
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void UpdateTimer_Tick(object sender, EventArgs e) {
            if (this.GameBoard != null) {
                this.GameBoard.Move();
            }
        }

        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void GameArea_MouseClick(object sender, MouseEventArgs e) {
            this.GameBoard.AddBall(new Point(e.X, e.Y));
        }
    }
}