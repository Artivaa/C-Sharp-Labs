using System;
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
            while (true)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Lab1 lab1 = new();
                        lab1.Run();
                        break;

                    case "3":
                        Lab3 lab3 = new();
                        lab3.Run();
                        break;

                    case "0":
                        Console.WriteLine("Программа завершена.");
                        return;
                    default:
                        Console.WriteLine(
                            "Ошибка: Неверный выбор. Пожалуйста, выберите 1, 3 или 0."
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
            Console.WriteLine("0.  Выход");
            Console.WriteLine("==========================");
            Console.Write("Введите номер работы: ");
        }
    }
}
