using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectCopyMethods
{

    class Person
    {
        public string name;
        public int age;

        public Person() { }

        public Person(Person copyPerson)
        {
            this.name = copyPerson.name;
            this.age = copyPerson.age;
        }

        public override string ToString()
        {
            return $"Name: {name}, age : {age}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Testing object
            Person Agatha = new Person();
            Agatha.name = "Agatha";
            Agatha.age = 22;

            Person DeepCopy = new Person(Agatha);
            Person Copy = DeepCopy;

            Console.WriteLine("-- Before change --");
            Console.WriteLine(Agatha);
            Console.WriteLine(DeepCopy);
            Console.WriteLine(Copy);

            DeepCopy.name = "Copy";
            DeepCopy.age = 20;

            Console.WriteLine("\n-- After Change --");

            Console.WriteLine(Agatha);
            Console.WriteLine(DeepCopy);
            Console.WriteLine(Copy);

            // Testing lists of objects
            List<Person> people = new List<Person>() 
            {
                Agatha,
                DeepCopy
            };

            List<Person> CopyOfPeople = new List<Person>(people);
            List<Person> DeepCopyOfPeople = people.ConvertAll(person => new Person(person));

            // Modififying person list object
            CopyOfPeople[0].age = 23;

            Console.WriteLine("\n-- People --");
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine("\n-- Copy of people --");
            foreach (Person person in CopyOfPeople)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine("\n-- Deep Copy of people --");
            foreach (Person person in DeepCopyOfPeople)
            {
                Console.WriteLine(person);
            }

            Console.ReadKey();
        }
    }
}
