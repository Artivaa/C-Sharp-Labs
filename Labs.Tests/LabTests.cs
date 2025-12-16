using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Labs;
using Labs.Labs.Lab10;
using Labs.Labs.Lab11;
using Labs.Labs.Lab9;
using Xunit;

namespace Labs.Tests
{
    public class LabTests
    {
        // === Lab5: Массивы и строки ===

        [Fact]
        public void AddColumn_AddsNewColumnWithRandomValues()
        {
            int[,] original =
            {
                { 1, 2 },
                { 3, 4 },
            };
            int[,] result = LabFunc.AddColumn(original);

            Assert.Equal(2, result.GetLength(0));
            Assert.Equal(3, result.GetLength(1));
            Assert.Equal(1, result[0, 0]);
            Assert.Equal(2, result[0, 1]);
            Assert.Equal(3, result[1, 0]);
            Assert.Equal(4, result[1, 1]);
            // Новый столбец: 100-199
            Assert.InRange(result[0, 2], 100, 199);
            Assert.InRange(result[1, 2], 100, 199);
        }

        [Fact]
        public void RemoveRowsContainingK_RemovesCorrectRows()
        {
            int[][] jagged =
            [
                [1, 2, 3],
                [4, 5, 6], // содержит 5 → будет удалена
                [7, 8, 5], // содержит 5 → будет удалена
            ];

            int[][] result = LabFunc.RemoveRowsContainingK(jagged, 5);

            // Должна остаться только одна строка: {1, 2, 3}
            Assert.Single(result); // вместо Assert.Equal(2, result.Length)

            // Убеждаемся, что нет строк с числом 5
            Assert.DoesNotContain(result, row => row.Contains(5));

            // Проверяем, что осталась именно первая строка
            Assert.Contains(result, row => row.SequenceEqual(new[] { 1, 2, 3 }));
        }

        [Fact]
        public void SwapFirstAndLastSentence_SwapsCorrectly()
        {
            string input = "Первое предложение. Второе предложение. Третье предложение.";
            string expected = "Третье предложение. Второе предложение. Первое предложение.";
            string result = LabFunc.SwapFirstAndLastSentence(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SwapFirstAndLastSentence_LessThanTwoSentences_ReturnsOriginal()
        {
            string input = "Одно предложение.";
            string result = LabFunc.SwapFirstAndLastSentence(input);
            Assert.Equal(input, result);
        }

        // === Lab9: Triangle ===

        [Fact]
        public void Triangle_ValidSides_CreatesSuccessfully()
        {
            var t = new Triangle(3, 4, 5);
            Assert.True(t.IsValid());
            Assert.Equal(6.0, (double)t, 3);
        }

        [Fact]
        public void Triangle_InvalidSides_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(1, 1, 3));
        }

        [Fact]
        public void Triangle_IncrementAndDecrement_Works()
        {
            var t = new Triangle(5, 5, 5);
            var incremented = t++;
            Assert.Equal(5, incremented.A);
            Assert.Equal(6, t.A);

            var decremented = t--;
            Assert.Equal(6, decremented.A);
            Assert.Equal(5, t.A);
        }

        [Fact]
        public void Triangle_ComparisonByArea()
        {
            var t1 = new Triangle(3, 4, 5); // площадь 6
            var t2 = new Triangle(5, 5, 6); // площадь ~14.14
            Assert.True(t1 < t2);
            Assert.True(t2 > t1);
        }

        // === Lab10: Organization hierarchy ===

        [Fact]
        public void Organization_Polymorphism_ShowCallsCorrectOverride()
        {
            Organization org = new Library("TestLib", 10, 1000);
            var output = CaptureOutput(() => org.Show());
            Assert.Contains("Библиотека", output);
            Assert.Contains("Книг: 1000", output);
        }

        [Fact]
        public void Organization_Clone_CreatesDeepCopy()
        {
            var original = new Library("Lib", 50, 5000);
            var clone = (Library)original.Clone();

            Assert.Equal(original.Name, clone.Name);
            Assert.Equal(original.BooksCount, clone.BooksCount);

            original.Name = "Changed";
            original.BooksCount = 9999;

            Assert.NotEqual(original.Name, clone.Name);
            Assert.NotEqual(original.BooksCount, clone.BooksCount);
        }

        [Fact]
        public void Organization_CompareTo_SortsByName()
        {
            var org1 = new Organization { Name = "B" };
            var org2 = new Organization { Name = "A" };

            Assert.True(org1.CompareTo(org2) > 0);
            Assert.True(org2.CompareTo(org1) < 0);
        }

        // === Lab11: Collections ===

        [Fact]
        public void Lab11_Collection_AddAndRemove_Works()
        {
            var lab = new Lab11();
            var org = new Organization("Test", 100);

            // Добавляем (используем reflection для доступа к private полю)
            var collectionField = typeof(Lab11).GetField(
                "_collection",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
            );
            var collection = (List<Organization>)collectionField.GetValue(lab);
            collection.Add(org);

            Assert.Single(collection);

            collection.RemoveAt(0);
            Assert.Empty(collection);
        }

        [Fact]
        public void Lab11_Queries_WorkCorrectly()
        {
            var lab = new Lab11();
            var collectionField = typeof(Lab11).GetField(
                "_collection",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
            );
            var collection = (List<Organization>)collectionField.GetValue(lab);

            collection.Add(new Factory("Factory1", 100, "Cars"));
            collection.Add(new Factory("Factory2", 200, "Food"));
            collection.Add(new Library("Lib", 50, 10000));

            // Вызываем private метод ExecuteQueries через reflection
            var method = typeof(Lab11).GetMethod(
                "ExecuteQueries",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
            );
            var output = CaptureOutput(() => method.Invoke(lab, null));

            Assert.Contains("Количество заводов в коллекции: 2", output);
            Assert.Contains("Самое длинное название:", output); // может быть Factory1 или Factory2
            Assert.Contains("Суммарно сотрудников на верфях: 0", output); // т.к. нет ShipbuildingCompany
        }

        [Fact]
        public void Lab11_Cloning_CreatesIndependentCopy()
        {
            var lab = new Lab11();
            var collectionField = typeof(Lab11).GetField(
                "_collection",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
            );
            var collection = (List<Organization>)collectionField.GetValue(lab);

            var org = new Library("Lib", 10, 5000);
            collection.Add(org);

            var cloned = new List<Organization>();
            foreach (var item in collection)
                cloned.Add((Organization)item.Clone());

            org.Name = "Changed";

            Assert.NotEqual(collection[0].Name, cloned[0].Name);
        }

        // Вспомогательный метод для захвата Console.Output
        private string CaptureOutput(Action action)
        {
            var oldOut = Console.Out;
            using var newOut = new System.IO.StringWriter();
            Console.SetOut(newOut);
            action();
            Console.SetOut(oldOut);
            return newOut.ToString();
        }
    }
}
