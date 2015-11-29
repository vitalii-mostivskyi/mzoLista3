using System.Configuration;
using mzoLista3.Data;

namespace mzoLista3
{
    class Program
    {
        static void Main(string[] args)
        {
            new XmlStudentsProvider().GetStudents(ConfigurationManager.AppSettings["xmlFilePath"])
               .ForEach(s => s.Print());
        }
    }
}
