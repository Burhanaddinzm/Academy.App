
using Academy.Core.Enums;
using Academy.Core.Models.BaseModels;

namespace Academy.Core.Models
{
    public class Student : BaseModel
    {
        private static int _id;

        public string FullName { get; set; }
        public string Group { get; set; }
        public double Average { get; set; }
        public StudentEducation Education { get; set; }

        public Student(string fullName, string group, double average, StudentEducation education)
        {
            _id++;
            FullName = fullName;
            Group = group;
            Average = average;
            Education = education;

            string educationName = Education.ToString();
            Id = $"{educationName[0]}-{_id}";
        }

    }
}
