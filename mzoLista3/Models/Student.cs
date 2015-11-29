using System;

namespace mzoLista3.Models
{
    public class Student
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public void Print()
        {
            Console.WriteLine("{0} {1}", Name, Surname);
        }
    }
}
