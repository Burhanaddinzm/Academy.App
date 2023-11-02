
using Academy.Core.Enums;

namespace Academy.Service.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<string> CreateAsync(string fullName, string group, double average, StudentEducation education);
        public Task<string> UpdateAsync(string id, string fullName, string group, double average, StudentEducation education);
        public Task<string> RemoveAsync(string id);
        public Task<string> GetAsync(string id);
        public Task GetAllAsync();
    }
}
