using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Configuration;
using mzoLista3.Models;
using mzoLista3.Data;
using System;

namespace mzoLista3
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvFilePath = ConfigurationManager.AppSettings["csvFilePath"];

            new CsvStudentsProvider().GetStudents(csvFilePath)
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
