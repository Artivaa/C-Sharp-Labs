using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    internal class LabFunc
    {
        public void Lab1()
        {
            Console.WriteLine("Практическая работа №1");

            // Задача 1: Вычисления выражений
            Console.WriteLine("Задача 1:");

            int m = ReadInt("Введите m: ");
            int n = ReadInt("Введите n: ");
            double x = ReadDoubleInRange("Введите x для выражения 4 в пределах [-1; 1]: ", -1, 1);

            Console.WriteLine($"Выражение 1: m={m}, n={n} Значение m - --n = {m - --n}");
            Console.WriteLine($"Выражение 2: m={m}, n={n} Значение m++ < n = {m++ < n}");
            Console.WriteLine($"Выражение 3: m={m}, n={n} Значение n++ > m = {n++ > m}");
            Console.WriteLine($"Выражение 4: x={x}, Значение cos(arcsin(x)) = {Math.Cos(Math.Asin(x))}");

            // Задача 2: Проверка принадлежности точки
            Console.WriteLine("\nЗадача 2:");

            double X1 = ReadDouble("Введите X1: ");
            double Y1 = ReadDouble("Введите Y1: ");

            Console.WriteLine($"Координата принадлежит: {Math.Abs(X1) + Math.Abs(Y1) <= 2}");

            // Задача 3: Вычисление выражения с float и double
            Console.WriteLine("\nЗадача 3:");

            double a = 1000;
            double b = 0.0001;

            double temp1 = Math.Pow(a + b, 3);
            double temp2 = Math.Pow(a, 3) + 3 * Math.Pow(a, 2) * b;

            Console.WriteLine($"Значение выражения (Double): {(temp1 - temp2) / (3 * a * Math.Pow(b, 2) + Math.Pow(b, 2))}");

            float aFloat = 1000f;
            float bFloat = 0.0001f;

            float temp1Float = (float)Math.Pow(aFloat + bFloat, 3);
            float temp2Float = (float)(Math.Pow(aFloat, 3) + 3 * Math.Pow(aFloat, 2) * bFloat);

            Console.WriteLine($"Float: {(temp1Float - temp2Float) / ((float)(3 * aFloat * Math.Pow(bFloat, 2) + Math.Pow(bFloat, 2)))}");
        }

        public void Lab2()
        {
            Console.WriteLine("Практическая работа №2");

            // Задача 1: Сумма четной последовательности
            Console.WriteLine("Задача 1:");
            
            int n = ReadInt("Введите количество чисел n: ");

            long sum = 0;
            for (int i = 0; i < n; i++)
            {
                int number = ReadInt($"Введите число №{i + 1}: ");

                // Если номер четный (нумерация начинается с 1, значит четные номера - нечетные индексы)
                if ((i + 1) % 2 == 0)
                {
                    sum += number;
                }
            }

            Console.WriteLine($"Сумма элементов с четными номерами: {sum}");

            // Задача 2: Количество элементов, кратных первому из последовательности
            Console.WriteLine("\nЗадача 2:");

            int first = ReadInt("Введите первый элемент последовательности: ");
            int count = 0;

            if(first == 0)
            {
                Console.WriteLine("Последовательность пуста.");
            }
            else
            {
                int current = first;
                while (true)
                {
                    if (current % first == 0)
                    {
                        count++;
                    }

                    current = ReadInt("Введите число последовательности (введите 0 для завершения последовательности): ");
                    if (current == 0)
                    {
                        break;
                    }
                }

                Console.WriteLine($"Первый элемент последовательности: {first}");
                Console.WriteLine($"Количество элементов, кратных {first}: {count}");
            }

            // задача 3: Сумма ряда n
            Console.WriteLine("\nЗадача 3:");

            n = ReadInt("Введите количество чисел n: ");

            sum = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0) // каждое третье число вычитаем
                    sum -= i;
                else
                    sum += i;
            }

            Console.WriteLine($"Сумма ряда: {sum}");
        }

        public void Lab3()
        {
            Console.WriteLine("Подождите. Скоро будет :D");
        }

        public void Lab4()
        {
            Console.WriteLine("Подождите. Скоро будет :D");
        }

        public void Lab5()
        {
            Console.WriteLine("Подождите. Скоро будет :D");
        }

        public void Lab6()
        {
            Console.WriteLine("Подождите. Скоро будет :D");
        }

        public void Lab7()
        {
            Console.WriteLine("Подождите. Скоро будет :D");
        }

        public void Lab8()
        {
            Console.WriteLine("Подождите. Скоро будет :D");
        }

        public void Lab9()
        {
            Console.WriteLine("Подождите. Скоро будет :D");
        }

        public void Lab10()
        {
            Console.WriteLine("Подождите. Скоро будет :D");
        }

        public void Lab11()
        {
            Console.WriteLine("Подождите. Скоро будет :D");
        }

        public void Lab12()
        {
            Console.WriteLine("Подождите. Скоро будет :D");
        }

        public void Lab13()
        {
            Console.WriteLine("Подождите. Скоро будет :D");
        }

        public void Lab14()
        {
            Console.WriteLine("Подождите. Скоро будет :D");
        }

        public void Lab15()
        {
            Console.WriteLine("Подождите. Скоро будет :D");
        }

        public void Lab16()
        {
            Console.WriteLine("Подождите. Скоро будет :D");
        }

        private int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;
                Console.WriteLine("Ошибка: нужно ввести целое число!");
            }
        }
        private double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;
                Console.WriteLine("Ошибка: нужно ввести число!");
            }
        }
        private double ReadDoubleInRange(string message, double min, double max)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    if (value >= min && value <= max)
                        return value;
                    Console.WriteLine($"Ошибка: число должно быть в диапазоне [{min}; {max}]!");
                }
                else
                {
                    Console.WriteLine("Ошибка: нужно ввести число!");
                }
            }
        }
    }
}
