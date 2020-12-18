using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormBreaker.Game {
    /// <summary>
    /// ぶつかった方向
    /// </summary>
    public enum Direction {
        /// <summary>なし</summary>
        None = 0b0000,
        /// <summary>左</summary>
        Left = 0b0001,
        /// <summary>右</summary>
        Right = 0b0010,
        /// <summary>上</summary>
        Top = 0b0100,
        /// <summary>下</summary>
        Bottom = 0b1000,
    }

    /// <summary>
    /// 反射タイプ(反射係数をどのように解釈するか)
    /// </summary>
    public enum ReflectionType {
        /// <summary>
        /// 反射は行わない
        /// </summary>
        None,
        /// <summary>
        /// 最大値のパーセンテージ
        /// </summary>
        Constant,
        /// <summary>
        /// 現在の速度の倍数
        /// </summary>
        Multiply,
    }

    /// <summary>
    /// 反射情報
    /// </summary>
    [DebuggerDisplay("Direction:{Direction}, Type:{ReflectionType} X:{CoefficientX} Y:{CoefficientY}")]
    public class ReflectionInfo {
        /// <summary>
        /// 反射係数(X方向)
        /// </summary>
        public double CoefficientX {
            get;
            set;
        }

        /// <summary>
        /// 反射係数(Y方向)
        /// </summary>
        public double CoefficientY {
            get;
            set;
        }

        /// <summary>
        /// 反射タイプ
        /// </summary>
        public ReflectionType ReflectionType {
            get;
            set;
        }

        /// <summary>
        /// 反射方向
        /// </summary>
        public Direction Direction {
            get;
            set;
        }
    }
}
