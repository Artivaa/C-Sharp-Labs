using System;

namespace Labs.Labs.Lab9
{
    public class Lab9 : ILab
    {
        public void Run()
        {
            // Создаём валидные треугольники
            Triangle t1 = new(3, 4, 5);
            Triangle t2 = new(5, 12, 13);
            Triangle t3 = new(6, 8, 10);

            Console.WriteLine("Исходные треугольники:");
            Console.Write("t1: ");
            t1.PrintSides();
            Console.Write("t2: ");
            t2.PrintSides();
            Console.Write("t3: ");
            t3.PrintSides();

            // Демонстрация унарных операций ++ и --
            Console.WriteLine("\nДемонстрация операции ++:");
            Triangle t4 = t1++;
            Console.WriteLine("После выполнения t1++:");
            Console.Write("t1 (увеличенный): ");
            t1.PrintSides();
            Console.Write("t4 (исходный t1): ");
            t4.PrintSides();

            Console.WriteLine("\nДемонстрация операции --:");
            Triangle t5 = t1--;
            Console.WriteLine("После выполнения t1--:");
            Console.Write("t1 (вернулся к исходному): ");
            t1.PrintSides();

            // Приведение к double
            Console.WriteLine("\nЯвное приведение к double (площадь):");
            Console.WriteLine($"Площадь t1: {(double)t1:F3}");
            Console.WriteLine($"Площадь t2: {(double)t2:F3}");
            Console.WriteLine($"Площадь t3: {(double)t3:F3}");

            // Приведение к bool
            Console.WriteLine("\nНеявное приведение к bool (существует ли треугольник):");
            Console.WriteLine($"t1 существует: {t1}"); // true

            // Попытка создать невалидный треугольник
            Triangle invalid = null;
            try
            {
                invalid = new Triangle(1, 1, 3);
            }
            catch { }
            if (invalid == null || !invalid)
                Console.WriteLine("Невалидный треугольник корректно распознан как false");

            // Сравнение по площади
            Console.WriteLine("\nСравнение треугольников по площади:");
            Console.WriteLine($"t1 <= t3: {t1 <= t3}");
            Console.WriteLine($"t2 >= t3: {t2 >= t3}");
            Console.WriteLine($"t1 > t2: {t1 > t2}");

            // Количество объектов
            Console.WriteLine($"\nВсего создано объектов треугольников: {Triangle.Count}");
        }
    }
}
