using System;
using System.Collections.Generic;
using System.Linq;

namespace L05.FilterByAge
{
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputArray = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person(inputArray[0], int.Parse(inputArray[1])));
            }

            string filterOutput = Console.ReadLine();
            int ageOutput = int.Parse(Console.ReadLine());
            string formarOutput = Console.ReadLine();

            Func<Person, int, bool> filter = GetFilter(filterOutput);
            Action<Person> printer = GetPrinter(formarOutput);

            people = people.Where(x => filter(x, ageOutput)).ToList();
            people.ForEach(printer);
        }

        private static Action<Person> GetPrinter(string formarOutput)
        {
            return formarOutput switch
            {
                "name" => x => Console.WriteLine(x.Name),
                "age" => x => Console.WriteLine(x.Age),
                "name age" => x => Console.WriteLine($"{x.Name} - {x.Age}"),
                _ => null
            };
        }

        private static Func<Person, int, bool> GetFilter(string filterOutput)
        {
            return filterOutput switch
            {
                "younger" => (p, a) => p.Age < a,
                "older" => (p, a) => p.Age > a,
                _ => null
            };
        }
    }
}