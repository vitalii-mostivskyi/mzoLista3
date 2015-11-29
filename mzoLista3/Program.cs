using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Configuration;
using System.Xml.Linq;
using System.Threading;

namespace mzoLista3
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlFilePath = ConfigurationManager.AppSettings["xmlFilePath"];

            GetStudents(xmlFilePath)
               .ForEach(s => s.Print());
        }

        private static List<Student> GetStudents(string path)
        {
            IEnumerable<XElement> studentsElements = XElement.Load(path).Elements("student");

            return studentsElements.Select(se =>
            {
                if (se != null)
                {
                    return new Student
                    {
                        Name = se.Element("imie").Value,
                        Surname = se.Element("nazwisko").Value,
                    };
                }

                return null;
            }).Where(s => s != null).ToList();
        }
    }
}
