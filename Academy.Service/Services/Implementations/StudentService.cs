using Academy.Core.Enums;
using Academy.Core.Models;
using Academy.Core.Repositories;
using Academy.Data.Repositories;
using Academy.Service.Services.Interfaces;

namespace Academy.Service.Services.Implementations
{
    public class StudentService : IStudentService
    {
        //Creating repo object. Downcasting?
        //User inputs is taken from MenuService.
        //GetAll takes values from StudentRepo and displays every object.
        //Get takes the values from StudentRepo by Id.
        //Remove takes the object from Get and removes them.
        //Update takes the object from Get and updates them.
        //Methods that have return string, returns the releated message.

        IStudentRepository _studentRepository = new StudentRepository();
        public async Task<string> CreateAsync(string fullName, string group, double average, StudentEducation education)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return "Full Name can not be empty!";

            if (string.IsNullOrWhiteSpace(group))
                return "Group can not be empty!";

            if (average <= 0 || average >= 100)
                return "Average can't be below 0 or above 100";

            Student student = new Student(fullName, group, average, education);
            student.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _studentRepository.AddAsync(student);

            return "Successfully Created!";

        }

        public async Task GetAllAsync()
        {
            List<Student> students = await _studentRepository.GetAllAsync();

            foreach (Student student in students)
            {
                Console.WriteLine($"Id:{student.Id} Full Name:{student.FullName} Group:{student.Group} Average:{student.Average} Education:{student.Education} CreatedAt:{student.CreatedAt} UpdatedAt:{student.UpdatedAt}");
            }
        }

        public async Task<string> GetAsync(string id)
        {
            Student student = await _studentRepository.GetAsync(x => x.Id == id);
            if (student == null)
                return "Student not found!";

            Console.WriteLine($"Id:{student.Id} Full Name:{student.FullName} Group:{student.Group} Average:{student.Average} Education:{student.Education} CreatedAt:{student.CreatedAt} UpdatedAt:{student.UpdatedAt}");
            return "Student found successfully!";
        }

        public async Task<string> RemoveAsync(string id)
        {
            Student student = await _studentRepository.GetAsync(x => x.Id == id);
            if (student == null)
                return "Student not found!";

            await _studentRepository.RemoveAsync(student);
            return "Removed successfully!";
        }

        public async Task<string> UpdateAsync(string id, string fullName, string group, double average, StudentEducation education)
        {
            Student student = await _studentRepository.GetAsync(x => x.Id == id);
            if (student == null)
                return "Student not found!";

            if (string.IsNullOrWhiteSpace(fullName))
                return "Full Name can not be empty!";

            if (string.IsNullOrWhiteSpace(group))
                return "Group can not be empty!";

            if (average <= 0 || average >= 100)
                return "Average can't be below 0 or above 100";

            student.FullName = fullName;
            student.Group = group;
            student.Average = average;
            student.Education = education;
            student.UpdatedAt = DateTime.UtcNow.AddHours(4);

            return "Updated Successfully!";

        }
    }
}
