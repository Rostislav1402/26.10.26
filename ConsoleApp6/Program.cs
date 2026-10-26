/*
using System;

namespace StructuresTasks
{
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double GetDistanceTo(Point other)
        {
            return Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2));
        }

        public override string ToString()
        {
            return $"({X}; {Y})";
        }
    }

    public struct Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double GetArea()
        {
            return Width * Height;
        }

        public double GetPerimeter()
        {
            return 2 * (Width + Height);
        }
    }

    public struct Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{Title} — {Author} ({Year})");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- Задача 1: Точка на плоскости ---");
            Point p1 = new Point(2, 3);
            Point p2 = new Point(5, 7);

            Console.WriteLine($"Точка 1: {p1}");
            Console.WriteLine($"Точка 2: {p2}");
            Console.WriteLine($"Расстояние между ними: {p1.GetDistanceTo(p2):F2}");

            Console.WriteLine("\n--- Задача 2: Прямоугольник ---");
            Rectangle rect = new Rectangle(10, 5);

            Console.WriteLine($"Ширина: {rect.Width}, Высота: {rect.Height}");
            Console.WriteLine($"Площадь: {rect.GetArea()}");
            Console.WriteLine($"Периметр: {rect.GetPerimeter()}");

            Console.WriteLine("\n--- Задача 3: Книга ---");
            Book myBook = new Book("Война и мир", "Лев Толстой", 1869);

            Console.Write("Информация о книге: ");
            myBook.PrintInfo();

            Console.ReadKey();
        }
    }
}
*/
/*
using System;

namespace StructuresTasksLevel2
{
    public struct ComplexNumber
    {
        public double Real { get; set; }
        public double Imag { get; set; }

        public ComplexNumber(double real, double imag)
        {
            Real = real;
            Imag = imag;
        }

        public ComplexNumber Add(ComplexNumber other)
        {
            return new ComplexNumber(Real + other.Real, Imag + other.Imag);
        }

        public ComplexNumber Subtract(ComplexNumber other)
        {
            return new ComplexNumber(Real - other.Real, Imag - other.Imag);
        }

        public ComplexNumber Multiply(ComplexNumber other)
        {
            double newReal = Real * other.Real - Imag * other.Imag;
            double newImag = Real * other.Imag + Imag * other.Real;
            return new ComplexNumber(newReal, newImag);
        }

        public override string ToString()
        {
            return $"{Real} + {Imag}i";
        }
    }

    public struct Color
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public string ToHex()
        {
            return $"#{R:X2}{G:X2}{B:X2}";
        }
    }

    public struct SimpleDate
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public SimpleDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public bool IsLeapYear()
        {
            return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- Задача 4: Комплексное число ---");
            ComplexNumber c1 = new ComplexNumber(3, 2);
            ComplexNumber c2 = new ComplexNumber(1, 4);

            Console.WriteLine($"c1 = {c1}");
            Console.WriteLine($"c2 = {c2}");
            Console.WriteLine($"Сложение: {c1.Add(c2)}");
            Console.WriteLine($"Вычитание: {c1.Subtract(c2)}");
            Console.WriteLine($"Умножение: {c1.Multiply(c2)}");

            Console.WriteLine("\n--- Задача 5: Цвет RGB ---");
            Color color = new Color(255, 128, 0);
            Console.WriteLine($"RGB ({color.R}, {color.G}, {color.B}) в HEX: {color.ToHex()}");

            Console.WriteLine("\n--- Задача 6: Дата ---");
            SimpleDate date1 = new SimpleDate(1, 1, 2024);
            SimpleDate date2 = new SimpleDate(1, 1, 2023);
            SimpleDate date3 = new SimpleDate(1, 1, 1900);

            Console.WriteLine($"Год {date1.Year} високосный? {date1.IsLeapYear()}");
            Console.WriteLine($"Год {date2.Year} високосный? {date2.IsLeapYear()}");
            Console.WriteLine($"Год {date3.Year} високосный? {date3.IsLeapYear()}");

            Console.ReadKey();
        }
    }
}
*/
using System;

namespace StructuresTasksLevel3
{
    public struct Vector2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public Vector2D Normalize()
        {
            double length = Length();
            if (length == 0)
                return new Vector2D(0, 0);
            
            return new Vector2D(X / length, Y / length);
        }

        public double Dot(Vector2D other)
        {
            return X * other.X + Y * other.Y;
        }

        public override string ToString()
        {
            return $"({X}; {Y})";
        }
    }

    public struct Money
    {
        public int Rubles { get; set; }
        public int Kopeks { get; set; }

        public Money(int rubles, int kopeks)
        {
            Rubles = rubles;
            Kopeks = kopeks;
            Normalize();
        }

        private void Normalize()
        {
            if (Kopeks >= 100)
            {
                Rubles += Kopeks / 100;
                Kopeks %= 100;
            }
            else if (Kopeks < 0)
            {
                int borrow = (Math.Abs(Kopeks) + 99) / 100;
                Rubles -= borrow;
                Kopeks += borrow * 100;
            }
        }

        public Money Add(Money other)
        {
            return new Money(Rubles + other.Rubles, Kopeks + other.Kopeks);
        }

        public Money Subtract(Money other)
        {
            return new Money(Rubles - other.Rubles, Kopeks - other.Kopeks);
        }

        public bool IsGreaterThan(Money other)
        {
            if (Rubles != other.Rubles)
                return Rubles > other.Rubles;
            return Kopeks > other.Kopeks;
        }

        public bool IsLessThan(Money other)
        {
            if (Rubles != other.Rubles)
                return Rubles < other.Rubles;
            return Kopeks < other.Kopeks;
        }

        public override string ToString()
        {
            return $"{Rubles} руб. {Kopeks} коп.";
        }
    }

    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double GetDistanceTo(Point other)
        {
            return Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2));
        }
    }

    public struct Triangle
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }

        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
        }

        public double GetSideAB() => A.GetDistanceTo(B);
        public double GetSideBC() => B.GetDistanceTo(C);
        public double GetSideCA() => C.GetDistanceTo(A);

        public double GetPerimeter()
        {
            return GetSideAB() + GetSideBC() + GetSideCA();
        }

        public double GetArea()
        {
            double a = GetSideBC();
            double b = GetSideCA();
            double c = GetSideAB();
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }

    public struct Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double GetDistanceTo(Point3D other)
        {
            return Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2) + Math.Pow(other.Z - Z, 2));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- Задача 7: Вектор в 2D ---");
            Vector2D v1 = new Vector2D(3, 4);
            Vector2D v2 = new Vector2D(1, 2);
            Console.WriteLine($"Вектор v1: {v1}");
            Console.WriteLine($"Длина v1: {v1.Length()}");
            Console.WriteLine($"Нормализованный v1: {v1.Normalize()}");
            Console.WriteLine($"Скалярное произведение v1 и v2: {v1.Dot(v2)}");

            Console.WriteLine("\n--- Задача 8: Деньги ---");
            Money m1 = new Money(100, 50);
            Money m2 = new Money(50, 80);
            Console.WriteLine($"m1: {m1}");
            Console.WriteLine($"m2: {m2}");
            Console.WriteLine($"Сложение: {m1.Add(m2)}");
            Console.WriteLine($"Вычитание: {m1.Subtract(m2)}");
            Console.WriteLine($"m1 > m2: {m1.IsGreaterThan(m2)}");
            Console.WriteLine($"m1 < m2: {m1.IsLessThan(m2)}");

            Console.WriteLine("\n--- Задача 9: Треугольник ---");
            Triangle t = new Triangle(new Point(0, 0), new Point(3, 0), new Point(0, 4));
            Console.WriteLine($"Стороны: {t.GetSideAB()}, {t.GetSideBC()}, {t.GetSideCA()}");
            Console.WriteLine($"Периметр: {t.GetPerimeter()}");
            Console.WriteLine($"Площадь: {t.GetArea()}");

            Console.WriteLine("\n--- Задача 10: 3D-геометрия ---");
            Point3D p1 = new Point3D(0, 0, 0);
            Point3D p2 = new Point3D(3, 4, 12);
            Console.WriteLine($"Расстояние между точками: {p1.GetDistanceTo(p2)}");

            Console.ReadKey();
        }
    }
}

