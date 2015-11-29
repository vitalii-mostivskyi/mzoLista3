using System.Configuration;
using mzoLista3.Data;

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
    }
}
