
using Academy.Core.Models;
using Academy.Core.Repositories;

namespace Academy.Data.Repositories
{
    //Inherits both Repository<Student> and IStudentRepository
    public class StudentRepository : Repository<Student>,IStudentRepository
    {

    }
}
