
using Academy.Core.Enums;
using Academy.Service.Services.Interfaces;

namespace Academy.Service.Services.Implementations
{
    public class MenuService
    {
        //Creating object from StudentSerivce.
        //CreateStudent:
        //Foreach takes every object from Enum and displays them using Enum.GetValues(typeof(Enum)).
        //For failsaving Enum created bool isExsist = Enum.IsDefined(Enum,enum_object) put in a while loop.
        //string result takes the message from studentSerive.Create().
        //UpdateStudent:
        //Mostly same as CreateStundent just takes Id and uses studentService.Update.
        //The rest takes Id and runs the corresponding method.
        IStudentService studentService = new StudentService();
        public async Task RunApp()
        {
            await MenuAsync();
            string request = Console.ReadLine();

            while (request != "0")
            {
                switch (request)
                {
                    case "1":
                        await CreateStudentAsync();
                        break;
                    case "2":
                        await GetAllStudentAsync();
                        break;
                    case "3":
                        await GetStudentAsync();
                        break;
                    case "4":
                        await RemoveStudentAsync();
                        break;
                    case "5":
                        await UpdateStudentAsync();
                        break;
                    default:
                        Console.WriteLine("Invalid Option!");
                        break;
                }
                await MenuAsync();
                request = Console.ReadLine();
            }

        }

        async Task CreateStudentAsync()
        {
            Console.WriteLine("Add Full Name:");
            string studentName = Console.ReadLine();
            Console.WriteLine("Add Group:");
            string studentGroup = Console.ReadLine();
            Console.WriteLine("Add Average:");
            double.TryParse(Console.ReadLine(), out double average);

            int i = 1;

            Console.WriteLine("Choose student's education:");
            foreach (var item in Enum.GetValues(typeof(StudentEducation)))
            {
                Console.WriteLine($"{i}.{item}");
                i++;
            }

            int.TryParse(Console.ReadLine(), out int enumIndex);
            bool isExsist = Enum.IsDefined(typeof(StudentEducation), (StudentEducation)enumIndex);

            while (!isExsist)
            {
                Console.WriteLine("Choose student's education:");
                int.TryParse(Console.ReadLine(), out enumIndex);
                isExsist = Enum.IsDefined(typeof(StudentEducation), (StudentEducation)enumIndex);
            }

            string result = await studentService.CreateAsync(studentName, studentGroup, average, (StudentEducation)enumIndex);
            Console.WriteLine(result);
        }
        async Task UpdateStudentAsync()
        {
            Console.WriteLine("Add Id:");
            string studentId = Console.ReadLine();
            Console.WriteLine("Add Full Name:");
            string studentName = Console.ReadLine();
            Console.WriteLine("Add Group:");
            string studentGroup = Console.ReadLine();
            Console.WriteLine("Add Average:");
            double.TryParse(Console.ReadLine(), out double average);

            int i = 1;

            Console.WriteLine("Choose student's education:");
            foreach (var item in Enum.GetValues(typeof(StudentEducation)))
            {
                Console.WriteLine($"{i}.{item}");
                i++;
            }

            int.TryParse(Console.ReadLine(), out int enumIndex);
            bool isExsist = Enum.IsDefined(typeof(StudentEducation), (StudentEducation)enumIndex);

            while (!isExsist)
            {
                Console.WriteLine("Choose student's education:");
                int.TryParse(Console.ReadLine(), out enumIndex);
                isExsist = Enum.IsDefined(typeof(StudentEducation), (StudentEducation)enumIndex);
            }

            string result = await studentService.UpdateAsync(studentId, studentName, studentGroup, average, (StudentEducation)enumIndex);
            Console.WriteLine(result);
        }
        async Task RemoveStudentAsync()
        {
            Console.WriteLine("Add Id:");
            string studentId = Console.ReadLine();
            string result = await studentService.RemoveAsync(studentId);
            Console.WriteLine(result);

        }
        async Task GetAllStudentAsync()
        {
            await studentService.GetAllAsync();
        }
        async Task GetStudentAsync()
        {
            Console.WriteLine("Add Id:");
            string studentId = Console.ReadLine();
            string result = await studentService.GetAsync(studentId);
            Console.WriteLine(result);
        }
        async Task MenuAsync()
        {
            Console.WriteLine("1.Create");
            Console.WriteLine("2.GetAll");
            Console.WriteLine("3.Get");
            Console.WriteLine("4.Remove");
            Console.WriteLine("5.Update");
            Console.WriteLine("0.Close");
        }
    }
}
