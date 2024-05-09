using System;

// Інтерфейс, який успадковує інтерфейси .NET
interface IFigure : IDisposable
{
    double CalculateArea();
    double CalculatePerimeter();
    void DisplayInfo();
}

// Інтерфейс користувача
interface IUser
{
    void Login();
    void Logout();
}

// Базовий клас Person
class Person : IUser
{
    protected string firstName;
    protected string lastName;

    public Person(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    public void Login()
    {
        Console.WriteLine("User logged in.");
    }

    public void Logout()
    {
        Console.WriteLine("User logged out.");
    }
}

// Клас Rectangle, який реалізує інтерфейс IFigure
class Rectangle : Person, IFigure
{
    private double width;
    private double height;

    public Rectangle(string firstName, string lastName, double width, double height) : base(firstName, lastName)
    {
        this.width = width;
        this.height = height;
    }

    public double CalculateArea()
    {
        return width * height;
    }

    public double CalculatePerimeter()
    {
        return 2 * (width + height);
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Rectangle:");
        Console.WriteLine($"Width: {width}, Height: {height}");
        Console.WriteLine($"Area: {CalculateArea()}, Perimeter: {CalculatePerimeter()}");
    }

    public void Dispose()
    {
        Console.WriteLine("Rectangle disposed.");
    }
}

// Клас Circle, який реалізує інтерфейс IFigure
class Circle : Person, IFigure
{
    private double radius;

    public Circle(string firstName, string lastName, double radius) : base(firstName, lastName)
    {
        this.radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * radius * radius;
    }

    public double CalculatePerimeter()
    {
        return 2 * Math.PI * radius;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Circle:");
        Console.WriteLine($"Radius: {radius}");
        Console.WriteLine($"Area: {CalculateArea()}, Perimeter: {CalculatePerimeter()}");
    }

    public void Dispose()
    {
        Console.WriteLine("Circle disposed.");
    }
}

// Клас Triangle, який реалізує інтерфейс IFigure
class Triangle : Person, IFigure
{
    private double side1;
    private double side2;
    private double side3;

    public Triangle(string firstName, string lastName, double side1, double side2, double side3) : base(firstName, lastName)
    {
        this.side1 = side1;
        this.side2 = side2;
        this.side3 = side3;
    }

    public double CalculateArea()
    {
        double p = (side1 + side2 + side3) / 2;
        return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
    }

    public double CalculatePerimeter()
    {
        return side1 + side2 + side3;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Triangle:");
        Console.WriteLine($"Side 1: {side1}, Side 2: {side2}, Side 3: {side3}");
        Console.WriteLine($"Area: {CalculateArea()}, Perimeter: {CalculatePerimeter()}");
    }

    public void Dispose()
    {
        Console.WriteLine("Triangle disposed.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Rectangle rectangle = new Rectangle("John", "Doe", 4, 5);
        Circle circle = new Circle("Jane", "Smith", 3);
        Triangle triangle = new Triangle("Alice", "Johnson", 3, 4, 5);

        IFigure[] figures = { rectangle, circle, triangle };

        foreach (var figure in figures)
        {
            figure.DisplayInfo();
            figure.Dispose();
            Console.WriteLine();
        }
    }
}