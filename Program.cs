using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LabFunc labFunc = new LabFunc();

            while (true)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        labFunc.Lab1();
                        break;
                    case "2":
                        labFunc.Lab2();
                        break;
                    case "3":
                        labFunc.Lab3();
                        break;
                    case "4":
                        labFunc.Lab4();
                        break;
                    case "5":
                        labFunc.Lab5();
                        break;
                    case "6":
                        labFunc.Lab6();
                        break;
                    case "7":
                        labFunc.Lab7();
                        break;
                    case "8":
                        labFunc.Lab8();
                        break;
                    case "9":
                        labFunc.Lab9();
                        break;
                    case "10":
                        labFunc.Lab10();
                        break;
                    case "11":
                        labFunc.Lab11();
                        break;
                    case "12":
                        labFunc.Lab12();
                        break;
                    case "13":
                        labFunc.Lab13();
                        break;
                    case "14":
                        labFunc.Lab14();
                        break;
                    case "15":
                        labFunc.Lab15();
                        break;
                    case "16":
                        labFunc.Lab16();
                        break;
                    case "0":
                        Console.WriteLine("Программа завершена.");
                        return;
                    default:
                        Console.WriteLine("Ошибка: Неверный выбор. Пожалуйста, выберите 1–16 или 0.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }

        }

        public static void DisplayMenu()
        {
            Console.WriteLine("===== МЕНЮ ПРОГРАММЫ =====");
            Console.WriteLine("1.  Работа 1");
            Console.WriteLine("2.  Работа 2");
            Console.WriteLine("3.  Работа 3");
            Console.WriteLine("4.  Работа 4");
            Console.WriteLine("5.  Работа 5");
            Console.WriteLine("6.  Работа 6");
            Console.WriteLine("7.  Работа 7");
            Console.WriteLine("8.  Работа 8");
            Console.WriteLine("9.  Работа 9");
            Console.WriteLine("10. Работа 10");
            Console.WriteLine("11. Работа 11");
            Console.WriteLine("12. Работа 12");
            Console.WriteLine("13. Работа 13");
            Console.WriteLine("14. Работа 14");
            Console.WriteLine("15. Работа 15");
            Console.WriteLine("16. Работа 16");
            Console.WriteLine("0.  Выход");
            Console.WriteLine("==========================");
            Console.Write("Введите номер работы: ");
        }
    }
    
}
