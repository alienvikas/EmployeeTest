using EmployeeApi.Models;
using EmployeeApi.Repository;
using EmployeeApi.ViewModel;
using WebAPI.Tests.MockData;

namespace WebAPI.Tests.MockRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<TmpEmployee> tmpEmployeeList = Data.tmpEmployees;
        public async Task AddAsync(EmployeeViewModel model)
        {
            TmpEmployee emp = new TmpEmployee()
            {
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
                EmployeeId = model.EmployeeId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                Salary = model.Salary,
                Id = model.Id!.Value,
            };
            (await GetAllAsync()).Add(emp);
        }

        public async Task DeleteByIdAsync(int id)
        {
            (await GetAllAsync()).RemoveAll(x => x.Id == id);
        }

        public async Task<List<TmpEmployee>> GetAllAsync()
        {
            return await Task.FromResult(tmpEmployeeList);
        }

        public async Task<TmpEmployee?> GetByIdAsync(int id)
        {
            return await Task.FromResult((await GetAllAsync()).FirstOrDefault(x => x.Id == id));
        }

        public async Task UpdateAsync(EmployeeViewModel model)
        {
            await DeleteByIdAsync(model.Id!.Value);
            await AddAsync(model);
        }
    }
}
