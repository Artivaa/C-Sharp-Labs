using System;
using static Labs.LabFunc;

namespace Labs.Labs
{
    public class Lab1 : ILab
    {
        public void Run()
        {
            Console.WriteLine("Практическая работа №1");

            // Задача 1: Вычисления выражений
            Console.WriteLine("Задача 1:");

            int m = ReadInt("Введите m: ");
            int n = ReadInt("Введите n: ");
            double x = ReadDoubleInRange("Введите x для выражения 4 в пределах [-1; 1]: ", -1, 1);

            // Выражение 1
            {
                int m1 = m,
                    n1 = n;
                Console.WriteLine($"Выражение 1: m={m1}, n={n1} Значение m - --n = {m1 - --n1}");
                Console.WriteLine($"После выражения 1: m={m1}, n={n1}\n");
            }

            // Выражение 2
            {
                int m2 = m,
                    n2 = n;
                Console.WriteLine($"Выражение 2: m={m2}, n={n2} Значение m++ < n = {m2++ < n2}");
                Console.WriteLine($"После выражения 2: m={m2}, n={n2}\n");
            }

            // Выражение 3
            {
                int m3 = m,
                    n3 = n;
                Console.WriteLine($"Выражение 3: m={m3}, n={n3} Значение n++ > m = {n3++ > m3}");
                Console.WriteLine($"После выражения 3: m={m3}, n={n3}\n");
            }

            // Выражение 4
            Console.WriteLine(
                $"Выражение 4: x={x}, Значение cos(arcsin(x)) = {Math.Cos(Math.Asin(x))}"
            );

            // Задача 2: Проверка принадлежности точки
            Console.WriteLine("\nЗадача 2:");

            double X1 = ReadDouble("Введите X1: ");
            double Y1 = ReadDouble("Введите Y1: ");

            Console.WriteLine($"Координата принадлежит: {Math.Abs(X1) + Math.Abs(Y1) <= 2}");

            // Задача 3: Вычисление выражения с float и double
            Console.WriteLine("\nЗадача 3:");

            double a = 1000;
            double b = 0.0001;

            double numerator = Math.Pow(a + b, 3) - Math.Pow(a, 3);
            double denominator = 3 * a * Math.Pow(b, 2) + Math.Pow(b, 3);
            Console.WriteLine($"Double: {numerator / denominator}");

            float aFloat = 1000f;
            float bFloat = 0.0001f;

            float numeratorF = (float)Math.Pow(aFloat + bFloat, 3) - (float)Math.Pow(aFloat, 3);
            float denominatorF =
                3 * aFloat * (float)Math.Pow(bFloat, 2) + (float)Math.Pow(bFloat, 3);
            Console.WriteLine($"Float: {numeratorF / denominatorF}");
        }
    }
}
