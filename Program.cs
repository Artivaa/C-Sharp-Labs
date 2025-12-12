using System;
using System.Collections.Generic;
using Labs.Labs;

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
            };

            while (true)
            {
                DisplayMenu();
                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Программа завершена.");
                        return;

                    // Проверяем, есть ли выбранный ключ в словаре
                    case var key when labActions.ContainsKey(key):
                        labActions[key].Invoke(); // Запускаем соответствующую работу
                        break;

                    default:
                        Console.WriteLine(
                            "Ошибка: Неверный выбор. Пожалуйста, выберите 1, 3, 5 или 0."
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
            Console.WriteLine("0.  Выход");
            Console.WriteLine("==========================");
            Console.Write("Введите номер работы: ");
        }
    }
}
