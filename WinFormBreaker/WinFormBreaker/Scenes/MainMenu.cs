using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormBreaker.Scenes {
    public partial class MainMenu : UserControl {
        public MainMenu() {
            InitializeComponent();
#if DEBUG
            this.btnDebug.Show();
#endif
        }

        /// <summary>
        /// ステージが選択された
        /// </summary>
        public event EventHandler<int> StageSelected;

        /// <summary>
        /// ステージクリックイベント
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void Stage_Click(object sender, EventArgs e) {
            // ステージが選択されたら選択イベント
            if(sender is Button button && button.Tag is string tag && int.TryParse(tag, out int value)) {
                this.StageSelected?.Invoke(this, value);
            }
        }
    }
}
