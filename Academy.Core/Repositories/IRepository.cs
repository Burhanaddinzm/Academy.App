
using Academy.Core.Models.BaseModels;

namespace Academy.Core.Repositories
{
    //Can only use this interface in classes where it inherits from BaseModel.
    //Get and GetAll methods use Func<T, bool> func for specific searching.
    //T stands for specific class and bool stands for searching conditions.
    //T entity stands for the object created by the specified Class.
    public interface IRepository<T> where T : BaseModel
    {
        public Task AddAsync(T entity);
        public Task RemoveAsync(T entity);
        public Task<T> GetAsync(Func<T, bool> func);
        public Task<List<T>> GetAllAsync();
        public Task<List<T>> GetAllAsync(Func<T, bool> func);
    }
}
