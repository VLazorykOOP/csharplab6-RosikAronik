using System;

// Базовий клас, який представляє основні характеристики для всіх типів осіб.
abstract class Person
{
    protected string firstName;
    protected string lastName;
    protected int age;

    public Person(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public abstract void Show();
}

// Клас, який представляє студентів.
class Student : Person
{
    protected int course;
    protected string specialty;

    public Student(string firstName, string lastName, int age, int course, string specialty)
        : base(firstName, lastName, age)
    {
        this.course = course;
        this.specialty = specialty;
    }

    public override void Show()
    {
        Console.WriteLine($"Student: {firstName} {lastName}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Course: {course}");
        Console.WriteLine($"Specialty: {specialty}");
    }
}

// Клас, який представляє викладачів.
class Teacher : Person
{
    protected string position;
    protected string subject;

    public Teacher(string firstName, string lastName, int age, string position, string subject)
        : base(firstName, lastName, age)
    {
        this.position = position;
        this.subject = subject;
    }

    public override void Show()
    {
        Console.WriteLine($"Teacher: {firstName} {lastName}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Position: {position}");
        Console.WriteLine($"Subject: {subject}");
    }
}

// Клас, який представляє завідувачів кафедр.
class DepartmentHead : Teacher
{
    protected string department;

    public DepartmentHead(string firstName, string lastName, int age, string position, string subject, string department)
        : base(firstName, lastName, age, position, subject)
    {
        this.department = department;
    }

    public override void Show()
    {
        Console.WriteLine($"Department Head: {firstName} {lastName}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Position: {position}");
        Console.WriteLine($"Subject: {subject}");
        Console.WriteLine($"Department: {department}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Приклад використання
        Student student = new Student("John", "Doe", 20, 2, "Computer Science");
        Teacher teacher = new Teacher("Jane", "Smith", 35, "Professor", "Mathematics");
        DepartmentHead head = new DepartmentHead("Alice", "Johnson", 45, "Associate Professor", "Physics", "Physics Department");

        student.Show();
        Console.WriteLine();
        teacher.Show();
        Console.WriteLine();
        head.Show();
    }
}
