using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormBreaker.Interface;
using WinFormBreaker.Game;

namespace WinFormBreaker.Controls {
    public class CheckBoxBlock : CheckBox, IBlock {
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CheckBoxBlock() : base() {
            this.Checked = true;
        }
        #endregion

        #region イベント
        /// <summary>
        /// ブロックが破壊されたことを通知するイベント
        /// </summary>
        public event EventHandler Broken;
        #endregion

        #region 外部メソッド
        /// <summary>
        /// 命中したかチェックを行います。
        /// </summary>
        /// <param name="point">チェックする座標</param>
        /// <returns>命中したかどうか</returns>
        public bool CheckHit(Point point) {
            const int BOX_MARGIN = 1;
            const int BOX_SIZE = 12;
            var topLeft = new Point(this.Location.X + BOX_MARGIN, this.Location.Y + BOX_MARGIN);
            var size = new Size(BOX_SIZE, BOX_SIZE);
            var rectangle = new Rectangle(topLeft, size);
            return rectangle.Contains(point);
        }

        /// <summary>
        /// このブロックを壊す。
        /// </summary>
        /// <param name="point">ヒットした座標</param>
        /// <param name="power">ボールパワー</param>
        /// <returns>ブロックの反射情報</returns>
        public ReflectionInfo Attack(IBall ball, Point point) {
            // ボタンは1回で破壊される
            // 破壊されたらボールは反射する
            var rectangle = new Rectangle(this.Location, this.ClientSize);
            var info = ReflectionHelper.CalculateReflection(ball, this, rectangle, point);
            // 破壊イベントを送信
            this.Broken?.Invoke(this, EventArgs.Empty);
            return info;
        }

        /// <summary>
        /// チェック状態が変化したときのイベントを動作させる。
        /// </summary>
        /// <param name="e">イベントパラメータ</param>
        protected override void OnCheckedChanged(EventArgs e) {
            // チェックが外されたときに破壊される
            if (!this.Checked) {
                this.Broken?.Invoke(this, EventArgs.Empty);
            }
            base.OnCheckedChanged(e);
        }

        /// <summary>
        /// リソース破棄時の動作を行う。
        /// </summary>
        /// <param name="disposing">リソースを破棄するか</param>
        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
        }
        #endregion
    }
}
