using mzoLista3.Enums;
using mzoLista3.Interfaces;
using System;

namespace mzoLista3.Data
{
    internal static class StudentsProviderFactory
    {
        public static IStudentsProvider Build(ReadMode mode)
        {
            switch (mode)
            {
                case ReadMode.Csv:
                    return new CsvStudentsProvider();

                case ReadMode.Xml:
                    return new XmlStudentsProvider();

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
