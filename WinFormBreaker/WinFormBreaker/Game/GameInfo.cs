using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormBreaker.Game {
    /// <summary>
    /// ゲーム情報
    /// </summary>
    public class GameInfo {
        /// <summary>
        /// ボール初期数
        /// </summary>
        private const int INIT_BALL = 10;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GameInfo() {
            this.ResetState();
        }

        /// <summary>
        /// ボール残り数
        /// </summary>
        public int RestBalls {
            get;
            set;
        }

        /// <summary>
        /// リセット
        /// </summary>
        public void ResetState() {
            this.RestBalls = INIT_BALL;
        }
    }
}
