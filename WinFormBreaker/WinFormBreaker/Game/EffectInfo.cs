using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormBreaker.Game {

    /// <summary>
    /// エフェクトの種別
    /// </summary>
    public enum EffectType {
        /// <summary>なし</summary>
        None = 0,

    }

    /// <summary>
    /// エフェクト情報
    /// </summary>
    public class EffectInfo {
        /// <summary>
        /// エフェクト名
        /// </summary>
        public string Name {
            get;
            set;
        }

        /// <summary>
        /// エフェクト種別
        /// </summary>
        public EffectType Effect {
            get;
            set;
        }

        public override string ToString() {
            return this.Name;
        }
    }
}
