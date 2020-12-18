using System;
using System.Drawing;
using WinFormBreaker.Game;

namespace WinFormBreaker.Controls {
    /// <summary>
    /// 反射したときの計算を行う静的クラス
    /// </summary>
    public static class ReflectionHelper {
        /// <summary>
        /// 領域に当たったときの反射情報を計算する
        /// </summary>
        /// <param name="area">ブロックの領域</param>
        /// <param name="hitPoint">ボールがヒットした点</param>
        /// <param name="type">反射の種別</param>
        /// <param name="reflectX">反射の強さ(X)</param>
        /// <param name="reflectY">反射の強さ(Y)</param>
        /// <returns>反射情報</returns>
        public static ReflectionInfo CalculateReflection(Rectangle area, Point hitPoint, ReflectionType type = ReflectionType.Multiply, double reflectX = 1.0, double reflectY = 1.0) {
            // 中心座標とヒット位置からヒットした角度を求める
            // (Atan2の返す範囲は-π～π)
            var center = new Point(area.X + area.Width / 2, area.Y + area.Height / 2);
            int x = hitPoint.X - center.X;
            int y = -(hitPoint.Y - center.Y);
            double angle = Math.Atan2(y, x);
            // 領域の幅、高さから命中した方向を計算する
            double areaAngle = Math.Atan2(area.Height, area.Width);
            // ヒットした角度と領域の角度からヒットした方向を決定する
            Direction direction;
            if (angle >= -areaAngle && angle < areaAngle) {
                // 右 angleが-areaAngle ～ areaAngleの範囲内
                direction = Direction.Right;
            } else if (angle >= areaAngle && angle < Math.PI - areaAngle) {
                // 上 angleが areaAngle ～ π - areaAngle の範囲内
                direction = Direction.Top;
            } else if (angle >= -Math.PI + areaAngle && angle < -areaAngle) {
                // 下 angleが -π + areaAngle ～ - areaAngleの範囲内
                direction = Direction.Bottom;
            } else {
                // 左 それ以外
                direction = Direction.Left;
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
