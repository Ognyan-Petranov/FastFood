using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.AspNetCore.Mvc;

using FastFood.Data;
using FastFood.Models;
using FastFood.Core.ViewModels.Employees;

namespace FastFood.Core.Controllers
{

    public class EmployeesController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public EmployeesController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Register()
        {
            var positions = this.context.Positions.ProjectTo<RegisterEmployeeViewModel>(mapper.ConfigurationProvider).ToList();
            return this.View(positions);
        }

        [HttpPost]
        public IActionResult Register(RegisterEmployeeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var employee = this.mapper.Map<Employee>(model);

            this.context.Employees.Add(employee);
            this.context.SaveChanges();

            return RedirectToAction("All");
        }

        public IActionResult All()
        {
            var employees = this.context.Employees.ProjectTo<EmployeesAllViewModel>(mapper.ConfigurationProvider).ToList();
            return this.View(employees);
        }
    }
}
