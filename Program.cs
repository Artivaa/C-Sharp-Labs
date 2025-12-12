using System;
using System.Collections.Generic;
using Labs.Labs;
using Labs.Labs.Lab10;
using Labs.Labs.Lab9;

namespace Labs
{
    /// <summary>
    /// Основной класс программы для запуска лабораторных работ
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // Используем Dictionary для маппинга выбора пользователя на действие
            var labActions = new Dictionary<string, Action>
            {
                ["1"] = () => new Lab1().Run(),
                ["3"] = () => new Lab3().Run(),
                ["5"] = () => new Lab5().Run(),
                ["9"] = () => new Lab9().Run(),
                ["10"] = () => new Lab10().Run(),
            };

            while (true)
            {
                DisplayMenu();
                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    // Проверяем, есть ли выбранный ключ в словаре
                    case var key when labActions.ContainsKey(key):
                        labActions[key].Invoke(); // Запускаем соответствующую работу
                        break;
                    case "0":
                        Console.WriteLine("Программа завершена.");
                        return;

                    default:
                        Console.WriteLine(
                            "Ошибка: Неверный выбор. Пожалуйста, выберите 1, 3, 5, 9, 10 или 0."
                        );
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        /// <summary>
        /// Отображает интерактивное меню выбора лабораторных работ
        /// </summary>
        public static void DisplayMenu()
        {
            Console.WriteLine("===== МЕНЮ ПРОГРАММЫ =====");
            Console.WriteLine("1.  Работа 1");
            Console.WriteLine("3.  Работа 3");
            Console.WriteLine("5.  Работа 5");
            Console.WriteLine("9.  Работа 9");
            Console.WriteLine("10.  Работа 10");
            Console.WriteLine("0.  Выход");
            Console.WriteLine("==========================");
            Console.Write("Введите номер работы: ");
        }
    }
}
