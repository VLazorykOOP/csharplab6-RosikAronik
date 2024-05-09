using System;
using System.Collections;
using System.Collections.Generic;

// Інтерфейс, який успадковує інтерфейси .NET
interface IFigure : IDisposable, IEnumerable
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

// Клас Rectangle, який реалізує інтерфейс IFigure та IEnumerable
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

    // Реалізація інтерфейсу IEnumerable для можливості використання foreach
    public IEnumerator GetEnumerator()
    {
        yield return this;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Rectangle rectangle = new Rectangle("John", "Doe", 4, 5);

        // Використання foreach для ітерації через об'єкт Rectangle
        foreach (var item in rectangle)
        {
            ((IFigure)item).DisplayInfo();
            ((IFigure)item).Dispose();
            Console.WriteLine();
        }
    }
}