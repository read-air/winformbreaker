﻿using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormBreaker.Game;
using WinFormBreaker.Interface;

namespace WinFormBreaker.Controls {
    public class ButtonBlock : Button, IBlock {
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
            // ボタンは1回で破壊される
            // 破壊されたらボールは反射する
            var rectangle = new Rectangle(this.Location, this.ClientSize);
            var info = ReflectionHelper.CalculateReflection(ball, this, rectangle, point);
            // 破壊イベントを送信
            this.Broken?.Invoke(this, EventArgs.Empty);
            return info;
        }

        /// <summary>
        /// クリック時のイベントを動作させる。
        /// </summary>
        /// <param name="e">イベントパラメータ</param>
        protected override void OnClick(EventArgs e) {
            // クリックしたときもどうように破壊される
            this.Broken?.Invoke(this, EventArgs.Empty);
            base.OnClick(e);
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
