using BusinessLogic.Middlewares;
using BusinessLogic.Services;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace UI.Web.V1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeesController : Controller
    {
        private readonly IWarehouseService _warehouseService = new WarehouseService();
        private ApplicationUserManager userManager;
        public ApplicationUserManager UserManager
        {
            get => userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            private set => userManager = value;
        }

        public EmployeesController(ApplicationUserManager userManager) => UserManager = userManager;

        public EmployeesController() { }

        // GET: Employees
        public ActionResult Index()
        {
            var employees = MapperConfig.Mapper.Map<List<EmployeeDTO>>(UserManager.Users.ToList());
            foreach (var employee in employees)
            {
                employee.Role = UserManager.GetRoles(employee.Id).FirstOrDefault();
            }
            return View(employees);
        }

        // GET: Employees/Details/5
        public async Task<ActionResult> Details(string id)
        {
            ViewBag.Warehouses = await _warehouseService.GetWarehousesAsync();
            var employee = MapperConfig.Mapper.Map<EmployeeDTO>(UserManager.FindById(id));
            employee.Role = UserManager.GetRoles(employee.Id).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        public async Task<ActionResult> Details(string employeeId, int warehouseId)
        {
            var employee = UserManager.FindById(employeeId);
            employee.WarehouseId = warehouseId;
            await UserManager.UpdateAsync(employee);
            return RedirectToAction("Details", new { id = employeeId });
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
