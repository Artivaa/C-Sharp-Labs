using System;
using static Labs.LabFunc;

namespace Labs.Labs.Lab10
{
    public class User : IInit
    {
        public string Login { get; set; }
        public int ID { get; set; }

        public void Init()
        {
            Console.WriteLine("\nВвод данных Пользователя:");
            Login = ReadString("Введите логин: ");
            ID = ReadPositiveInt("Введите ID: ");
        }

        public void RandomInit()
        {
            Login = "User" + Rnd.Next(1000);
            ID = Rnd.Next(1, 10000);
        }

        public override string ToString()
        {
            return $"User: {Login}, ID: {ID}";
        }
    }
}
