using mzoLista3.Interfaces;
using System.Collections.Generic;
using System.Linq;
using mzoLista3.Models;
using System.Xml.Linq;

namespace mzoLista3.Data
{
    internal class XmlStudentsProvider : IStudentsProvider
    {
        public List<Student> GetStudents(string path)
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
