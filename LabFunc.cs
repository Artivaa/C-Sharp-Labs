using System;

namespace Labs
{
    /// <summary>
    /// Вспомогательный класс для выполнения лабораторных работ по программированию
    /// </summary>
    public static class LabFunc
    {
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
        public static double CalculateSE(double x, double epsilon)
        {
            double sum = 0;
            int i = 1;
            while (true)
            {
                double term = Math.Pow(-1, i + 1) * Math.Pow(x, 2 * i) / (2 * i * (2 * i - 1));
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
        /// Вычисляет аналитическое значение функции
        /// </summary>
        /// <param name="x">Аргумент функции</param>
        /// <returns>Аналитическое значение функции</returns>
        public static double CalculateY(double x)
        {
            return x * Math.Atan(x) - 0.5 * Math.Log(1 + x * x);
        }

        #endregion
    }
}
