using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    /// <summary>
    /// Основной класс для выполнения лабораторных работ по программированию
    /// </summary>
    internal class LabFunc
    {
        /// <summary>
        /// Выполняет лабораторную работу №1: вычисления выражений, проверка принадлежности точки и вычисление выражений с float/double
        /// </summary>
        public void Lab1()
        {
            Console.WriteLine("Практическая работа №1");

            // Задача 1: Вычисления выражений
            Console.WriteLine("Задача 1:");

            int m = ReadInt("Введите m: ");
            int n = ReadInt("Введите n: ");
            double x = ReadDoubleInRange("Введите x для выражения 4 в пределах [-1; 1]: ", -1, 1);

            // Выражение 1
            {
                int m1 = m, n1 = n;
                Console.WriteLine($"Выражение 1: m={m1}, n={n1} Значение m - --n = {m1 - --n1}");
                Console.WriteLine($"После выражения 1: m={m1}, n={n1}\n");
            }

            // Выражение 2
            {
                int m2 = m, n2 = n;
                Console.WriteLine($"Выражение 2: m={m2}, n={n2} Значение m++ < n = {m2++ < n2}");
                Console.WriteLine($"После выражения 2: m={m2}, n={n2}\n");
            }

            // Выражение 3
            {
                int m3 = m, n3 = n;
                Console.WriteLine($"Выражение 3: m={m3}, n={n3} Значение n++ > m = {n3++ > m3}");
                Console.WriteLine($"После выражения 3: m={m3}, n={n3}\n");
            }

            // Выражение 4
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

            double numerator = Math.Pow(a + b, 3) - Math.Pow(a, 3);
            double denominator = 3 * a * Math.Pow(b, 2) + Math.Pow(b, 3);
            Console.WriteLine($"Double: {numerator / denominator}");

            float aFloat = 1000f;
            float bFloat = 0.0001f;

            float numeratorF = (float)Math.Pow(aFloat + bFloat, 3) - (float)Math.Pow(aFloat, 3);
            float denominatorF = 3 * aFloat * (float)Math.Pow(bFloat, 2) + (float)Math.Pow(bFloat, 3);
            Console.WriteLine($"Float: {numeratorF / denominatorF}");
        }

        /// <summary>
        /// Выполняет лабораторную работу №2: сумма четной последовательности, кратность элементов и сумма ряда
        /// </summary>
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

            int first;
            
            do
            {
                first = ReadInt("Введите первый элемент последовательности (не может быть 0): ");
                if (first == 0)
                {
                    Console.WriteLine("Деление на ноль невозможно. Введите ненулевое значение.");
                }
            } while (first == 0);
            
            int count = 0;
            int current;

            do
            {
                current = ReadInt("Введите число последовательности (введите 0 для завершения): ");
                if (current != 0 && current % first == 0)
                {
                    count++;
                }
            } while (current != 0);

            Console.WriteLine($"Первый элемент последовательности: {first}");
            Console.WriteLine($"Количество элементов, кратных {first}: {count}");

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

        /// <summary>
        /// Выполняет лабораторную работу №3: численное интегрирование функции методом трапеций
        /// </summary>
        public void Lab3()
        {
            const double StartX = 0.1, EndX = 0.8;
            const int Steps = 10;
            const int NTermCount = 10;
            const double Epsilon = 0.0001;
            double step = (EndX - StartX) / Steps;

            Console.WriteLine("Вычисление функции");
            for (int i = 0; i <= Steps; i++)
            {
                double x = StartX + i * step;
                double sn = CalculateSN(x, NTermCount);
                double se = CalculateSE(x, Epsilon);
                double y = CalculateY(x);

                Console.WriteLine($"X = {x:F4} SN = {sn:F6} SE = {se:F6} Y = {y:F6}");
            }
        }

        /// <summary>
        /// Выполняет лабораторную работу №4: операции с массивами (удаление, вставка, перестановка, сортировка)
        /// </summary>
        public void Lab4()
        {
            int n = ReadInt("Введите количество элементов массива n: ");
            // Создание и заполнение массива случайными числами
            Random rnd = new Random();
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(1, 100); // числа от 1 до 100
            }

            // Вывод исходного массива
            Console.WriteLine("\nИсходный массив:");
            PrintArray(array);

            // Удаление N элементов начиная с индекса K
            int N = ReadInt("\nВведите количество удаляемых элементов N: ");
            int K = ReadInt("Введите начальный индекс K для удаления: ");
            array = DeleteElements(array, K, N);
            Console.WriteLine("Массив после удаления:");
            PrintArray(array);

            // Добавление элемента на позицию K
            int newElement = ReadInt("\nВведите новый элемент для добавления: ");
            K = ReadInt("Введите индекс K для добавления: ");
            array = InsertElement(array, K, newElement);
            Console.WriteLine("Массив после добавления элемента:");
            PrintArray(array);

            // Перестановка четных и нечетных элементов
            SwapEvenOdd(array);
            Console.WriteLine("\nМассив после перестановки четных/нечетных:");
            PrintArray(array);

            // Поиск элемента, равного среднему арифметическому
            SearchForAverageAndCountCompares(array, "исходном");

            // Сортировка простым обменом
            BubbleSort(array);
            Console.WriteLine("\nМассив после сортировки:");
            PrintArray(array);

            // Поиск в отсортированном массиве
            SearchForAverageAndCountCompares(array, "отсортированном");
        }

        // Заглушки для незавершенных лабораторных работ
        public void Lab5() => Console.WriteLine("Подождите. Скоро будет :D");
        public void Lab6() => Console.WriteLine("Подождите. Скоро будет :D");
        public void Lab7() => Console.WriteLine("Подождите. Скоро будет :D");
        public void Lab8() => Console.WriteLine("Подождите. Скоро будет :D");
        public void Lab9() => Console.WriteLine("Подождите. Скоро будет :D");
        public void Lab10() => Console.WriteLine("Подождите. Скоро будет :D");
        public void Lab11() => Console.WriteLine("Подождите. Скоро будет :D");
        public void Lab12() => Console.WriteLine("Подождите. Скоро будет :D");
        public void Lab13() => Console.WriteLine("Подождите. Скоро будет :D");
        public void Lab14() => Console.WriteLine("Подождите. Скоро будет :D");
        public void Lab15() => Console.WriteLine("Подождите. Скоро будет :D");
        public void Lab16() => Console.WriteLine("Подождите. Скоро будет :D");

        #region Вспомогательные методы ввода

        /// <summary>
        /// Считывает целое число из консоли с обработкой ошибок ввода
        /// </summary>
        /// <param name="message">Сообщение для пользователя</param>
        /// <returns>Введенное целое число</returns>
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

        /// <summary>
        /// Считывает число с плавающей точкой из консоли с обработкой ошибок ввода
        /// </summary>
        /// <param name="message">Сообщение для пользователя</param>
        /// <returns>Введенное число с плавающей точкой</returns>
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

        /// <summary>
        /// Считывает число с плавающей точкой в заданном диапазоне с обработкой ошибок
        /// </summary>
        /// <param name="message">Сообщение для пользователя</param>
        /// <param name="min">Минимальное значение диапазона</param>
        /// <param name="max">Максимальное значение диапазона</param>
        /// <returns>Введенное число в заданном диапазоне</returns>
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

        #endregion

        #region Методы для Lab3 - численное интегрирование

        /// <summary>
        /// Вычисляет сумму ряда с заданным количеством членов
        /// </summary>
        /// <param name="x">Аргумент функции</param>
        /// <param name="n">Количество членов ряда</param>
        /// <returns>Значение суммы ряда</returns>
        private double CalculateSN(double x, int n)
        {
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                double term = Math.Pow(-1, i + 1) * Math.Pow(x, 2 * i) / (2 * i * (2 * i - 1));
                sum += term;
            }
            return sum;
        }

        /// <summary>
        /// Вычисляет сумму ряда с заданной точностью (Epsilon)
        /// </summary>
        /// <param name="x">Аргумент функции</param>
        /// <param name="epsilon">Требуемая точность вычислений</param>
        /// <returns>Значение суммы ряда с заданной точностью</returns>
        private double CalculateSE(double x, double epsilon)
        {
            double sum = 0;
            int i = 1;
            while (true)
            {
                double term = Math.Pow(-1, i + 1) * Math.Pow(x, 2 * i) / (2 * i * (2 * i - 1));
                if (Math.Abs(term) < epsilon)
                    break;
                sum += term;
                i++;
            }
            return sum;
        }

        /// <summary>
        /// Вычисляет аналитическое значение функции
        /// </summary>
        /// <param name="x">Аргумент функции</param>
        /// <returns>Аналитическое значение функции</returns>
        private double CalculateY(double x)
        {
            return x * Math.Atan(x) - 0.5 * Math.Log(1 + x * x);
        }

        #endregion

        #region Методы для работы с массивами (Lab4)

        /// <summary>
        /// Выводит массив в консоль
        /// </summary>
        /// <param name="arr">Массив для вывода</param>
        private void PrintArray(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }

        /// <summary>
        /// Удаляет N элементов из массива начиная с индекса K
        /// </summary>
        /// <param name="arr">Исходный массив</param>
        /// <param name="K">Начальный индекс удаления</param>
        /// <param name="N">Количество удаляемых элементов</param>
        /// <returns>Новый массив без удаленных элементов</returns>
        private int[] DeleteElements(int[] arr, int K, int N)
        {
            if (K < 0 || K >= arr.Length || N < 0)
                return arr;

            N = Math.Min(N, arr.Length - K);
            int[] newArray = new int[arr.Length - N];

            for (int i = 0; i < K; i++)
                newArray[i] = arr[i];

            for (int i = K + N; i < arr.Length; i++)
                newArray[i - N] = arr[i];

            return newArray;
        }

        /// <summary>
        /// Вставляет элемент в массив на позицию K
        /// </summary>
        /// <param name="arr">Исходный массив</param>
        /// <param name="K">Индекс вставки</param>
        /// <param name="element">Вставляемый элемент</param>
        /// <returns>Новый массив с вставленным элементом</returns>
        private int[] InsertElement(int[] arr, int K, int element)
        {
            if (K < 0 || K > arr.Length)
                return arr;

            int[] newArray = new int[arr.Length + 1];

            for (int i = 0; i < K; i++)
                newArray[i] = arr[i];

            newArray[K] = element;

            for (int i = K; i < arr.Length; i++)
                newArray[i + 1] = arr[i];

            return newArray;
        }

        /// <summary>
        /// Меняет местами четные и нечетные элементы массива попарно
        /// </summary>
        /// <param name="arr">Массив для перестановки</param>
        private void SwapEvenOdd(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i += 2)
            {
                int temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
            }
        }

        /// <summary>
        /// Находит элементы массива, равные среднему арифметическому и подсчитывает сравнения
        /// </summary>
        /// <param name="arr">Массив для поиска</param>
        /// <param name="arrayType">Тип массива для вывода в консоль</param>
        private int SearchForAverageAndCountCompares(int[] arr, string arrayType)
        {
            Console.WriteLine($"\n--- Поиск в {arrayType} массиве ---");
            if (arr.Length == 0)
            {
                Console.WriteLine("Массив пуст, поиск невозможен.");
                return 0;
            }

            double average = arr.Average();
            Console.WriteLine($"Среднее арифметическое: {average:F2}");

            int comparisons = 0;
            bool found = false;

            for (int i = 0; i < arr.Length; i++)
            {
                comparisons++; // Увеличиваем счетчик на каждом сравнении
                if (Math.Abs(arr[i] - average) < 0.001)
                {
                    Console.WriteLine($"Найден элемент {arr[i]} на позиции {i}.");
                    found = true;
                    // Можно добавить break, если нужно найти только первое вхождение
                }
            }

            if (!found)
            {
                Console.WriteLine("Элемент, равный среднему арифметическому, не найден.");
            }

            // Возвращаем и выводим результат
            Console.WriteLine($"Потребовалось сравнений: {comparisons}");
            return comparisons;
        }

        /// <summary>
        /// Сортирует массив методом пузырька (bubble sort)
        /// </summary>
        /// <param name="arr">Массив для сортировки</param>
        private void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        #endregion
    }
}