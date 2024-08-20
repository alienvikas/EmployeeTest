using Microsoft.AspNetCore.Mvc;
using MVCTestApplication.Models;

namespace MVCTestApplication.Controllers
{
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpClient _httpClient = new()
            {
                BaseAddress = new Uri("https://localhost:7278/api/")
            };
            var empList = await _httpClient.GetFromJsonAsync<List<EmployeeModel>>("employee");
            return View(empList);
        }

        public async Task<IActionResult> Create(EmployeeModel model)
        {
            HttpClient _httpClient = new()
            {
                BaseAddress = new Uri("https://localhost:7278/api/")
            };
            if (model.Id == 0)
                await _httpClient.PostAsJsonAsync("employee", model);
            else
                await _httpClient.PutAsJsonAsync("employee/" + model.Id, model);

            return PartialView("_EmployeeList", await _httpClient.GetFromJsonAsync<List<EmployeeModel>>("employee"));
        }

        public async Task<IActionResult> Edit(int id)
        {
            HttpClient _httpClient = new()
            {
                BaseAddress = new Uri("https://localhost:7278/api/")
            };
            var empDetail = await _httpClient.GetFromJsonAsync<EmployeeModel>($"employee/getEmployee/{id}");
            return Json(empDetail);
        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpClient _httpClient = new()
            {
                BaseAddress = new Uri("https://localhost:7278/api/")
            };
            await _httpClient.DeleteAsync($"employee/{id}");
            return PartialView("_EmployeeList", await _httpClient.GetFromJsonAsync<List<EmployeeModel>>("employee"));
        }
    }
}
