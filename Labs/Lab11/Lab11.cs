using System;
using System.Collections.Generic;
using Labs.Labs.Lab10;
using static Labs.LabFunc;

namespace Labs.Labs.Lab11
{
    public class Lab11 : ILab
    {
        // 1. Создать коллекцию, в которую добавить объекты созданной иерархии классов.
        private List<Organization> _collection = [];

        public void Run()
        {
            Console.WriteLine("=== Лабораторная работа №11: Коллекции List<T> ===");
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Меню ---");
                Console.WriteLine("1. Добавить элемент");
                Console.WriteLine("2. Удалить элемент");
                Console.WriteLine("3. Печать коллекции (foreach)");
                Console.WriteLine("4. Выполнить запросы");
                Console.WriteLine("5. Клонирование коллекции");
                Console.WriteLine("6. Сортировка и бинарный поиск");
                Console.WriteLine("7. Тестирование коллекций");
                Console.WriteLine("0. Выход");

                int choice = ReadInt("Выберите пункт: ");

                switch (choice)
                {
                    case 1:
                        AddElement();
                        break;
                    case 2:
                        RemoveElement();
                        break;
                    case 3:
                        PrintCollection(_collection, "Текущая коллекция");
                        break;
                    case 4:
                        ExecuteQueries();
                        break;
                    case 5:
                        TestCloning();
                        break;
                    case 6:
                        TestSortAndSearch();
                        break;
                    case 7:
                        RunPerformanceTest();
                        break;
                    case 0:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Неверный пункт меню.");
                        break;
                }
            }
        }

        // 2. Используя меню, реализовать добавление объектов коллекции.
        private void AddElement()
        {
            Console.WriteLine("\n1. Создать вручную");
            Console.WriteLine("2. Создать случайно");
            int mode = ReadInt("Выбор: ");

            Organization org = null;

            if (mode == 2)
            {
                org = CreateRandomOrganization(); // Метод из LabFunc
            }
            else
            {
                // Выбор типа для ручного создания
                Console.WriteLine(
                    "Типы: 1.Организация 2.Страховая 3.Судостроительная 4.Завод 5.Библиотека"
                );
                int type = ReadPositiveInt("Выберите тип: ");
                switch (type)
                {
                    case 1:
                        org = new Organization();
                        break;
                    case 2:
                        org = new InsuranceCompany();
                        break;
                    case 3:
                        org = new ShipbuildingCompany();
                        break;
                    case 4:
                        org = new Factory();
                        break;
                    case 5:
                        org = new Library();
                        break;
                    default:
                        Console.WriteLine("Неверный тип.");
                        return;
                }
                org.Init(); // Ручной ввод параметров
            }

            if (org != null)
            {
                _collection.Add(org);
                Console.WriteLine("Элемент добавлен.");
            }
        }

        // 2. Используя меню, реализовать удаление объектов коллекции.
        private void RemoveElement()
        {
            if (_collection.Count == 0)
            {
                Console.WriteLine("Коллекция пуста.");
                return;
            }

            // Выводим список с индексами для удобства
            for (int i = 0; i < _collection.Count; i++)
            {
                Console.Write($"[{i + 1}] ");
                _collection[i].Show();
            }

            int index = ReadInt("Введите номер элемента для удаления: ") - 1;

            if (index >= 0 && index < _collection.Count)
            {
                _collection.RemoveAt(index);
                Console.WriteLine("Элемент удален.");
            }
            else
            {
                Console.WriteLine("Неверный индекс.");
            }
        }

        // 4. Выполнить перебор элементов коллекции с помощью метода foreach.
        private void PrintCollection(List<Organization> list, string title)
        {
            Console.WriteLine($"\n--- {title} ---");
            if (list.Count == 0)
            {
                Console.WriteLine("Коллекция пуста.");
                return;
            }

            int i = 1;
            foreach (var item in list)
            {
                Console.Write($"{i++}. ");
                item.Show(); // Полиморфный вызов
            }
        }

        // 3. Разработать и реализовать три запроса.
        private void ExecuteQueries()
        {
            if (_collection.Count == 0)
            {
                Console.WriteLine("Коллекция пуста, запросы невозможны.");
                return;
            }

            Console.WriteLine("\n--- Запросы ---");

            // Запрос А: Подсчет количества Заводов (определенного вида)
            int factoryCount = 0;
            foreach (var item in _collection)
            {
                if (item is Factory)
                    factoryCount++;
            }
            Console.WriteLine($"1. Количество заводов в коллекции: {factoryCount}");

            // Запрос Б: Найти организацию с самым длинным названием
            Organization longestNameOrg = _collection[0];
            foreach (var item in _collection)
            {
                if (item.Name.Length > longestNameOrg.Name.Length)
                    longestNameOrg = item;
            }
            Console.WriteLine($"2. Самое длинное название: {longestNameOrg.Name}");

            // Запрос В: Суммарное количество сотрудников во всех судостроительных компаниях
            int totalShipbuilders = 0;
            foreach (var item in _collection)
            {
                if (item is ShipbuildingCompany)
                {
                    totalShipbuilders += item.EmployeeCount;
                }
            }
            Console.WriteLine($"3. Суммарно сотрудников на верфях: {totalShipbuilders}");
        }

        // 5. Выполнить клонирование коллекции.
        private void TestCloning()
        {
            if (_collection.Count == 0)
            {
                Console.WriteLine("Сначала добавьте элементы.");
                return;
            }

            Console.WriteLine("\n--- Клонирование ---");
            // Глубокое клонирование коллекции
            List<Organization> clonedList = [];
            foreach (var item in _collection)
            {
                // Используем метод Clone() из Organization (ICloneable)
                clonedList.Add((Organization)item.Clone());
            }

            Console.WriteLine("Коллекция успешно клонирована.");

            // Демонстрация независимости клона
            Console.WriteLine("Изменяем первый элемент в оригинальной коллекции...");
            _collection[0].Name = "ИЗМЕНЕННОЕ ИМЯ";

            Console.WriteLine($"Оригинал [0]: {_collection[0].Name}");
            Console.WriteLine($"Клон [0]:     {clonedList[0].Name}");

            if (_collection[0].Name != clonedList[0].Name)
                Console.WriteLine("(Коллекции независимы)");
        }

        // 6. Выполнить сортировку коллекции и поиск заданного элемента.
        private void TestSortAndSearch()
        {
            if (_collection.Count == 0)
            {
                Console.WriteLine("Коллекция пуста.");
                return;
            }

            // --- Сортировка ---
            Console.WriteLine("\n--- Сортировка (IComparable: по Названию) ---");
            _collection.Sort(); // Использует CompareTo внутри Organization
            PrintCollection(_collection, "Отсортированная коллекция");

            // --- Поиск ---
            Console.WriteLine("\n--- Бинарный поиск ---");
            // Для бинарного поиска коллекция ОБЯЗАНА быть отсортирована
            string searchName = ReadString("Введите название организации для поиска: ");

            // Создаем временный объект для сравнения (CompareTo сравнивает по Name)
            Organization searchPattern = new() { Name = searchName };

            int index = _collection.BinarySearch(searchPattern);

            if (index >= 0)
            {
                Console.WriteLine($"Элемент найден на позиции {index + 1}:");
                _collection[index].Show();
            }
            else
            {
                Console.WriteLine("Элемент не найден.");
            }
        }

        private static void RunPerformanceTest()
        {
            Console.WriteLine("\n--- Тестирование производительности коллекций ---");
            // Создаем коллекции с 1000 элементов (как в задании)
            TestCollections tester = new(1000);

            // Запускаем измерения
            tester.MeasureTime();

            Console.WriteLine("\nПояснение:");
            Console.WriteLine(
                "1. Queue.Contains: Линейный поиск O(N). Время зависит от позиции элемента."
            );
            Console.WriteLine(
                "2. SortedDictionary.ContainsKey: Бинарное дерево поиска O(log N). Время почти одинаковое (быстрое)."
            );
            Console.WriteLine(
                "3. SortedDictionary.ContainsValue: Линейный перебор значений O(N). Аналогично Queue."
            );
        }
    }
}
