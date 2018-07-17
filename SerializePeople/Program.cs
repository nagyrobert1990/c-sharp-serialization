using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializePeople
{
    class Program
    {
        static void Main(string[] args)
        {
            Person Kovacs = new Person("Géza", new DateTime(1988, 8, 15), Person.Genders.Male);
            Console.WriteLine(Kovacs.ToString());

            Console.WriteLine();

            Kovacs.Serialize("Person.bin");
            Person person = Person.Deserialize("Person.bin");
            Console.WriteLine(person.ToString());

            Console.ReadKey();
        }
    }
}
