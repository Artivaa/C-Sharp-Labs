using System;
using static Labs.LabFunc;

namespace Labs.Labs.Lab9
{
    /// <summary>
    /// Представляет лабораторную работу №9 по теме "Перегрузка операторов".
    /// Демонстрирует использование унарных операций (++, --), бинарных операций сравнения,
    /// и явного/неявного приведения типов, реализованных в классе <see cref="Triangle"/>.
    /// </summary>
    public class Lab9 : ILab
    {
        /// <summary>
        /// Выполняет демонстрацию функциональности класса <see cref="Triangle"/>:
        /// создание объектов, тестирование перегруженных операторов инкремента/декремента,
        /// операций сравнения по площади, а также приведения типов к <see cref="double"/> и <see cref="bool"/>.
        /// </summary>
        public void Run()
        {
            // Создаём валидные треугольники
            Triangle t1 = GenerateRandomTriangle();
            Triangle t2 = GenerateRandomTriangle();
            Triangle t3 = GenerateRandomTriangle();
            Console.WriteLine("Исходные треугольники:");
            Console.Write("t1: ");
            t1.PrintSides();
            Console.Write("t2: ");
            t2.PrintSides();
            Console.Write("t3: ");
            t3.PrintSides();

            // Демонстрация унарных операций ++ и --
            Console.WriteLine("\nДемонстрация операции ++ (постфиксная):");
            Triangle t1Copy = new(t1); // Сохраняем копию для сравнения
            Triangle t4 = t1++; // t1++ возвращает старое значение, затем увеличивает
            Console.WriteLine("После выполнения t1++:");
            Console.Write("t1 (увеличенный): ");
            t1.PrintSides();
            Console.Write("t4 (исходный t1): ");
            t4.PrintSides();

            Console.WriteLine("\nДемонстрация операции -- (постфиксная):");
            Triangle t5 = t1--; // t1-- возвращает увеличенное значение, затем уменьшает
            Console.WriteLine("После выполнения t1--:");
            Console.Write("t1 (вернулся к исходному): ");
            t1.PrintSides();
            Console.Write("t5 (увеличенный t1): ");
            t5.PrintSides();

            // Проверка, что t1 вернулся к исходному состоянию
            Console.WriteLine(
                $"\nt1 равен исходному значению: "
                    + $"{Math.Abs(t1.A - t1Copy.A) < 0.001 && Math.Abs(t1.B - t1Copy.B) < 0.001 && Math.Abs(t1.C - t1Copy.C) < 0.001}"
            );

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
                // Генерируем гарантированно невалидный треугольник
                double invalidA = Rnd.Next(1, 50);
                double invalidB = Rnd.Next(1, 50);
                double invalidC = invalidA + invalidB + 10; // Нарушаем неравенство треугольника

                invalid = new Triangle(invalidA, invalidB, invalidC);
                Console.WriteLine("Невалидный треугольник создан (это не должно произойти)");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Невалидный треугольник корректно отклонен: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
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
