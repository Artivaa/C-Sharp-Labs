using System;
using System.Collections.Generic;
using System.Diagnostics;
using Labs.Labs.Lab10;

namespace Labs.Labs.Lab11
{
    /// <summary>
    /// Класс для тестирования производительности операций поиска
    /// (<c>Contains</c>, <c>ContainsKey</c>, <c>ContainsValue</c>)
    /// в различных коллекциях (<see cref="Queue{T}"/> и <see cref="SortedDictionary{TKey, TValue}"/>).
    /// </summary>
    public class TestCollections
    {
        // Поля коллекций согласно заданию

        /// <summary>
        /// Коллекция 1: Очередь (<see cref="Queue{T}"/>) с элементами производного класса <see cref="Factory"/>.
        /// </summary>
        public Queue<Factory> Col1_Value = new();

        /// <summary>
        /// Коллекция 1: Очередь (<see cref="Queue{T}"/>) со строковыми представлениями элементов.
        /// </summary>
        public Queue<string> Col1_String = new();

        /// <summary>
        /// Коллекция 2: Сортированный словарь (<see cref="SortedDictionary{TKey, TValue}"/>),
        /// где ключ - базовый класс <see cref="Organization"/>, а значение - производный <see cref="Factory"/>.
        /// </summary>
        public SortedDictionary<Organization, Factory> Col2_KeyVal = new();

        /// <summary>
        /// Коллекция 2: Сортированный словарь (<see cref="SortedDictionary{TKey, TValue}"/>),
        /// где ключ - строка, а значение - <see cref="Factory"/>.
        /// </summary>
        public SortedDictionary<string, Factory> Col2_StringVal = new();

        // Объекты для поиска (первый, центральный, последний, отсутствующий)
        private Factory _firstElement;
        private Factory _middleElement;
        private Factory _lastElement;
        private Factory _noneElement;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="TestCollections"/> и заполняет все коллекции
        /// указанным количеством элементов <see cref="Factory"/>.
        /// </summary>
        /// <param name="count">Количество элементов для генерации и добавления в коллекции.</param>
        public TestCollections(int count)
        {
            if (count <= 0)
                count = 1;

            Console.WriteLine($"\nГенерация {count} элементов...");

            for (int i = 0; i < count; i++)
            {
                // Создаем элемент с УНИКАЛЬНЫМ именем для использования в качестве ключа
                // Используем производный класс Factory
                string uniqueName = $"Factory_{i}";
                Factory factory = new Factory(uniqueName, 100 + i, $"Type_{i}");

                // Добавляем в Queue<Factory>
                Col1_Value.Enqueue(factory);

                // Добавляем в Queue<string> (используем ToString())
                Col1_String.Enqueue(factory.ToString());

                // Добавляем в SortedDictionary<Organization, Factory>
                // Ключ - базовый класс (upcast), Значение - производный
                // Organization реализует IComparable, поэтому может быть ключом
                Col2_KeyVal.Add(factory, factory);

                // Добавляем в SortedDictionary<string, Factory>
                Col2_StringVal.Add(factory.ToString(), factory);

                // Сохраняем ссылки на элементы для тестов
                if (i == 0)
                    _firstElement = factory;
                if (i == count / 2)
                    _middleElement = factory;
                if (i == count - 1)
                    _lastElement = factory;
            }

            // Создаем элемент, которого точно нет в коллекции
            _noneElement = new Factory("Factory_MISSING", 999, "None");
        }

        /// <summary>
        /// Выполняет замер времени выполнения операций поиска
        /// (<c>Contains</c>, <c>ContainsKey</c>, <c>ContainsValue</c>)
        /// для первого, центрального, последнего и отсутствующего элементов в каждой коллекции.
        /// </summary>
        public void MeasureTime()
        {
            Console.WriteLine("\n=== Результаты измерения времени поиска (в тиках) ===");
            // Форматированный вывод заголовка
            Console.WriteLine(
                "{0,-20} | {1,-15} | {2,-15} | {3,-15} | {4,-15}",
                "Коллекция / Метод",
                "Первый",
                "Центральный",
                "Последний",
                "Нет в колл."
            );
            Console.WriteLine(new string('-', 90));

            // 1. Queue<TValue> (Contains) - Линейный поиск O(N)
            MeasureSearch(
                "Queue<T>",
                () => Col1_Value.Contains(_firstElement),
                () => Col1_Value.Contains(_middleElement),
                () => Col1_Value.Contains(_lastElement),
                () => Col1_Value.Contains(_noneElement)
            );

            // 2. Queue<string> (Contains) - Линейный поиск O(N)
            MeasureSearch(
                "Queue<str>",
                () => Col1_String.Contains(_firstElement.ToString()),
                () => Col1_String.Contains(_middleElement.ToString()),
                () => Col1_String.Contains(_lastElement.ToString()),
                () => Col1_String.Contains(_noneElement.ToString())
            );

            // 3. SortedDictionary<Key, Val> (ContainsKey) - Бинарное дерево O(log N)
            MeasureSearch(
                "SortDict<Key,Val> Key",
                () => Col2_KeyVal.ContainsKey(_firstElement),
                () => Col2_KeyVal.ContainsKey(_middleElement),
                () => Col2_KeyVal.ContainsKey(_lastElement),
                () => Col2_KeyVal.ContainsKey(_noneElement)
            );

            // 4. SortedDictionary<str, Val> (ContainsKey) - Бинарное дерево O(log N)
            MeasureSearch(
                "SortDict<str,Val> Key",
                () => Col2_StringVal.ContainsKey(_firstElement.ToString()),
                () => Col2_StringVal.ContainsKey(_middleElement.ToString()),
                () => Col2_StringVal.ContainsKey(_lastElement.ToString()),
                () => Col2_StringVal.ContainsKey(_noneElement.ToString())
            );

            // 5. SortedDictionary<Key, Val> (ContainsValue) - Линейный перебор значений O(N)
            // Ищем ЗНАЧЕНИЕ (Value) в словаре
            MeasureSearch(
                "SortDict<Key,Val> Val",
                () => Col2_KeyVal.ContainsValue(_firstElement),
                () => Col2_KeyVal.ContainsValue(_middleElement),
                () => Col2_KeyVal.ContainsValue(_lastElement),
                () => Col2_KeyVal.ContainsValue(_noneElement)
            );
        }

        /// <summary>
        /// Вспомогательный метод для замера и вывода времени поиска для четырех контрольных элементов.
        /// </summary>
        /// <param name="label">Метка для отображения в таблице результатов.</param>
        /// <param name="checkFirst">Функция поиска первого элемента.</param>
        /// <param name="checkMid">Функция поиска центрального элемента.</param>
        /// <param name="checkLast">Функция поиска последнего элемента.</param>
        /// <param name="checkNone">Функция поиска отсутствующего элемента.</param>
        private void MeasureSearch(
            string label,
            Func<bool> checkFirst,
            Func<bool> checkMid,
            Func<bool> checkLast,
            Func<bool> checkNone
        )
        {
            long t1 = GetTicks(checkFirst);
            long t2 = GetTicks(checkMid);
            long t3 = GetTicks(checkLast);
            long t4 = GetTicks(checkNone);

            Console.WriteLine(
                "{0,-20} | {1,-15} | {2,-15} | {3,-15} | {4,-15}",
                label,
                t1,
                t2,
                t3,
                t4
            );
        }

        /// <summary>
        /// Замеряет время выполнения переданного делегата <paramref name="action"/> в тактах процессора (<see cref="Stopwatch.ElapsedTicks"/>).
        /// </summary>
        /// <param name="action">Действие (поиск), время выполнения которого необходимо измерить.</param>
        /// <returns>Время выполнения действия в тиках.</returns>
        private long GetTicks(Func<bool> action)
        {
            Stopwatch sw = Stopwatch.StartNew();
            action();
            sw.Stop();
            return sw.ElapsedTicks;
        }
    }
}
