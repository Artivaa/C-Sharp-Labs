using System;
using static Labs.LabFunc;

namespace Labs.Labs.Lab10
{
    /// <summary>
    /// Представляет объект "Пользователь" (User).
    /// Этот класс используется для демонстрации того, как классы, не входящие
    /// в иерархию <see cref="Organization"/>, могут реализовать интерфейс <see cref="IInit"/>.
    /// </summary>
    public class User : IInit
    {
        /// <summary>
        /// Получает или устанавливает логин пользователя.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Получает или устанавливает уникальный идентификатор пользователя.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Выполняет ручную инициализацию полей <see cref="Login"/> и <see cref="ID"/>
        /// путем запроса ввода у пользователя.
        /// </summary>
        public void Init()
        {
            Console.WriteLine("\nВвод данных Пользователя:");
            Login = ReadString("Введите логин: ");
            ID = ReadPositiveInt("Введите ID: ");
        }

        /// <summary>
        /// Выполняет случайную инициализацию полей <see cref="Login"/> и <see cref="ID"/>.
        /// Используется статический генератор случайных чисел.
        /// </summary>
        public void RandomInit()
        {
            Login = "User" + Rnd.Next(1000);
            ID = Rnd.Next(1, 10000);
        }

        /// <summary>
        /// Возвращает строковое представление текущего объекта <see cref="User"/>.
        /// </summary>
        /// <returns>Строка, содержащая <see cref="Login"/> и <see cref="ID"/> пользователя.</returns>
        public override string ToString()
        {
            return $"User: {Login}, ID: {ID}";
        }
    }
}
