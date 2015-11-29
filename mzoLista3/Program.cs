using System.Configuration;
using mzoLista3.Data;
using mzoLista3.Enums;
using mzoLista3.Interfaces;

namespace mzoLista3
{
    class Program
    {
        static void Main(string[] args)
        {
            var mode = ReadMode.Csv;

            if (args != null && args.Length > 0)
            {
                var modeString = args[0];

                if (!string.IsNullOrEmpty(args[0]))
                {
                    switch (args[0])
                    {
                        case "csv":
                            mode = ReadMode.Csv;
                            break;

                        case "xml":
                            mode = ReadMode.Xml;
                            break;
                    }
                }
            }

            IStudentsProvider studentsProvider = null;

            switch(mode)
            {
                case ReadMode.Csv:
                    studentsProvider = new CsvStudentsProvider();
                    break;

                case ReadMode.Xml:
                    studentsProvider = new XmlStudentsProvider();
                    break;

            }

            studentsProvider.GetStudents()
               .ForEach(s => s.Print());
        }
    }
}
