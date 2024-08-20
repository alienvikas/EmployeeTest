using EmployeeApi.Models;
using EmployeeApi.ViewModel;

namespace EmployeeApi.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<TmpEmployee>> GetAllAsync();
        Task AddAsync(EmployeeViewModel model);
        Task DeleteByIdAsync(int id);
        Task<TmpEmployee?> GetByIdAsync(int id);
        Task UpdateAsync(EmployeeViewModel model);
    }
}
