using EmployeeApi.Models;
using EmployeeApi.ViewModel;
using WebAPI.Tests.MockRepository;

namespace WebAPI.Tests
{
    public class EmployeeControllerTest
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeControllerTest()
        {
            _employeeRepository ??= new EmployeeRepository();
        }

        [Fact]
        public async Task GetByIdEmployee()
        {
            var expected = new TmpEmployee()
            {
                Id = 1,
                FirstName = "Test1",
                MiddleName = "Test2",
                LastName = "Test3",
                Salary = "1000",
                EmployeeId = "S100"
            };
            var actual = await _employeeRepository.GetByIdAsync(1);
            Assert.Equal(expected.Id, actual?.Id);
        }

        [Fact]
        public async Task GetAllEmployee()
        {
            var actual = await _employeeRepository.GetAllAsync();
            Assert.Equal(6, actual?.Count);
        }

        [Fact]
        public async Task AddEmployee()
        {
            var employee = new EmployeeViewModel()
            {
                Id = 7,
                FirstName = "Test19",
                MiddleName = "Test20",
                LastName = "Test21",
                Salary = "2000",
                EmployeeId = "S700"
            };
            await _employeeRepository.AddAsync(employee);
            var actual = await _employeeRepository.GetByIdAsync(7);
            Assert.Equal(employee.Id, actual?.Id);
        }

        [Fact]
        public async Task UpdateEmployee()
        {
            var data = await _employeeRepository.GetByIdAsync(2);
            var VM = new EmployeeViewModel()
            {
                Id = data.Id,
                FirstName = data.FirstName,
                MiddleName = data.MiddleName,
                LastName = data.LastName,
                Salary = data.Salary,
                EmployeeId = data.EmployeeId,
                Address = data.Address
            };
            VM.FirstName = "XYZ";
            await _employeeRepository.UpdateAsync(VM);
            var actual = await _employeeRepository.GetByIdAsync(2);
            Assert.Equal("XYZ", actual?.FirstName);
        }

        [Fact]
        public async Task DeleteByIdEmployee()
        {
            await _employeeRepository.DeleteByIdAsync(5);
            var actual = await _employeeRepository.GetAllAsync();
            Assert.Equal(5, actual?.Count);
        }
    }
}
