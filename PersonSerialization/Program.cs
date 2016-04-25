using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace PersonSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Milan", new DateTime(1995,10,27));
            Person person2 = new Person("Mate", new DateTime(1999,03,11));
            Person person3 = new Person("Gabor", new DateTime(1942,03,13));
            Person person4 = new Person("Zoli", new DateTime(1991,12,04));

            Console.WriteLine(person);
            Console.WriteLine(person2);
            Console.WriteLine(person3);
            Console.WriteLine(person4);

            Serialize(person);
            Serialize(person2);
            Serialize(person3);
            Serialize(person4);

            Person desPerson = Deserialize();
            Console.WriteLine("Deserialized person: ");
            Console.WriteLine(desPerson);
        }

        private static void Serialize(Person newPerson) {
            FileStream fileStream = new FileStream("Person.dat", FileMode.Create);
            BinaryFormatter binFormatter = new BinaryFormatter();

            binFormatter.Serialize(fileStream, newPerson);
            fileStream.Close();
        }

        private static Person Deserialize()
        {
            FileStream fileStream = new FileStream("Person.dat", FileMode.Open);
            BinaryFormatter binFormatter = new BinaryFormatter();

            var person = (Person)binFormatter.Deserialize(fileStream);

            fileStream.Close();

            return person;
        }
    }
}
