
using Academy.Core.Enums;

namespace Academy.Service.Services.Interfaces
{   
    //All of the methods except GetAll returns string for conditional messages.
    //Create method takes all the set values and sets them to the specified class'es constructor.
    //Update method is mostly the same as Create but additionally takes id as well for identifing required object.
    public interface IStudentService
    {
        public Task<string> CreateAsync(string fullName, string group, double average, StudentEducation education);
        public Task<string> UpdateAsync(string id, string fullName, string group, double average, StudentEducation education);
        public Task<string> RemoveAsync(string id);
        public Task<string> GetAsync(string id);
        public Task GetAllAsync();
    }
}
