using System;
using static Labs.LabFunc;

namespace Labs.Labs.Lab10
{
    public class Organization
    {
        protected string name;
        protected int employeeCount;

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
        public virtual string OrganizationType => "Организация";

        public Organization()
        {
            Name = "Неизвестная организация";
            EmployeeCount = 1;
        }

        public Organization(string name, int employeeCount)
        {
            Name = name;
            EmployeeCount = employeeCount;
        }

        public Organization(Organization other)
        {
            Name = other.Name;
            EmployeeCount = other.EmployeeCount;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Организация: {Name}, Сотрудников: {EmployeeCount}");
        }

        // Невиртуальный метод для демонстрации разницы
        public void Display()
        {
            Console.WriteLine($"Организация (невиртуальный): {Name}, Сотрудников: {EmployeeCount}");
        }

        public virtual void RandomInit(Random rnd)
        {
            Name = GenerateRandomString();
            EmployeeCount = rnd.Next(10, 1000);
        }

        public override bool Equals(object obj)
        {
            if (obj is not Organization other)
                return false;
            return Name == other.Name && EmployeeCount == other.EmployeeCount;
        }

        public override int GetHashCode() => HashCode.Combine(Name, EmployeeCount);
    }

    public class InsuranceCompany : Organization
    {
        protected int clientCount;

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

        public override string OrganizationType => "Страховая компания";

        public InsuranceCompany()
            : base()
        {
            ClientCount = 0;
        }

        public InsuranceCompany(string name, int employeeCount, int clientCount)
            : base(name, employeeCount)
        {
            ClientCount = clientCount;
        }

        public InsuranceCompany(InsuranceCompany other)
            : base(other)
        {
            ClientCount = other.ClientCount;
        }

        public override void Show()
        {
            Console.WriteLine(
                $"Страховая компания: {Name}, Сотрудников: {EmployeeCount}, Клиентов: {ClientCount}"
            );
        }

        public override void RandomInit(Random rnd)
        {
            base.RandomInit(rnd);
            Name += " Страхование";
            ClientCount = rnd.Next(1000, 10000);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj) && obj is InsuranceCompany ic && ClientCount == ic.ClientCount;
        }

        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), ClientCount);
    }

    public class ShipbuildingCompany : Organization
    {
        protected int shipsBuilt;

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
        public override string OrganizationType => "Судостроительная компания";

        public ShipbuildingCompany()
            : base()
        {
            ShipsBuilt = 0;
        }

        public ShipbuildingCompany(string name, int employeeCount, int shipsBuilt)
            : base(name, employeeCount)
        {
            ShipsBuilt = shipsBuilt;
        }

        public ShipbuildingCompany(ShipbuildingCompany other)
            : base(other)
        {
            ShipsBuilt = other.ShipsBuilt;
        }

        public override void Show()
        {
            Console.WriteLine(
                $"Судостроительная компания: {Name}, Сотрудников: {EmployeeCount}, Построено кораблей: {ShipsBuilt}"
            );
        }

        public override void RandomInit(Random rnd)
        {
            base.RandomInit(rnd);
            Name += " Верфь";
            ShipsBuilt = rnd.Next(5, 150);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj) && obj is ShipbuildingCompany sc && ShipsBuilt == sc.ShipsBuilt;
        }

        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), ShipsBuilt);
    }

    public class Factory : Organization
    {
        protected string productType;

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
        public override string OrganizationType => "Завод";

        public Factory()
            : base()
        {
            ProductType = "Неизвестно";
        }

        public Factory(string name, int employeeCount, string productType)
            : base(name, employeeCount)
        {
            ProductType = productType;
        }

        public Factory(Factory other)
            : base(other)
        {
            ProductType = other.ProductType;
        }

        public override void Show()
        {
            Console.WriteLine(
                $"Завод: {Name}, Сотрудников: {EmployeeCount}, Тип продукции: {ProductType}"
            );
        }

        public override void RandomInit(Random rnd)
        {
            base.RandomInit(rnd);
            Name += " Завод";
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

        public override bool Equals(object obj)
        {
            return base.Equals(obj) && obj is Factory f && ProductType == f.ProductType;
        }

        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), ProductType);
    }

    public class Library : Organization
    {
        protected int booksCount;

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
        public override string OrganizationType => "Библиотека";

        public Library()
            : base()
        {
            BooksCount = 0;
        }

        public Library(string name, int employeeCount, int booksCount)
            : base(name, employeeCount)
        {
            BooksCount = booksCount;
        }

        public Library(Library other)
            : base(other)
        {
            BooksCount = other.BooksCount;
        }

        public override void Show()
        {
            Console.WriteLine(
                $"Библиотека: {Name}, Сотрудников: {EmployeeCount}, Книг: {BooksCount}"
            );
        }

        public override void RandomInit(Random rnd)
        {
            base.RandomInit(rnd);
            Name += " Библиотека";
            BooksCount = rnd.Next(5000, 200000);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj) && obj is Library l && BooksCount == l.BooksCount;
        }

        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), BooksCount);
    }
}
