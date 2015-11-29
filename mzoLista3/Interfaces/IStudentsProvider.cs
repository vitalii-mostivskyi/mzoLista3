using mzoLista3.Models;
using System.Collections.Generic;

namespace mzoLista3.Interfaces
{
    internal interface IStudentsProvider
    {
        string Path { get; }

        List<Student> GetStudents();
    }
}
