using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Configuration;

namespace mzoLista3
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvFilePath = ConfigurationManager.AppSettings["csvFilePath"];

            GetStudents(csvFilePath)
               .ForEach(s => s.Print());
        }

        private static List<Student> GetStudents(string path)
        {
            return File.ReadAllLines(path).Select(l =>
            {
                var parts = l.Split("><".ToCharArray());

                return new Student
                {
                    Name = parts[1],
                    Surname = parts[3],
                };
            }).ToList();
        }
    }
}
