using System;
using static Labs.LabFunc;

namespace Labs.Labs.Lab10
{
    /// <summary>
    /// Базовый класс, представляющий организацию.
    /// Реализует основные интерфейсы для работы в лабораторной работе:
    /// <list type="bullet">
    ///     <item><see cref="IInit"/>: для ручной и случайной инициализации.</item>
    ///     <item><see cref="IComparable{T}"/>: для сравнения (сортировки) по имени.</item>
    ///     <item><see cref="ICloneable"/>: для глубокого и поверхностного копирования.</item>
    /// </list>
    /// </summary>
    public class Organization : IInit, IComparable<Organization>, ICloneable
    {
        protected string name;
        protected int employeeCount;

        /// <summary>
        /// Получает или устанавливает название организации.
        /// </summary>
        /// <exception cref="ArgumentException">Возникает, если значение пустое или null.</exception>
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название не может быть пустым.");
                name = value;
            }
        }

        /// <summary>
        /// Получает или устанавливает количество сотрудников организации.
        /// </summary>
        /// <exception cref="ArgumentException">Возникает, если значение меньше или равно нулю.</exception>
        public int EmployeeCount
        {
            get => employeeCount;
            set
            {
                if (value <= 0)
                    throw new ArgumentException(
                        "Количество сотрудников должно быть положительным."
                    );
                employeeCount = value;
            }
        }

        /// <summary>
        /// Получает строковое представление типа организации (для полиморфизма).
        /// </summary>
        public virtual string OrganizationType => "Организация";

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Organization"/> со значениями по умолчанию.
        /// </summary>
        public Organization()
        {
            Name = "Неизвестная организация";
            EmployeeCount = 1;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Organization"/> с заданными параметрами.
        /// </summary>
        /// <param name="name">Название организации.</param>
        /// <param name="employeeCount">Количество сотрудников.</param>
        public Organization(string name, int employeeCount)
        {
            Name = name;
            EmployeeCount = employeeCount;
        }

        /// <summary>
        /// Конструктор копирования. Инициализирует новый экземпляр класса <see cref="Organization"/>
        /// на основе данных из существующего объекта.
        /// </summary>
        /// <param name="other">Существующий объект <see cref="Organization"/> для копирования.</param>
        public Organization(Organization other)
        {
            Name = other.Name;
            EmployeeCount = other.EmployeeCount;
        }

        /// <summary>
        /// Виртуальный метод для вывода информации об организации.
        /// Демонстрирует полиморфизм.
        /// </summary>
        public virtual void Show()
        {
            Console.WriteLine($"Организация: {Name}, Сотрудников: {EmployeeCount}");
        }

        /// <summary>
        /// Невиртуальный метод для вывода информации об организации.
        /// Используется для демонстрации разницы между виртуальными и невиртуальными методами
        /// при вызове через переменную базового типа (отсутствие полиморфизма).
        /// </summary>
        public void Display()
        {
            Console.WriteLine($"Организация (невиртуальный): {Name}, Сотрудников: {EmployeeCount}");
        }

        /// <summary>
        /// Виртуальный метод для случайной инициализации полей организации.
        /// Используется для генерации случайных данных.
        /// </summary>
        /// <param name="rnd">Экземпляр генератора случайных чисел.</param>
        public virtual void RandomInit(Random rnd)
        {
            Name = GenerateRandomString();
            EmployeeCount = rnd.Next(10, 1000);
        }

        /// <summary>
        /// Сравнивает текущий объект с другим объектом <see cref="Organization"/>.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns><see langword="true"/>, если объекты равны; иначе <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is not Organization other)
                return false;
            return Name == other.Name && EmployeeCount == other.EmployeeCount;
        }

        /// <summary>
        /// Выполняет ручную инициализацию полей организации путем запроса ввода у пользователя.
        /// </summary>
        public virtual void Init()
        {
            Console.WriteLine("\nВвод данных организации:");
            Name = ReadString("Введите название: ");
            EmployeeCount = ReadPositiveInt("Введите количество сотрудников: ");
        }

        /// <summary>
        /// Метод интерфейса <see cref="IInit"/> для случайной инициализации.
        /// Использует статический генератор случайных чисел.
        /// </summary>
        public void RandomInit()
        {
            RandomInit(Rnd);
        }

        /// <summary>
        /// Сравнивает текущий объект с другим объектом <see cref="Organization"/> по названию.
        /// Используется для сортировки (интерфейс <see cref="IComparable{T}"/>).
        /// </summary>
        /// <param name="other">Объект <see cref="Organization"/> для сравнения.</param>
        /// <returns>Целое число, указывающее относительный порядок сравниваемых объектов.</returns>
        public int CompareTo(Organization other)
        {
            if (other == null)
                return 1;
            return string.Compare(this.Name, other.Name, StringComparison.Ordinal);
        }

        /// <summary>
        /// Создает глубокую копию текущего объекта <see cref="Organization"/>.
        /// </summary>
        /// <returns>Новый объект, который является глубокой копией текущего экземпляра.</returns>
        public virtual object Clone()
        {
            return new Organization(this);
        }

        /// <summary>
        /// Создает поверхностную копию текущего объекта <see cref="Organization"/>,
        /// используя <see cref="object.MemberwiseClone"/>.
        /// </summary>
        /// <returns>Новый объект, который является поверхностной копией текущего экземпляра.</returns>
        public Organization ShallowCopy()
        {
            return (Organization)this.MemberwiseClone();
        }

        /// <summary>
        /// Вычисляет хэш-код для текущего экземпляра.
        /// </summary>
        /// <returns>Хэш-код для текущего объекта.</returns>
        public override int GetHashCode() => HashCode.Combine(Name, EmployeeCount);
    }

    /// <summary>
    /// Представляет страховую компанию, наследуется от <see cref="Organization"/>.
    /// </summary>
    public class InsuranceCompany : Organization
    {
        protected int clientCount;

        /// <summary>
        /// Получает или устанавливает количество клиентов страховой компании.
        /// </summary>
        /// <exception cref="ArgumentException">Возникает, если значение отрицательное.</exception>
        public int ClientCount
        {
            get => clientCount;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Количество клиентов не может быть отрицательным.");
                clientCount = value;
            }
        }

        /// <summary>
        /// Получает строковое представление типа организации.
        /// </summary>
        public override string OrganizationType => "Страховая компания";

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InsuranceCompany"/> со значениями по умолчанию.
        /// </summary>
        public InsuranceCompany()
            : base()
        {
            ClientCount = 0;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InsuranceCompany"/> с заданными параметрами.
        /// </summary>
        /// <param name="name">Название компании.</param>
        /// <param name="employeeCount">Количество сотрудников.</param>
        /// <param name="clientCount">Количество клиентов.</param>
        public InsuranceCompany(string name, int employeeCount, int clientCount)
            : base(name, employeeCount)
        {
            ClientCount = clientCount;
        }

        /// <summary>
        /// Конструктор копирования.
        /// </summary>
        /// <param name="other">Существующий объект <see cref="InsuranceCompany"/> для копирования.</param>
        public InsuranceCompany(InsuranceCompany other)
            : base(other)
        {
            ClientCount = other.ClientCount;
        }

        /// <summary>
        /// Выводит полную информацию о страховой компании.
        /// Переопределяет <see cref="Organization.Show"/>.
        /// </summary>
        public override void Show()
        {
            Console.WriteLine(
                $"Страховая компания: {Name}, Сотрудников: {EmployeeCount}, Клиентов: {ClientCount}"
            );
        }

        /// <summary>
        /// Выполняет ручную инициализацию, включая количество клиентов.
        /// Переопределяет <see cref="Organization.Init"/>.
        /// </summary>
        public override void Init()
        {
            base.Init();
            ClientCount = ReadPositiveInt("Введите количество клиентов: ");
        }

        /// <summary>
        /// Создает глубокую копию текущего объекта <see cref="InsuranceCompany"/>.
        /// Переопределяет <see cref="Organization.Clone"/>.
        /// </summary>
        /// <returns>Новый объект, который является глубокой копией текущего экземпляра.</returns>
        public override object Clone()
        {
            return new InsuranceCompany(this);
        }

        /// <summary>
        /// Выполняет случайную инициализацию, включая количество клиентов.
        /// Переопределяет <see cref="Organization.RandomInit(Random)"/>.
        /// </summary>
        /// <param name="rnd">Экземпляр генератора случайных чисел.</param>
        public override void RandomInit(Random rnd)
        {
            base.RandomInit(rnd);
            Name = $"{GenerateRandomString()} Страхование";
            ClientCount = rnd.Next(1000, 10000);
        }

        /// <summary>
        /// Сравнивает текущий объект с другим объектом <see cref="InsuranceCompany"/>.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns><see langword="true"/>, если объекты равны; иначе <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj) && obj is InsuranceCompany ic && ClientCount == ic.ClientCount;
        }

        /// <summary>
        /// Вычисляет хэш-код для текущего экземпляра.
        /// </summary>
        /// <returns>Хэш-код для текущего объекта.</returns>
        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), ClientCount);
    }

    /// <summary>
    /// Представляет судостроительную компанию, наследуется от <see cref="Organization"/>.
    /// </summary>
    public class ShipbuildingCompany : Organization
    {
        protected int shipsBuilt;

        /// <summary>
        /// Получает или устанавливает количество построенных кораблей.
        /// </summary>
        /// <exception cref="ArgumentException">Возникает, если значение отрицательное.</exception>
        public int ShipsBuilt
        {
            get => shipsBuilt;
            set
            {
                if (value < 0)
                    throw new ArgumentException(
                        "Количество построенных кораблей не может быть отрицательным."
                    );
                shipsBuilt = value;
            }
        }

        /// <summary>
        /// Получает строковое представление типа организации.
        /// </summary>
        public override string OrganizationType => "Судостроительная компания";

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ShipbuildingCompany"/> со значениями по умолчанию.
        /// </summary>
        public ShipbuildingCompany()
            : base()
        {
            ShipsBuilt = 0;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ShipbuildingCompany"/> с заданными параметрами.
        /// </summary>
        /// <param name="name">Название компании.</param>
        /// <param name="employeeCount">Количество сотрудников.</param>
        /// <param name="shipsBuilt">Количество построенных кораблей.</param>
        public ShipbuildingCompany(string name, int employeeCount, int shipsBuilt)
            : base(name, employeeCount)
        {
            ShipsBuilt = shipsBuilt;
        }

        /// <summary>
        /// Конструктор копирования.
        /// </summary>
        /// <param name="other">Существующий объект <see cref="ShipbuildingCompany"/> для копирования.</param>
        public ShipbuildingCompany(ShipbuildingCompany other)
            : base(other)
        {
            ShipsBuilt = other.ShipsBuilt;
        }

        /// <summary>
        /// Выводит полную информацию о судостроительной компании.
        /// Переопределяет <see cref="Organization.Show"/>.
        /// </summary>
        public override void Show()
        {
            Console.WriteLine(
                $"Судостроительная компания: {Name}, Сотрудников: {EmployeeCount}, Построено кораблей: {ShipsBuilt}"
            );
        }

        /// <summary>
        /// Выполняет ручную инициализацию, включая количество построенных кораблей.
        /// Переопределяет <see cref="Organization.Init"/>.
        /// </summary>
        public override void Init()
        {
            base.Init();
            ShipsBuilt = ReadPositiveInt("Введите количество построенных кораблей: ");
        }

        /// <summary>
        /// Создает глубокую копию текущего объекта <see cref="ShipbuildingCompany"/>.
        /// Переопределяет <see cref="Organization.Clone"/>.
        /// </summary>
        /// <returns>Новый объект, который является глубокой копией текущего экземпляра.</returns>
        public override object Clone()
        {
            return new ShipbuildingCompany(this);
        }

        /// <summary>
        /// Выполняет случайную инициализацию, включая количество построенных кораблей.
        /// Переопределяет <see cref="Organization.RandomInit(Random)"/>.
        /// </summary>
        /// <param name="rnd">Экземпляр генератора случайных чисел.</param>
        public override void RandomInit(Random rnd)
        {
            base.RandomInit(rnd);
            Name = $"{GenerateRandomString()} Верфь";
            ShipsBuilt = rnd.Next(5, 150);
        }

        /// <summary>
        /// Сравнивает текущий объект с другим объектом <see cref="ShipbuildingCompany"/>.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns><see langword="true"/>, если объекты равны; иначе <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj) && obj is ShipbuildingCompany sc && ShipsBuilt == sc.ShipsBuilt;
        }

        /// <summary>
        /// Вычисляет хэш-код для текущего экземпляра.
        /// </summary>
        /// <returns>Хэш-код для текущего объекта.</returns>
        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), ShipsBuilt);
    }

    /// <summary>
    /// Представляет завод, наследуется от <see cref="Organization"/>.
    /// </summary>
    public class Factory : Organization
    {
        protected string productType;

        /// <summary>
        /// Получает или устанавливает тип продукции, производимой заводом.
        /// </summary>
        /// <exception cref="ArgumentException">Возникает, если значение пустое или null.</exception>
        public string ProductType
        {
            get => productType;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Тип продукции не может быть пустым.");
                productType = value;
            }
        }

        /// <summary>
        /// Получает строковое представление типа организации.
        /// </summary>
        public override string OrganizationType => "Завод";

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Factory"/> со значениями по умолчанию.
        /// </summary>
        public Factory()
            : base()
        {
            ProductType = "Неизвестно";
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Factory"/> с заданными параметрами.
        /// </summary>
        /// <param name="name">Название завода.</param>
        /// <param name="employeeCount">Количество сотрудников.</param>
        /// <param name="productType">Тип производимой продукции.</param>
        public Factory(string name, int employeeCount, string productType)
            : base(name, employeeCount)
        {
            ProductType = productType;
        }

        /// <summary>
        /// Конструктор копирования.
        /// </summary>
        /// <param name="other">Существующий объект <see cref="Factory"/> для копирования.</param>
        public Factory(Factory other)
            : base(other)
        {
            ProductType = other.ProductType;
        }

        /// <summary>
        /// Выводит полную информацию о заводе.
        /// Переопределяет <see cref="Organization.Show"/>.
        /// </summary>
        public override void Show()
        {
            Console.WriteLine(
                $"Завод: {Name}, Сотрудников: {EmployeeCount}, Тип продукции: {ProductType}"
            );
        }

        /// <summary>
        /// Выполняет ручную инициализацию, включая тип продукции.
        /// Переопределяет <see cref="Organization.Init"/>.
        /// </summary>
        public override void Init()
        {
            base.Init();
            ProductType = ReadString("Введите тип продукции: ");
        }

        /// <summary>
        /// Создает глубокую копию текущего объекта <see cref="Factory"/>.
        /// Переопределяет <see cref="Organization.Clone"/>.
        /// </summary>
        /// <returns>Новый объект, который является глубокой копией текущего экземпляра.</returns>
        public override object Clone()
        {
            return new Factory(this);
        }

        /// <summary>
        /// Выполняет случайную инициализацию, включая тип продукции.
        /// Переопределяет <see cref="Organization.RandomInit(Random)"/>.
        /// </summary>
        /// <param name="rnd">Экземпляр генератора случайных чисел.</param>
        public override void RandomInit(Random rnd)
        {
            base.RandomInit(rnd);
            Name = $"{GenerateRandomString()} Завод";
            string[] types =
            {
                "Автомобили",
                "Электроника",
                "Продукты питания",
                "Одежда",
                "Мебель",
            };
            ProductType = types[rnd.Next(types.Length)];
        }

        /// <summary>
        /// Сравнивает текущий объект с другим объектом <see cref="Factory"/>.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns><see langword="true"/>, если объекты равны; иначе <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj) && obj is Factory f && ProductType == f.ProductType;
        }

        /// <summary>
        /// Вычисляет хэш-код для текущего экземпляра.
        /// </summary>
        /// <returns>Хэш-код для текущего объекта.</returns>
        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), ProductType);
    }

    /// <summary>
    /// Представляет библиотеку, наследуется от <see cref="Organization"/>.
    /// </summary>
    public class Library : Organization
    {
        protected int booksCount;

        /// <summary>
        /// Получает или устанавливает количество книг в библиотеке.
        /// </summary>
        /// <exception cref="ArgumentException">Возникает, если значение отрицательное.</exception>
        public int BooksCount
        {
            get => booksCount;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Количество книг не может быть отрицательным.");
                booksCount = value;
            }
        }

        /// <summary>
        /// Получает строковое представление типа организации.
        /// </summary>
        public override string OrganizationType => "Библиотека";

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Library"/> со значениями по умолчанию.
        /// </summary>
        public Library()
            : base()
        {
            BooksCount = 0;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Library"/> с заданными параметрами.
        /// </summary>
        /// <param name="name">Название библиотеки.</param>
        /// <param name="employeeCount">Количество сотрудников.</param>
        /// <param name="booksCount">Количество книг.</param>
        public Library(string name, int employeeCount, int booksCount)
            : base(name, employeeCount)
        {
            BooksCount = booksCount;
        }

        /// <summary>
        /// Конструктор копирования.
        /// </summary>
        /// <param name="other">Существующий объект <see cref="Library"/> для копирования.</param>
        public Library(Library other)
            : base(other)
        {
            BooksCount = other.BooksCount;
        }

        /// <summary>
        /// Выводит полную информацию о библиотеке.
        /// Переопределяет <see cref="Organization.Show"/>.
        /// </summary>
        public override void Show()
        {
            Console.WriteLine(
                $"Библиотека: {Name}, Сотрудников: {EmployeeCount}, Книг: {BooksCount}"
            );
        }

        /// <summary>
        /// Выполняет ручную инициализацию, включая количество книг.
        /// Переопределяет <see cref="Organization.Init"/>.
        /// </summary>
        public override void Init()
        {
            base.Init();
            BooksCount = ReadPositiveInt("Введите количество книг: ");
        }

        /// <summary>
        /// Создает глубокую копию текущего объекта <see cref="Library"/>.
        /// Переопределяет <see cref="Organization.Clone"/>.
        /// </summary>
        /// <returns>Новый объект, который является глубокой копией текущего экземпляра.</returns>
        public override object Clone()
        {
            return new Library(this);
        }

        /// <summary>
        /// Выполняет случайную инициализацию, включая количество книг.
        /// Переопределяет <see cref="Organization.RandomInit(Random)"/>.
        /// </summary>
        /// <param name="rnd">Экземпляр генератора случайных чисел.</param>
        public override void RandomInit(Random rnd)
        {
            base.RandomInit(rnd);
            Name = $"{GenerateRandomString()} Библиотека";
            BooksCount = rnd.Next(5000, 200000);
        }

        /// <summary>
        /// Сравнивает текущий объект с другим объектом <see cref="Library"/>.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns><see langword="true"/>, если объекты равны; иначе <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj) && obj is Library l && BooksCount == l.BooksCount;
        }

        /// <summary>
        /// Вычисляет хэш-код для текущего экземпляра.
        /// </summary>
        /// <returns>Хэш-код для текущего объекта.</returns>
        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), BooksCount);
    }
}
