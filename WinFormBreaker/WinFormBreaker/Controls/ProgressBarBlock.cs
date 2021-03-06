﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormBreaker.Interface;
using WinFormBreaker.Game;

namespace WinFormBreaker.Controls {
    public class ProgressBarBlock : ProgressBar, IBlock{
        #region 
        /// <summary>
        /// 領域
        /// </summary>
        private Region region;
        #endregion

        #region イベント
        /// <summary>
        /// ブロックが破壊されたことを通知するイベント
        /// </summary>
        public event EventHandler Broken;
        /// <summary>
        /// プログレスバーの値の変化を通知するイベント
        /// </summary>
        public event EventHandler ProgressChanged;
        #endregion

        #region 外部プロパティ
        /// <summary>
        /// 値
        /// </summary>
        public new int Value {
            get {
                return base.Value;
            }
            set {
                if(base.Value != value) {
                    base.Value = value;
                    this.ProgressChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        #endregion

        #region 外部メソッド
        /// <summary>
        /// 命中したかチェックを行います。
        /// </summary>
        /// <param name="point">チェックする座標</param>
        /// <returns>命中したかどうか</returns>
        public bool CheckHit(Point point) {
            var rectangle = new Rectangle(this.Location, this.ClientSize);
            return rectangle.Contains(point);
        }

        /// <summary>
        /// このブロックを壊す。
        /// </summary>
        /// <param name="point">ヒットした座標</param>
        /// <param name="power">ボールパワー</param>
        /// <returns>ブロックの反射情報</returns>
        public ReflectionInfo Attack(IBall ball, Point point) {
            // プログレスバーに当たるたび、パワー分値が増加する
            // 破壊されたらボールは反射する
            var rectangle = new Rectangle(this.Location, this.ClientSize);
            var info = ReflectionHelper.CalculateReflection(ball, this, rectangle, point);
            // 設定値
            int setValue = this.Value + ball.Power;
            if(setValue >= this.Maximum) {
                // 最大値以上になったら、破壊イベントを送信
                this.Broken?.Invoke(this, EventArgs.Empty);
            } else {
                // 最大値未満なら、値を加算
                this.Value = setValue;
            }
            return info;
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
        #endregion
    }
}
