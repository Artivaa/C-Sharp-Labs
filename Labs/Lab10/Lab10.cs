using System;
using static Labs.LabFunc;

namespace Labs.Labs.Lab10
{
    /// <summary>
    /// Представляет демонстрационный класс для лабораторной работы №10 по теме
    /// "Иерархия классов, полиморфизм, интерфейсы, клонирование".
    /// </summary>
    public class Lab10 : ILab
    {
        /// <summary>
        /// Основной метод для запуска демонстрации.
        /// Выполняет следующие действия:
        /// <list type="bullet">
        ///     <item>Демонстрирует иерархию классов и полиморфизм (<c>Show()</c> vs <c>Display()</c>).</item>
        ///     <item>Выполняет запросы к массиву объектов разных типов.</item>
        ///     <item>Демонстрирует сортировку с использованием интерфейса <see cref="IComparable"/> (по имени).</item>
        ///     <item>Демонстрирует сортировку и бинарный поиск с использованием интерфейса <see cref="System.Collections.IComparer"/> (по количеству сотрудников).</item>
        ///     <item>Демонстрирует работу с массивом объектов, реализующих интерфейс <c>IInit</c> (задание 6).</item>
        ///     <item>Демонстрирует глубокое клонирование (<c>Clone()</c>) и поверхностное копирование (<c>ShallowCopy()</c>).</item>
        /// </list>
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Демонстрация иерархии классов \"Организация\"\n");

            int count = ReadPositiveInt("Введите количество организаций для генерации: ");

            Organization[] organizations = new Organization[count];

            Console.WriteLine("\nГенерация объектов случайным образом...\n");
            for (int i = 0; i < count; i++)
            {
                organizations[i] = CreateRandomOrganization();
            }

            PrintOrganizations(organizations);

            PrintOrganizationsNonVirtual(organizations);

            Console.WriteLine("Разница:");
            Console.WriteLine(
                "• Виртуальный метод Show() вызывает реализацию соответствующего типа объекта (полиморфизм)."
            );
            Console.WriteLine(
                "• Невиртуальный метод Display() всегда вызывает версию базового класса Organization, независимо от реального типа объекта."
            );

            Query_ByType(organizations);

            Query_EmployeeCountMin(organizations);

            Query_MaxSpecificValue(organizations);

            Console.WriteLine("=== Задание 2: Сортировка IComparable (по Имени) ===");
            Organization[] orgs =
            [
                // Заполняем массив разными типами
                new Factory(),
                new Library(),
                new InsuranceCompany(),
                new ShipbuildingCompany(),
                new Organization(),
            ];
            foreach (var o in orgs)
                o.RandomInit(); // Используем новый метод интерфейса

            Console.WriteLine("До сортировки:");
            PrintOrganizations(orgs);

            Array.Sort(orgs); // Использует CompareTo

            Console.WriteLine("После сортировки (по алфавиту):");
            PrintOrganizations(orgs);

            Console.WriteLine("\n=== Задание 3: Сортировка IComparer (по Сотрудникам) ===");
            Array.Sort(orgs, new SortByEmployeeCount());
            PrintOrganizations(orgs);

            Console.WriteLine("\n=== Задание 4: Бинарный поиск ===");
            // Для бинарного поиска массив должен быть отсортирован по критерию поиска!
            // Мы только что отсортировали по сотрудникам. Ищем организацию с определенным числом сотрудников.
            // Возьмем существующее число для примера
            int searchCount = orgs[2].EmployeeCount;
            Organization searchTarget = new() { EmployeeCount = searchCount };

            int index = Array.BinarySearch(orgs, searchTarget, new SortByEmployeeCount());

            Console.WriteLine($"Ищем организацию с {searchCount} сотрудниками.");
            if (index >= 0)
                Console.WriteLine(
                    $"Найдено на позиции {index + 1}: {orgs[index].Name} ({orgs[index].EmployeeCount} сотр.)"
                );
            else
                Console.WriteLine("Не найдено.");

            Console.WriteLine("\n=== Задание 6: Массив IInit (разные классы) ===");
            IInit[] initObjects =
            [
                new Factory(),
                new User(), // Сторонний класс
                new Library(),
                new User(),
            ];
            Console.WriteLine("Демонстрация RandomInit() и вывода:");
            foreach (var item in initObjects)
            {
                item.RandomInit();
                // User не наследник Organization, у него нет Show(), используем ToString() или проверку типов
                if (item is Organization org)
                    org.Show();
                else
                    Console.WriteLine(item.ToString());
            }

            Console.WriteLine("\n=== Задание 7: Клонирование (Deep) vs Копирование (Shallow) ===");
            Library originalLib = new("Ленинская Библиотека", 100, 5000);

            // Глубокое клонирование
            Library deepClone = (Library)originalLib.Clone();
            // Поверхностное копирование
            Library shallowCopy = (Library)originalLib.ShallowCopy();

            Console.WriteLine($"Оригинал: {originalLib.Name}, Книг: {originalLib.BooksCount}");
            Console.WriteLine($"Клон:     {deepClone.Name}, Книг: {deepClone.BooksCount}");
            Console.WriteLine($"Копия:    {shallowCopy.Name}, Книг: {shallowCopy.BooksCount}");

            Console.WriteLine("\nИзменяем оригинал...");
            originalLib.Name = "НОВАЯ БИБЛИОТЕКА";
            originalLib.BooksCount = 999999;

            Console.WriteLine($"Оригинал: {originalLib.Name}, Книг: {originalLib.BooksCount}");
            Console.WriteLine(
                $"Клон:     {deepClone.Name}, Книг: {deepClone.BooksCount} (Не изменился - новый объект)"
            );
            Console.WriteLine(
                $"Копия:    {shallowCopy.Name}, Книг: {shallowCopy.BooksCount} (Не изменился, так как поля значимые/строки immutable)"
            );

            Console.WriteLine(
                "\n*Примечание: Разница между Shallow и Deep копированием была бы видна, если бы внутри класса был изменяемый ссылочный тип (например, массив или другой объект). Для строк и чисел MemberwiseClone работает аналогично глубокому копированию.*"
            );
        }
    }
}
