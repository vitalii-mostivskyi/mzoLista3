using mzoLista3.Interfaces;
using System.Collections.Generic;
using System.Linq;
using mzoLista3.Models;
using System.IO;
using System.Configuration;

namespace mzoLista3.Data
{
    internal class CsvStudentsProvider : IStudentsProvider
    {
        private string path;

        public string Path
        {
            get { return path; }
        }

        public CsvStudentsProvider()
        {
            path = ConfigurationManager.AppSettings["csvFilePath"];
        }

        public List<Student> GetStudents()
        {
            return File.ReadAllLines(Path).Select(l =>
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
