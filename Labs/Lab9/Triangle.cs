// Triangle.cs
using System;

namespace Labs.Labs.Lab9
{
    public class Triangle
    {
        private double a;
        private double b;
        private double c;

        private static int count = 0;

        public double A
        {
            get => a;
            set =>
                a =
                    value > 0
                        ? value
                        : throw new ArgumentException("Сторона должна быть положительной");
        }

        public double B
        {
            get => b;
            set =>
                b =
                    value > 0
                        ? value
                        : throw new ArgumentException("Сторона должна быть положительной");
        }

        public double C
        {
            get => c;
            set =>
                c =
                    value > 0
                        ? value
                        : throw new ArgumentException("Сторона должна быть положительной");
        }

        public static int Count => count;

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                throw new ArgumentException("Все стороны должны быть положительными");
            if (!IsValidTriangle(sideA, sideB, sideC))
                throw new ArgumentException("Нарушено неравенство треугольника");

            a = sideA;
            b = sideB;
            c = sideC;
            count++;
        }

        private static bool IsValidTriangle(double x, double y, double z)
        {
            return x + y > z && x + z > y && y + z > x;
        }

        public bool IsValid() => IsValidTriangle(a, b, c);

        private double CalculateArea()
        {
            double s = (a + b + c) / 2.0;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        public void PrintSides()
        {
            Console.WriteLine($"Стороны: a = {a:F2}, b = {b:F2}, c = {c:F2}");
        }

        public double GetArea() => IsValid() ? CalculateArea() : 0;

        public static double CalculateArea(double sideA, double sideB, double sideC)
        {
            if (!IsValidTriangle(sideA, sideB, sideC))
                return 0;
            double s = (sideA + sideB + sideC) / 2.0;
            return Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
        }

        public static Triangle operator ++(Triangle t)
        {
            return new Triangle(t.a + 1, t.b + 1, t.c + 1);
        }

        public static Triangle operator --(Triangle t)
        {
            if (t.a - 1 <= 0 || t.b - 1 <= 0 || t.c - 1 <= 0)
                throw new InvalidOperationException(
                    "Нельзя уменьшить стороны: результат будет неположительным"
                );
            return new Triangle(t.a - 1, t.b - 1, t.c - 1);
        }

        public static explicit operator double(Triangle t)
        {
            return t.IsValid() ? t.CalculateArea() : -1;
        }

        public static implicit operator bool(Triangle t)
        {
            return t.IsValid();
        }

        public static bool operator <=(Triangle t1, Triangle t2)
        {
            return t1.GetArea() <= t2.GetArea();
        }

        public static bool operator >=(Triangle t1, Triangle t2)
        {
            return t1.GetArea() >= t2.GetArea();
        }

        public static bool operator <(Triangle t1, Triangle t2)
        {
            return t1.GetArea() < t2.GetArea();
        }

        public static bool operator >(Triangle t1, Triangle t2)
        {
            return t1.GetArea() > t2.GetArea();
        }
    }
}
