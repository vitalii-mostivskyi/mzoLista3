using mzoLista3.Interfaces;
using System.Collections.Generic;
using System.Linq;
using mzoLista3.Models;
using System.IO;

namespace mzoLista3.Data
{
    internal class CsvStudentsProvider : IStudentsProvider
    {
        public List<Student> GetStudents(string path)
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
