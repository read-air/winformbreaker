using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormBreaker.Game;
using WinFormBreaker.Interface;

namespace WinFormBreaker.Controls {
    /// <summary>
    /// テキストボックスを表すブロック
    /// </summary>
    public class TextBoxBlock : TextBox, IBlock {
        #region 定数
        /// <summary>
        /// ウィンドウメッセージ、描画
        /// </summary>
        private const int WM_PAINT = 0x000F;
        #endregion

        #region メンバ変数
        /// <summary>
        /// 領域
        /// </summary>
        private Region region;
        /// <summary>
        /// 正解となるテキスト
        /// </summary>
        private string inputText;
        #endregion

        #region イベント
        /// <summary>
        /// ブロックが破壊されたことを通知するイベント
        /// </summary>
        public event EventHandler Broken;
        #endregion

        #region 外部プロパティ
        /// <summary>
        /// ブロックのリージョン
        /// </summary>
        Region IBlock.Region {
            get {
                if (this.region == null) {
                    var rectangle = new Rectangle(this.Location, this.ClientSize);
                    this.region = new Region(rectangle);
                }
                return this.region;
            }
        }

        /// <summary>
        /// 正解となるテキスト
        /// </summary>
        public string InputText {
            get {
                return inputText;
            }
            set {
                inputText = value;
                // 再描画する
                if (!this.DesignMode) {
                    this.Invalidate();
                }
            }
        }
        #endregion

        #region 外部メソッド
        /// <summary>
        /// このブロックを壊す。
        /// </summary>
        /// <param name="point">ヒットした座標</param>
        /// <param name="power">ボールパワー</param>
        /// <returns>ブロックの反射情報</returns>
        public ReflectionInfo Attack(IBall ball, Point point) {
            // テキストボックスは当たるたびに文字列が追加されていく
            // ボールは反射する
            var rectangle = new Rectangle(this.Location, this.ClientSize);
            var info = ReflectionHelper.CalculateReflection(ball, this, rectangle, point);
            this.ChangeText(ball.Power);
            return info;
        }

        /// <summary>
        /// テキスト変更時のイベント
        /// </summary>
        /// <param name="e">イベントパラメータ</param>
        protected override void OnTextChanged(EventArgs e) {
            this.CheckText();
            base.OnTextChanged(e);
        }

        /// <summary>
        /// リソース破棄時の動作を行う。
        /// </summary>
        /// <param name="disposing">リソースを破棄するか</param>
        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
            if (disposing) {
                // リソース破棄
                if (this.region != null) {
                    this.region.Dispose();
                    this.region = null;
                }
            }
        }

        /// <summary>
        /// ウィンドウプロシージャを呼び出す
        /// </summary>
        /// <param name="windowMessage">ウィンドウメッセージ</param>
        protected override void WndProc(ref Message windowMessage) {
            base.WndProc(ref windowMessage);
            // プレースホルダーを入力する
            if (windowMessage.Msg == WM_PAINT) {
                if (this.Enabled && !this.ReadOnly && !this.Focused && (this.inputText != null) && (this.inputText.Length > 0) && (this.TextLength == 0)) {
                    using (var g = this.CreateGraphics()) {
                        // 描画を一旦消してしまう
                        g.FillRectangle(new System.Drawing.SolidBrush(this.BackColor), this.ClientRectangle);

                        // プレースホルダのテキスト色を、前景色と背景色の中間として文字列を描画する
                        var placeholderTextColor = System.Drawing.Color.FromArgb((this.ForeColor.A >> 1 + this.BackColor.A >> 1), (this.ForeColor.R >> 1 + this.BackColor.R >> 1), ((this.ForeColor.G >> 1 + this.BackColor.G) >> 1), (this.ForeColor.B >> 1 + this.BackColor.B >> 1));
                        g.DrawString(this.inputText, this.Font, new System.Drawing.SolidBrush(placeholderTextColor), 1, 1);
                    }
                }
            }
        }
        #endregion

        #region 内部メソッド
        /// <summary>
        /// ボールのパワーに合わせてテキストを設定する。
        /// </summary>
        /// <param name="power">パワー</param>
        private void ChangeText(int power) {
            if (!this.IsDisposed && !string.IsNullOrEmpty(this.InputText)) {
                var text = new StringBuilder(this.Text);
                int index = 0;
                // ボールパワーがなくなるまで文字列を変更する
                while (power > 0) {
                    // 最後まで文字を入力したら終了
                    if (this.InputText.Length <= index) {
                        break;
                    }
                    // 文字をチェック
                    if (text.Length <= index) {
                        // 入力文字列が足りなければ追加する。
                        text.Append(this.inputText[index]);
                        // 追加したらパワーを1消費
                        power--;
                    } else if (text[index] != this.InputText[index]) {
                        // 入力文字列があり、文字が違えば変更する。
                        text[index] = this.InputText[index];
                        // 変更したらパワーを1消費
                        power--;
                    }
                    index++;
                }
                // 結果のテキストを設定する。
                string setText = text.ToString();
                if (this.Text != setText) {
                    this.Text = setText;
                }
            }
        }

        /// <summary>
        /// テキストをチェックして、入力文字列と一致したら破壊されたことにする。
        /// </summary>
        private void CheckText() {
            if (!this.IsDisposed && !string.IsNullOrEmpty(this.InputText)) {
                // 入力文字列のテキスト長さ分取り出す
                int length = this.InputText.Length;
                string check = new string(this.Text.Take(length).ToArray());
                // 取り出した文字列と一致すれば破壊
                if (check == this.InputText) {
                    this.Broken?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        #endregion
    }
}
