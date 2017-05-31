using System;

/*
    Написать консольное приложение, которое проверяет
    принадлежность точки заштрихованной области.
    Пользователь вводит координаты точки (x; y) и выбирает
    букву графика (a-к). В консоли должно высветиться сообщение:
    «Точка [(x; y)] принадлежит фигуре [г]».
*/

namespace Task01
{
    struct DPoint
    {
        public double X;
        public double Y;

        public DPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    static class Figures
    {
        public static bool InCircle(DPoint point, DPoint center, double radius, bool withBorder = true)
        {
            var r = Math.Pow(point.X - center.X, 2) + Math.Pow(point.Y - center.Y, 2);
            return withBorder ? r <= radius * radius : r < radius * radius;
        }

        public static bool InRectange(DPoint point, DPoint leftUp, DPoint rightDown, bool withBorder = true)
        {
            return withBorder
                ? point.X >= leftUp.X && point.Y >= leftUp.Y &&
                  point.X <= rightDown.X && point.Y <= rightDown.Y

                : point.X > leftUp.X && point.Y > leftUp.Y &&
                  point.X < rightDown.X && point.Y < rightDown.Y;
        }

        public static bool InTriangle(DPoint point, DPoint t1Point, DPoint t2Point, DPoint t3Point, bool withBorder = true)
        {
            var a = (t1Point.X - point.X) * (t2Point.Y - t1Point.Y) - (t2Point.X - t1Point.X) * (t1Point.Y - point.Y);
            var b = (t2Point.X - point.X) * (t3Point.Y - t2Point.Y) - (t3Point.X - t2Point.X) * (t2Point.Y - point.Y);
            var c = (t3Point.X - point.X) * (t1Point.Y - t3Point.Y) - (t1Point.X - t3Point.X) * (t3Point.Y - point.Y);

            return withBorder
                ? a >= 0 && b >= 0 && c >= 0 || a <= 0 && b <= 0 && c <= 0
                : a > 0 && b > 0 && c > 0 || a < 0 && b < 0 && c < 0;
        }
    }
}
