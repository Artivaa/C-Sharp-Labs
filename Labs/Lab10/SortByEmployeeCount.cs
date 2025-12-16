using System.Collections.Generic;

namespace Labs.Labs.Lab10
{
    /// <summary>
    /// Предоставляет механизм сравнения для сортировки объектов <see cref="Organization"/>
    /// на основе их свойства <see cref="Organization.EmployeeCount"/> (количества сотрудников).
    /// Реализует интерфейс <see cref="IComparer{T}"/>.
    /// </summary>
    public class SortByEmployeeCount : IComparer<Organization>
    {
        /// <summary>
        /// Сравнивает два объекта <see cref="Organization"/> и возвращает значение,
        /// указывающее, какой из них меньше, больше или равен другому по количеству сотрудников.
        /// </summary>
        /// <param name="x">Первый объект <see cref="Organization"/> для сравнения.</param>
        /// <param name="y">Второй объект <see cref="Organization"/> для сравнения.</param>
        /// <returns>
        /// Целое число со знаком, которое указывает относительное отношение объектов:
        /// <list type="bullet">
        ///     <item>Меньше нуля: <paramref name="x"/> имеет меньше сотрудников, чем <paramref name="y"/>.</item>
        ///     <item>Ноль: <paramref name="x"/> и <paramref name="y"/> имеют одинаковое количество сотрудников.</item>
        ///     <item>Больше нуля: <paramref name="x"/> имеет больше сотрудников, чем <paramref name="y"/>.</item>
        /// </list>
        /// </returns>
        public int Compare(Organization x, Organization y)
        {
            if (x == null || y == null)
                // Согласно контракту IComparer, если один из объектов null,
                // можно вернуть 0, если это допустимо для конкретного случая,
                // или бросить исключение/вернуть 1/-1 для определения порядка.
                // В данном случае возвращаем 0, предполагая, что порядок не важен при null.
                return 0;
            if (x.EmployeeCount > y.EmployeeCount)
                return 1;
            if (x.EmployeeCount < y.EmployeeCount)
                return -1;
            return 0;
        }
    }
}
