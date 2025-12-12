using System;
using static Labs.LabFunc;

namespace Labs.Labs.Lab10
{
    public class Lab10 : ILab
    {
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
        }
    }
}
