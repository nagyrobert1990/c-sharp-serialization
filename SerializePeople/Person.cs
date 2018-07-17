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
    public class Person : IDeserializationCallback, ISerializable
    {
        public String Name { get; }
        public DateTime BirthDate { get; }
        public enum Genders { Male, Female };
        public Genders Gender { get; }

        [NonSerialized()] public int Age;
        

        public Person(string name, DateTime birthDate, Genders gender)
        {
            this.Name = name;
            this.BirthDate = birthDate;
            this.Gender = gender;
            this.Age = DateTime.Today.Year - this.BirthDate.Year;
        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            this.Name = (string)info.GetValue("Name", typeof(string));
            this.BirthDate = (DateTime)info.GetValue("Birthdate", typeof(DateTime));
            this.Gender = (Genders)info.GetValue("Gender", typeof(Genders));
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

        public void OnDeserialization(object sender)
        {
            this.Age = DateTime.Today.Year - this.BirthDate.Year;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name, typeof(string));
            info.AddValue("Birthdate", BirthDate, typeof(DateTime));
            info.AddValue("Gender", Gender, typeof(Genders));
        }

        public override string ToString()
        {
            return $"Name: {Name}\nBirthDate: {BirthDate.Year} {BirthDate.Month} {BirthDate.Day}\nSex: {Gender}\nAge: {Age}";
        }
    }
}
