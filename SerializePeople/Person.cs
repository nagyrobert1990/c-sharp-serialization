using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

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
        

        public Person(String name, DateTime birthDate, Genders gender)
        {
            this.Name = name;
            this.BirthDate = birthDate;
            this.Gender = gender;
            this.Age = DateTime.Today.Year - this.BirthDate.Year;
        }

        public override string ToString()
        {
            return $"Name: {Name} BirthDate: {BirthDate.Year} {BirthDate.Month} {BirthDate.Day} Sex: {Gender}";
        }
    }
}
