using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormBreaker.Game {
    /// <summary>
    /// ゲーム情報
    /// </summary>
    public class GameInfo : INotifyPropertyChanged {
        /// <summary>
        /// ボール初期数
        /// </summary>
        private const int INIT_BALL = 30;

        /// <summary>
        /// ボール残り数
        /// </summary>
        private int restBalls;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GameInfo() {
            this.ResetState();
        }

        /// <summary>
        /// プロパティに変更があったときの通知イベント
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// ボール残り数のイベント
        /// </summary>
        private readonly PropertyChangedEventArgs RestBallsEventArgs = new PropertyChangedEventArgs(nameof(RestBalls));

        /// <summary>
        /// ボール残り数
        /// </summary>
        public int RestBalls {
            get {
                return this.restBalls;
            }
            set {
                if(restBalls != value) {
                    restBalls = value;
                    this.PropertyChanged?.Invoke(this, RestBallsEventArgs);
                }
            }
        }

        /// <summary>
        /// リセット
        /// </summary>
        public void ResetState() {
            this.RestBalls = INIT_BALL;
        }
    }
}
