using System;
using static Labs.LabFunc;

namespace Labs.Labs
{
    /// <summary>
    /// Выполняет задания лабораторной работы №5:
    /// <list type="number">
    /// <item>Создание, вывод и добавление столбца в двумерный массив.</item>
    /// <item>Создание, вывод и удаление строк, содержащих число K, в рваном массиве.</item>
    /// <item>Обработка строк: ввод текста и перестановка первого и последнего предложений.</item>
    /// </list>
    /// </summary>
    public class Lab5 : ILab
    {
        /// <summary>
        /// Запускает выполнение Лабораторной работы 5.
        /// </summary>
        public void Run()
        {
            // --- ЗАДАНИЯ 1 и 2: Прямоугольный массив ---
            Console.WriteLine("--- Часть 1: Прямоугольная матрица ---");

            int rows = ReadInt("Введите число строк");
            int cols = ReadInt("Введите число столбцов");

            // 1. Сформировать и вывести
            int[,] array = GenerateArray(rows, cols);
            Console.WriteLine("Исходный массив:");
            PrintArray(array);

            // 2. Добавить столбец в конец
            Console.WriteLine("\nДобавляем случайный столбец в конец...");
            array = AddColumn(array);
            Console.WriteLine("Обновленная матрица:");
            PrintArray(array);

            // --- ЗАДАНИЯ 3 и 4: Рваный массив ---
            Console.WriteLine("\n--- Часть 2: Рваный массив ---");

            rows = ReadInt("Введите число строк");
            int minlen = ReadInt("Введите минимальную длинну");
            int maxlen = ReadInt("Введите максимальную длинну");

            // 3. Сформировать и вывести
            int[][] jaggedArray = GenerateJaggedArray(rows, minlen, maxlen);
            Console.WriteLine("Исходный рваный массив:");
            PrintJaggedArray(jaggedArray);

            int k = ReadInt("ведите число K для удаления строк: ");
            jaggedArray = RemoveRowsContainingK(jaggedArray, k);
            Console.WriteLine($"\nМассив после удаления строк, содержащих {k}:");
            PrintJaggedArray(jaggedArray);

            // --- ЗАДАНИЯ 5, 6, 7: Строки ---
            Console.WriteLine("\n--- Часть 3: Работа со строками ---");

            // 5. Ввод строки (или использование тестовой для примера)
            Console.WriteLine(
                "Введите текст (несколько предложений) или нажмите Enter для использования примера:"
            );
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                input =
                    "Привет, мир! Это второе предложение, в котором много слов. А это последнее предложение?";
                Console.WriteLine($"\nИспользуем строку по умолчанию:\n{input}");
            }

            // 6. Поменять местами первое и последнее предложение
            string resultText = SwapFirstAndLastSentence(input);

            // 7. Вывод результата
            Console.WriteLine("\nРезультат обработки текста:");
            Console.WriteLine(resultText);
        }
    }
}
