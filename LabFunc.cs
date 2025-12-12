using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Labs
{
    /// <summary>
    /// Вспомогательный класс для выполнения лабораторных работ по программированию
    /// </summary>
    public static class LabFunc
    {
        /// <summary>
        /// Генератор случайных чисел для использования в классе.
        /// </summary>
        private static readonly Random rnd = new Random();

        #region Вспомогательные методы ввода

        /// <summary>
        /// Считывает целое число из консоли с обработкой ошибок ввода
        /// </summary>
        /// <param name="message">Сообщение для пользователя</param>
        /// <returns>Введенное целое число</returns>
        public static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }

                Console.WriteLine("Ошибка: нужно ввести целое число!");
            }
        }

        /// <summary>
        /// Считывает число с плавающей точкой из консоли с обработкой ошибок ввода
        /// </summary>
        /// <param name="message">Сообщение для пользователя</param>
        /// <returns>Введенное число с плавающей точкой</returns>
        public static double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }

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
        public static double ReadDoubleInRange(string message, double min, double max)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    if (value >= min && value <= max)
                    {
                        return value;
                    }

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
        public static double CalculateSN(double x, int n)
        {
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                // Формула для члена ряда: (-1)^(i+1) * x^(2i) / (2i * (2i - 1))
                double term = Math.Pow(-1, i + 1) * Math.Pow(x, 2 * i) / (2 * i * (2 * i - 1));
                sum += term;
            }
            return sum;
        }

        /// <summary>
        /// Вычисляет сумму ряда с заданной точностью (Epsilon)
        /// </summary>
        /// <param name="x">Аргумент функции</param>
        /// <param name="epsilon">Требуемая точность вычислений (максимальный модуль последнего члена)</param>
        /// <returns>Значение суммы ряда с заданной точностью</returns>
        public static double CalculateSE(double x, double epsilon)
        {
            double sum = 0;
            int i = 1;
            while (true)
            {
                // Формула для члена ряда: (-1)^(i+1) * x^(2i) / (2i * (2i - 1))
                double term = Math.Pow(-1, i + 1) * Math.Pow(x, 2 * i) / (2 * i * (2 * i - 1));

                // Проверка условия останова: |A_i| < epsilon
                if (Math.Abs(term) < epsilon)
                {
                    break;
                }

                sum += term;
                i++;
            }
            return sum;
        }

        /// <summary>
        /// Вычисляет аналитическое значение функции: f(x) = x * arctg(x) - 0.5 * ln(1 + x^2)
        /// </summary>
        /// <param name="x">Аргумент функции</param>
        /// <returns>Аналитическое значение функции</returns>
        public static double CalculateY(double x)
        {
            return x * Math.Atan(x) - 0.5 * Math.Log(1 + x * x);
        }

        #endregion

        #region Методы для Lab5 Многомерные и рваные массивы, строки

        /// <summary>
        /// Генерирует и заполняет случайными целыми числами от 1 до 99 двумерный массив.
        /// </summary>
        /// <param name="rows">Количество строк.</param>
        /// <param name="cols">Количество столбцов.</param>
        /// <returns>Сгенерированный двумерный массив.</returns>
        public static int[,] GenerateArray(int rows, int cols)
        {
            int[,] newArray = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                newArray[i, j] = rnd.Next(1, 100);
            return newArray;
        }

        /// <summary>
        /// Добавляет новый столбец в конец существующего двумерного массива.
        /// </summary>
        /// <param name="original">Исходный двумерный массив.</param>
        /// <returns>Новый двумерный массив с добавленным столбцом, заполненным случайными числами от 100 до 199.</returns>
        /// <exception cref="ArgumentNullException">Выбрасывается, если <paramref name="original"/> равен null.</exception>
        public static int[,] AddColumn(int[,] original)
        {
            ArgumentNullException.ThrowIfNull(original);
            int rows = original.GetLength(0);
            int cols = original.GetLength(1);
            int newCols = cols + 1;

            // Создаем новый массив большего размера
            int[,] newArray = new int[rows, newCols];

            for (int i = 0; i < rows; i++)
            {
                // Копируем старые данные
                for (int j = 0; j < cols; j++)
                {
                    newArray[i, j] = original[i, j];
                }
                // Заполняем новый столбец
                newArray[i, cols] = rnd.Next(100, 200);
            }

            return newArray;
        }

        /// <summary>
        /// Выводит содержимое двумерного массива в консоль.
        /// </summary>
        /// <param name="array">Двумерный массив для печати.</param>
        public static void PrintArray(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write($"{array[i, j], 4} ");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Генерирует зубчатый массив (массив массивов) с указанным количеством строк
        /// и случайной длиной каждой строки в заданном диапазоне.
        /// </summary>
        /// <param name="rows">Количество строк в зубчатом массиве.</param>
        /// <param name="minLen">Минимальная возможная длина строки.</param>
        /// <param name="maxLen">Максимальная возможная длина строки.</param>
        /// <returns>Сгенерированный зубчатый массив, заполненный случайными числами от 1 до 19.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Выбрасывается, если <paramref name="rows"/>, <paramref name="minLen"/> отрицательны.</exception>
        /// <exception cref="ArgumentException">Выбрасывается, если <paramref name="maxLen"/> меньше <paramref name="minLen"/>.</exception>
        public static int[][] GenerateJaggedArray(int rows, int minLen, int maxLen)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(rows);
            ArgumentOutOfRangeException.ThrowIfNegative(minLen);
            if (maxLen < minLen)
                throw new ArgumentException("Максимальная длинна должна быть больше минимальной");

            int[][] jagged = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int length = rnd.Next(minLen, maxLen + 1);
                jagged[i] = new int[length];
                for (int j = 0; j < length; j++)
                {
                    jagged[i][j] = rnd.Next(1, 20); // Числа поменьше, чтобы легче было попасть в K
                }
            }
            return jagged;
        }

        /// <summary>
        /// Удаляет из зубчатого массива те строки, которые содержат заданное число <paramref name="k"/>.
        /// </summary>
        /// <param name="jagged">Исходный зубчатый массив.</param>
        /// <param name="k">Число, наличие которого в строке приводит к её удалению.</param>
        /// <returns>Новый зубчатый массив, содержащий только те строки, в которых нет числа <paramref name="k"/>.</returns>
        public static int[][] RemoveRowsContainingK(int[][] jagged, int k)
        {
            // Создаем список для хранения строк, которые НЕ содержат k.
            // Используем List, так как мы заранее не знаем, сколько строк останется.
            List<int[]> tempResult = new List<int[]>();

            // Проходим по каждой строке зубчатого массива
            for (int i = 0; i < jagged.Length; i++)
            {
                int[] currentRow = jagged[i];
                bool isFound = false;

                // Вручную проверяем, есть ли число k в текущей строке (замена .Contains)
                for (int j = 0; j < currentRow.Length; j++)
                {
                    if (currentRow[j] == k)
                    {
                        isFound = true;
                        break; // Если нашли k, дальше эту строку проверять нет смысла
                    }
                }

                // Если k не найдено, добавляем строку в наш список
                if (!isFound)
                {
                    tempResult.Add(currentRow);
                }
            }

            // Вывод информации (логика остается прежней)
            int removedCount = jagged.Length - tempResult.Count;

            if (removedCount > 0)
            {
                Console.WriteLine($"\nУдалено строк: {removedCount}");
            }
            else
            {
                Console.WriteLine($"\nЧисло {k} не найдено, ничего не удалено.");
            }

            // Преобразуем список обратно в массив массивов
            return [.. tempResult];
        }

        /// <summary>
        /// Выводит содержимое зубчатого массива в консоль.
        /// </summary>
        /// <param name="jagged">Зубчатый массив для печати.</param>
        public static void PrintJaggedArray(int[][] jagged)
        {
            if (jagged.Length == 0)
            {
                Console.WriteLine("(Пустой массив)");
                return;
            }

            for (int i = 0; i < jagged.Length; i++)
            {
                Console.Write($"Строка {i}: ");
                foreach (var item in jagged[i])
                {
                    Console.Write($"{item, 5} ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Меняет местами первое и последнее предложения в строке.
        /// </summary>
        /// <param name="text">Исходный текст.</param>
        /// <returns>Текст с переставленными первым и последним предложениями, или исходный текст, если предложений меньше двух.</returns>
        public static string SwapFirstAndLastSentence(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            // Разбиваем текст на предложения. Шаблон ищет разделители . ! ? с последующим пробелом.
            var sentences = Regex
                .Split(text, @"(?<=[.!?])\s+")
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToArray();

            // Если предложений мало, просто возвращаем исходный текст
            if (sentences.Length < 2)
                return text;

            // Использование кортежей для обмена и оператора ^1 (индекс с конца)
            (sentences[0], sentences[^1]) = (sentences[^1], sentences[0]);

            return string.Join(" ", sentences);
        }

        #endregion
    }
}
