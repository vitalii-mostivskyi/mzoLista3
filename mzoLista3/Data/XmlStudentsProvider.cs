using mzoLista3.Interfaces;
using System.Collections.Generic;
using System.Linq;
using mzoLista3.Models;
using System.Xml.Linq;
using System.Configuration;

namespace mzoLista3.Data
{
    internal class XmlStudentsProvider : IStudentsProvider
    {
        private string path;

        public string Path
        {
            get { return path; }
        }

        public XmlStudentsProvider()
        {
            path = ConfigurationManager.AppSettings["xmlFilePath"];
        }

        public List<Student> GetStudents()
        {
            IEnumerable<XElement> studentsElements = XElement.Load(Path).Elements("student");

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
