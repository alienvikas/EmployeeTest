using EmployeeApi.Models;
using EmployeeApi.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            ArgumentNullException.ThrowIfNull(employeeDbContext);
            _employeeDbContext = employeeDbContext;
        }

        public async Task AddAsync(EmployeeViewModel model)
        {
            if (model.Id == 0)
            {
                var emp = new TmpEmployee()
                {
                    Address = model.Address,
                    Gender = model.Gender,
                    DateOfBirth = model.DateOfBirth,
                    EmployeeId = model.EmployeeId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName,
                    Salary = model.Salary
                };
                await _employeeDbContext.TmpEmployees.AddAsync(emp);
                await _employeeDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            if (id > 0)
            {
                var empDetails = await _employeeDbContext.TmpEmployees.FindAsync(id);
                if (empDetails != null)
                {
                    _employeeDbContext.TmpEmployees.Remove(empDetails);
                    await _employeeDbContext.SaveChangesAsync();
                }
            }
        }

        public async Task<List<TmpEmployee>> GetAllAsync()
        {
            return await _employeeDbContext.TmpEmployees.ToListAsync();
        }

        public async Task<TmpEmployee?> GetByIdAsync(int id)
        {
            return await _employeeDbContext.TmpEmployees.FindAsync(id);
        }

        public async Task UpdateAsync(EmployeeViewModel model)
        {
            var emp = await _employeeDbContext.TmpEmployees.FindAsync(model.Id);
            if (emp != null)
            {
                emp.Salary = model.Salary;
                emp.Gender = model.Gender;
                emp.DateOfBirth = model.DateOfBirth;
                emp.FirstName = model.FirstName;
                emp.LastName = model.LastName;
                emp.MiddleName = model.MiddleName;
                emp.EmployeeId = model.EmployeeId;
                _employeeDbContext.TmpEmployees.Update(emp);
                await _employeeDbContext.SaveChangesAsync();
            }
        }
    }
}
