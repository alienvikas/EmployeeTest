using EmployeeApi.Models;
using EmployeeApi.Repository;
using EmployeeApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeRepository employeeRepository) : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;

        [HttpGet]
        public async Task<List<TmpEmployee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        [HttpPost]
        public async Task AddAsync(EmployeeViewModel model)
        {
            await _employeeRepository.AddAsync(model);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _employeeRepository.DeleteByIdAsync(id);
        }

        [HttpGet("getEmployee/{id}")]
        public async Task<TmpEmployee?> GetAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task UpdateAsync(int id, EmployeeViewModel model)
        {
            if (id == model.Id)
            {
                await _employeeRepository.UpdateAsync(model);
            }
        }
    }
}
