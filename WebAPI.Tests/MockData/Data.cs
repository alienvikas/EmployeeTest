using EmployeeApi.Models;

namespace WebAPI.Tests.MockData
{
    public static class Data
    {
        //public static List<TmpEmployee> GetAllEmployee()
        //{
        //    return new List<TmpEmployee>() {
        //        new() { Id = 1, FirstName = "Test1", MiddleName = "Test2", LastName = "Test3", Salary = "1000", EmployeeId = "S100" },
        //        new() { Id = 2, FirstName = "Test4", MiddleName = "Test5", LastName = "Test6", Salary = "2000", EmployeeId = "S200" },
        //        new() { Id = 3, FirstName = "Test7", MiddleName = "Test8", LastName = "Test9", Salary = "3000", EmployeeId = "S300" },
        //        new() { Id = 4, FirstName = "Test10", MiddleName = "Test11", LastName = "Test12", Salary = "4000", EmployeeId = "S400" },
        //        new() { Id = 5, FirstName = "Test13", MiddleName = "Test14", LastName = "Test15", Salary = "5000", EmployeeId = "S500" },
        //        new() { Id = 6, FirstName = "Test16", MiddleName = "Test17", LastName = "Test18", Salary = "6000", EmployeeId = "S600" },
        //    };
        //}

        public static List<TmpEmployee> tmpEmployees => new List<TmpEmployee>() {
                new () { Id = 1, FirstName = "Test1", MiddleName = "Test2", LastName = "Test3", Salary = "1000", EmployeeId = "S100" },
                new () { Id = 2, FirstName = "Test4", MiddleName = "Test5", LastName = "Test6", Salary = "2000", EmployeeId = "S200" },
                new() { Id = 3, FirstName = "Test7", MiddleName = "Test8", LastName = "Test9", Salary = "3000", EmployeeId = "S300" },
                new() { Id = 4, FirstName = "Test10", MiddleName = "Test11", LastName = "Test12", Salary = "4000", EmployeeId = "S400" },
                new() { Id = 5, FirstName = "Test13", MiddleName = "Test14", LastName = "Test15", Salary = "5000", EmployeeId = "S500" },
                new() { Id = 6, FirstName = "Test16", MiddleName = "Test17", LastName = "Test18", Salary = "6000", EmployeeId = "S600" },
            };
    }
}
