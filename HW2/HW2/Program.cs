using System;

public class Person
{
    private string name;
    private string address;
    private double salary;

    public Person() { }

    public Person(string name, string address, double salary)
    {
        this.name = name;
        this.address = address;
        this.salary = salary;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    public double Salary
    {
        get { return salary; }
        set { salary = value; }
    }
}

class Program
{
    public static Person inputPersonInfo(string name, string address, string sSalary)
    {
        if (string.IsNullOrWhiteSpace(sSalary))
        {
            throw new Exception("You must input Salary.");
        }

        if (!double.TryParse(sSalary, out double salary))
        {
            throw new Exception("You must input digit.");
        }

        if (salary <= 0)
        {
            throw new Exception("Salary is greater than zero");
        }

        return new Person(name, address, salary);
    }

    public static void displayPersonInfo(Person person)
    {
        Console.WriteLine("Information of Person you have entered:");
        Console.WriteLine($"Name: {person.Name}");
        Console.WriteLine($"Address: {person.Address}");
        Console.WriteLine($"Salary: {person.Salary}");
    }

    public static Person[] sortBySalary(Person[] person)
    {
        try
        {
            int n = person.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (person[j].Salary > person[j + 1].Salary)
                    {
                        Person temp = person[j];
                        person[j] = person[j + 1];
                        person[j + 1] = temp;
                    }
                }
            }
            return person;
        }
        catch (Exception)
        {
            throw new Exception("Can't Sort Person");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("=====Management Person programer=====");
        Person[] persons = new Person[3];

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Input Information of Person");

            Console.Write("Please input name: ");
            string name = Console.ReadLine();

            Console.Write("Please input address: ");
            string address = Console.ReadLine();

            double salary = 0;
            while (true)
            {
                Console.Write("Please input salary: ");
                string sSalary = Console.ReadLine();
                try
                {
                    Person p = inputPersonInfo(name, address, sSalary);
                    salary = p.Salary;
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            persons[i] = new Person(name, address, salary);
        }

        persons = sortBySalary(persons);

        foreach (var p in persons)
        {
            displayPersonInfo(p);
        }
    }
}