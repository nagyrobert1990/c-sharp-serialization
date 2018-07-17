using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializePeople
{
    [Serializable()]
    class Person 
    {
        public String Name { get; }
        public DateTime BirthDate { get; set; }
        public enum Genders { Male, Female };
        public Genders Gender { get; set; }
        public int Age { get; }
        

        public Person(string name, DateTime birthDate, Genders gender)
        {
            this.Name = name;
            this.BirthDate = birthDate;
            this.Gender = gender;
            this.Age = DateTime.Today.Year - this.BirthDate.Year;
        }
        
        public void Serialize(string output)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(output,
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();
        }
        
        public static Person Deserialize(string input)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(input,
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
            Person person = (Person)formatter.Deserialize(stream);
            stream.Close();
            return person;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nBirthDate: {BirthDate.Year} {BirthDate.Month} {BirthDate.Day}\nSex: {Gender}\nAge: {Age}";
        }
    }
}
