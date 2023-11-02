
using Academy.Core.Models.BaseModels;
using Academy.Core.Repositories;

namespace Academy.Data.Repositories
{
    //Creating another generic repo.Need to specify the same constraints as IRepository.
    //Creating List<T> for GetAll method.
    //Add method adds object to the List.
    //GetAll returns list.
    //GetAll(Func<T, bool> func) returns the List according to the set condition.
    //Get uses FirstOrDefault method on List for set condition.
    //Remove method uses Remove method on List for specified object.
    //Add and Remove methods doesn't return any value.
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        List<T> values = new List<T>();
        public async Task AddAsync(T entity)
        {
            values.Add(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return values;
        }

        public async Task<List<T>> GetAllAsync(Func<T, bool> func)
        {
            return values.Where(func).ToList();
        }

        public async Task<T> GetAsync(Func<T, bool> func)
        {
            return values.FirstOrDefault(func);
        }

        public async Task RemoveAsync(T entity)
        {
            values.Remove(entity);
        }
    }
}
