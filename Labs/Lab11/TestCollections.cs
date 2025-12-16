using System;
using System.Collections.Generic;
using System.Diagnostics;
using Labs.Labs.Lab10;

namespace Labs.Labs
{
    public class TestCollections
    {
        // Поля коллекций согласно заданию
        // Коллекция_1 - Queue
        public Queue<Factory> Col1_Value = new();
        public Queue<string> Col1_String = new();

        // Коллекция_2 - SortedDictionary
        // TKey (Organization) - базовый, TValue (Factory) - производный
        public SortedDictionary<Organization, Factory> Col2_KeyVal = new();
        public SortedDictionary<string, Factory> Col2_StringVal = new();

        // Объекты для поиска (первый, центральный, последний, отсутствующий)
        private Factory _firstElement;
        private Factory _middleElement;
        private Factory _lastElement;
        private Factory _noneElement;

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

            // 1. Queue<TValue> (Contains)
            MeasureSearch(
                "Queue<T>",
                () => Col1_Value.Contains(_firstElement),
                () => Col1_Value.Contains(_middleElement),
                () => Col1_Value.Contains(_lastElement),
                () => Col1_Value.Contains(_noneElement)
            );

            // 2. Queue<string> (Contains)
            MeasureSearch(
                "Queue<str>",
                () => Col1_String.Contains(_firstElement.ToString()),
                () => Col1_String.Contains(_middleElement.ToString()),
                () => Col1_String.Contains(_lastElement.ToString()),
                () => Col1_String.Contains(_noneElement.ToString())
            );

            // 3. SortedDictionary<Key, Val> (ContainsKey)
            MeasureSearch(
                "SortDict<Key,Val> Key",
                () => Col2_KeyVal.ContainsKey(_firstElement),
                () => Col2_KeyVal.ContainsKey(_middleElement),
                () => Col2_KeyVal.ContainsKey(_lastElement),
                () => Col2_KeyVal.ContainsKey(_noneElement)
            );

            // 4. SortedDictionary<str, Val> (ContainsKey)
            MeasureSearch(
                "SortDict<str,Val> Key",
                () => Col2_StringVal.ContainsKey(_firstElement.ToString()),
                () => Col2_StringVal.ContainsKey(_middleElement.ToString()),
                () => Col2_StringVal.ContainsKey(_lastElement.ToString()),
                () => Col2_StringVal.ContainsKey(_noneElement.ToString())
            );

            // 5. SortedDictionary<Key, Val> (ContainsValue)
            // Ищем ЗНАЧЕНИЕ (Value) в словаре
            MeasureSearch(
                "SortDict<Key,Val> Val",
                () => Col2_KeyVal.ContainsValue(_firstElement),
                () => Col2_KeyVal.ContainsValue(_middleElement),
                () => Col2_KeyVal.ContainsValue(_lastElement),
                () => Col2_KeyVal.ContainsValue(_noneElement)
            );
        }

        // Вспомогательный метод для замера и вывода
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

        private long GetTicks(Func<bool> action)
        {
            Stopwatch sw = Stopwatch.StartNew();
            action();
            sw.Stop();
            return sw.ElapsedTicks;
        }
    }
}
