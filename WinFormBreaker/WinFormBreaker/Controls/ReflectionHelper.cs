using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using WinFormBreaker.Game;
using WinFormBreaker.Interface;

namespace WinFormBreaker.Controls {
    /// <summary>
    /// 反射したときの計算を行う静的クラス
    /// </summary>
    public static class ReflectionHelper {
        /// <summary>
        /// 領域に当たったときの反射情報を計算する
        /// </summary>
        /// <param name="blockArea">ブロックの領域</param>
        /// <param name="hitPoint">ボールがヒットした点</param>
        /// <param name="type">反射の種別</param>
        /// <param name="reflectX">反射の強さ(X)</param>
        /// <param name="reflectY">反射の強さ(Y)</param>
        /// <returns>反射情報</returns>
        public static ReflectionInfo CalculateReflection(IBall ball, IBlock block, Rectangle blockArea, Point hitPoint, ReflectionType type = ReflectionType.Multiply, double reflectX = 1.0, double reflectY = 1.0) {
            Direction currentDirection = ball.Direction;
            // 命中座標に一番距離が近い地点を反射地点とする
            var list = new List<(Direction Direction, double Distance)>() {
                (Direction.Left, Math.Abs(blockArea.Left - hitPoint.X)),
                (Direction.Top, Math.Abs(blockArea.Top - hitPoint.Y)),
                (Direction.Right, Math.Abs(blockArea.Right - hitPoint.X)),
                (Direction.Bottom, Math.Abs(blockArea.Bottom - hitPoint.Y)),
            };
            Direction targetDirection = list.OrderBy(p => p.Distance).First().Direction;
            Direction direction = targetDirection;
            if((targetDirection & currentDirection) == targetDirection) {
                switch (targetDirection) {
                    case Direction.Top:
                        direction = Direction.Bottom;
                        break;
                    case Direction.Left:
                        direction = Direction.Right;
                        break;
                    case Direction.Right:
                        direction = Direction.Left;
                        break;
                    case Direction.Bottom:
                        direction = Direction.Top;
                        break;
                    default:
                        // DO NOTHING
                        break;
                }
            }
            var info = new ReflectionInfo() {
                Direction = direction,
                ReflectionType = type,
                CoefficientX = reflectX,
                CoefficientY = reflectY,
            };
            return info;
        }
    }
}
