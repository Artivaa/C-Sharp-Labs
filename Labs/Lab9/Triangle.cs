using System;

namespace Labs.Labs.Lab9
{
    /// <summary>
    /// Представляет объект "Треугольник", определяемый тремя положительными сторонами (A, B, C).
    /// Класс включает проверку на неравенство треугольника и методы для вычисления площади.
    /// Реализованы перегруженные операторы для сравнения, инкремента/декремента и приведения типов.
    /// </summary>
    public class Triangle
    {
        private double a;
        private double b;
        private double c;

        private static int count = 0;

        /// <summary>
        /// Получает или устанавливает длину стороны A.
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если значение не положительно.</exception>
        public double A
        {
            get => a;
            set =>
                a =
                    value > 0
                        ? value
                        : throw new ArgumentException("Сторона должна быть положительной");
        }

        /// <summary>
        /// Получает или устанавливает длину стороны B.
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если значение не положительно.</exception>
        public double B
        {
            get => b;
            set =>
                b =
                    value > 0
                        ? value
                        : throw new ArgumentException("Сторона должна быть положительной");
        }

        /// <summary>
        /// Получает или устанавливает длину стороны C.
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если значение не положительно.</exception>
        public double C
        {
            get => c;
            set =>
                c =
                    value > 0
                        ? value
                        : throw new ArgumentException("Сторона должна быть положительной");
        }

        /// <summary>
        /// Получает общее количество созданных экземпляров класса <see cref="Triangle"/>.
        /// </summary>
        public static int Count => count;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Triangle"/> с заданными длинами сторон.
        /// </summary>
        /// <param name="sideA">Длина стороны A.</param>
        /// <param name="sideB">Длина стороны B.</param>
        /// <param name="sideC">Длина стороны C.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если стороны неположительны или нарушают неравенство треугольника.</exception>
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                throw new ArgumentException("Все стороны должны быть положительными");
            if (!IsValidTriangle(sideA, sideB, sideC))
                throw new ArgumentException("Нарушено неравенство треугольника");

            a = sideA;
            b = sideB;
            c = sideC;
            count++;
        }

        /// <summary>
        /// Конструктор копирования. Инициализирует новый экземпляр класса <see cref="Triangle"/>,
        /// копируя значения сторон из другого треугольника.
        /// </summary>
        /// <param name="other">Объект <see cref="Triangle"/> для копирования.</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, если <paramref name="other"/> равен null.</exception>
        public Triangle(Triangle other)
        {
            ArgumentNullException.ThrowIfNull(other);

            a = other.a;
            b = other.b;
            c = other.c;
            count++;
        }

        /// <summary>
        /// Проверяет, могут ли три заданные длины сторон образовывать треугольник (согласно неравенству треугольника).
        /// </summary>
        /// <param name="x">Длина первой стороны.</param>
        /// <param name="y">Длина второй стороны.</param>
        /// <param name="z">Длина третьей стороны.</param>
        /// <returns><see langword="true"/>, если стороны образуют валидный треугольник; иначе <see langword="false"/>.</returns>
        private static bool IsValidTriangle(double x, double y, double z)
        {
            return x + y > z && x + z > y && y + z > x;
        }

        /// <summary>
        /// Проверяет, является ли текущий экземпляр валидным треугольником.
        /// </summary>
        /// <returns><see langword="true"/>, если треугольник валиден; иначе <see langword="false"/>.</returns>
        public bool IsValid() => IsValidTriangle(a, b, c);

        /// <summary>
        /// Вычисляет площадь треугольника по формуле Герона.
        /// </summary>
        /// <returns>Площадь треугольника.</returns>
        private double CalculateArea()
        {
            // Полупериметр
            double s = (a + b + c) / 2.0;
            // Формула Герона
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        /// <summary>
        /// Выводит длины сторон треугольника в консоль.
        /// </summary>
        public void PrintSides()
        {
            Console.WriteLine($"Стороны: a = {a:F2}, b = {b:F2}, c = {c:F2}");
        }

        /// <summary>
        /// Возвращает площадь треугольника.
        /// </summary>
        /// <returns>Площадь треугольника.</returns>
        /// <exception cref="InvalidOperationException">Выбрасывается, если треугольник невалиден.</exception>
        public double GetArea()
        {
            if (!IsValid())
                throw new InvalidOperationException(
                    "Невозможно вычислить площадь невалидного треугольника"
                );
            return CalculateArea();
        }

        /// <summary>
        /// Статический метод для вычисления площади треугольника по заданным сторонам.
        /// </summary>
        /// <param name="sideA">Длина стороны A.</param>
        /// <param name="sideB">Длина стороны B.</param>
        /// <param name="sideC">Длина стороны C.</param>
        /// <returns>Площадь треугольника, или 0, если треугольник невалиден.</returns>
        public static double CalculateArea(double sideA, double sideB, double sideC)
        {
            if (!IsValidTriangle(sideA, sideB, sideC))
                return 0;
            double s = (sideA + sideB + sideC) / 2.0;
            return Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
        }

        /// <summary>
        /// Перегруженный оператор инкремента. Создает новый треугольник,
        /// увеличивая длину каждой стороны на 1.
        /// </summary>
        /// <param name="t">Исходный треугольник.</param>
        /// <returns>Новый треугольник с увеличенными сторонами.</returns>
        public static Triangle operator ++(Triangle t)
        {
            return new Triangle(t.a + 1, t.b + 1, t.c + 1);
        }

        /// <summary>
        /// Перегруженный оператор декремента. Создает новый треугольник,
        /// уменьшая длину каждой стороны на 1.
        /// </summary>
        /// <param name="t">Исходный треугольник.</param>
        /// <returns>Новый треугольник с уменьшенными сторонами.</returns>
        /// <exception cref="InvalidOperationException">Выбрасывается, если уменьшение сторон приведет к невалидному треугольнику.</exception>
        public static Triangle operator --(Triangle t)
        {
            if (!IsValidTriangle(t.a - 1, t.b - 1, t.c - 1))
                throw new InvalidOperationException(
                    "Нельзя уменьшить стороны: треугольник станет невалидным"
                );

            return new Triangle(t.a - 1, t.b - 1, t.c - 1);
        }

        /// <summary>
        /// Явное приведение типа <see cref="Triangle"/> к типу <see cref="double"/>.
        /// Возвращает площадь треугольника, или -1, если треугольник невалиден.
        /// </summary>
        /// <param name="t">Треугольник для приведения.</param>
        public static explicit operator double(Triangle t)
        {
            return t.IsValid() ? t.CalculateArea() : -1;
        }

        /// <summary>
        /// Неявное приведение типа <see cref="Triangle"/> к типу <see cref="bool"/>.
        /// Возвращает <see langword="true"/>, если треугольник валиден, иначе <see langword="false"/>.
        /// </summary>
        /// <param name="t">Треугольник для приведения.</param>
        public static implicit operator bool(Triangle t)
        {
            return t.IsValid();
        }

        /// <summary>
        /// Перегруженный оператор "меньше или равно" (<=). Сравнивает треугольники по площади.
        /// </summary>
        /// <param name="t1">Первый треугольник.</param>
        /// <param name="t2">Второй треугольник.</param>
        /// <returns><see langword="true"/>, если площадь первого треугольника меньше или равна площади второго.</returns>
        public static bool operator <=(Triangle t1, Triangle t2)
        {
            return t1.GetArea() <= t2.GetArea();
        }

        /// <summary>
        /// Перегруженный оператор "больше или равно" (>=). Сравнивает треугольники по площади.
        /// </summary>
        /// <param name="t1">Первый треугольник.</param>
        /// <param name="t2">Второй треугольник.</param>
        /// <returns><see langword="true"/>, если площадь первого треугольника больше или равна площади второго.</returns>
        public static bool operator >=(Triangle t1, Triangle t2)
        {
            return t1.GetArea() >= t2.GetArea();
        }

        /// <summary>
        /// Перегруженный оператор "меньше" (&lt;). Сравнивает треугольники по площади.
        /// </summary>
        /// <param name="t1">Первый треугольник.</param>
        /// <param name="t2">Второй треугольник.</param>
        /// <returns><see langword="true"/>, если площадь первого треугольника строго меньше площади второго.</returns>
        public static bool operator <(Triangle t1, Triangle t2)
        {
            return t1.GetArea() < t2.GetArea();
        }

        /// <summary>
        /// Перегруженный оператор "больше" (&gt;). Сравнивает треугольники по площади.
        /// </summary>
        /// <param name="t1">Первый треугольник.</param>
        /// <param name="t2">Второй треугольник.</param>
        /// <returns><see langword="true"/>, если площадь первого треугольника строго больше площади второго.</returns>
        public static bool operator >(Triangle t1, Triangle t2)
        {
            return t1.GetArea() > t2.GetArea();
        }

        /// <summary>
        /// Перегруженный оператор равенства (==). Сравнивает треугольники по длинам сторон с малой погрешностью (0.001).
        /// </summary>
        /// <param name="t1">Первый треугольник.</param>
        /// <param name="t2">Второй треугольник.</param>
        /// <returns><see langword="true"/>, если длины сторон совпадают; иначе <see langword="false"/>.</returns>
        public static bool operator ==(Triangle t1, Triangle t2)
        {
            if (ReferenceEquals(t1, t2))
                return true;
            if (t1 is null || t2 is null)
                return false;

            return Math.Abs(t1.a - t2.a) < 0.001
                && Math.Abs(t1.b - t2.b) < 0.001
                && Math.Abs(t1.c - t2.c) < 0.001;
        }

        /// <summary>
        /// Перегруженный оператор неравенства (!=).
        /// </summary>
        /// <param name="t1">Первый треугольник.</param>
        /// <param name="t2">Второй треугольник.</param>
        /// <returns><see langword="true"/>, если треугольники не равны; иначе <see langword="false"/>.</returns>
        public static bool operator !=(Triangle t1, Triangle t2) => !(t1 == t2);

        /// <summary>
        /// Переопределяет метод <see cref="object.Equals(object?)"/> для сравнения с другим объектом.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns><see langword="true"/>, если объект является <see cref="Triangle"/> и равен текущему экземпляру; иначе <see langword="false"/>.</returns>
        public override bool Equals(object obj) => obj is Triangle other && this == other;

        /// <summary>
        /// Переопределяет метод <see cref="object.GetHashCode()"/> для вычисления хэш-кода объекта.
        /// </summary>
        /// <returns>Хэш-код текущего экземпляра.</returns>
        public override int GetHashCode() => HashCode.Combine(a, b, c);
    }
}
