using BusinessLogic.Services;
using Core.Abstracts.IServices;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI.Web.V1.Models;

namespace UI.Web.V1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class WarehousesController : Controller
    {
        private readonly IWarehouseService service = new WarehouseService();
        private ApplicationUserManager userManager;
        public ApplicationUserManager UserManager
        {
            get => userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            set => userManager = value;
        }

        public WarehousesController() { }

        public WarehousesController(ApplicationUserManager userManager)
        {
            this.userManager = userManager;
        }
        // GET: Warehouses
        public async Task<ActionResult> Index()
        {
            return View(await service.GetWarehousesAsync());
        }

        // GET: Warehouses/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var warehouse = await service.GetWarehouseAsync(id);
            foreach (var item in warehouse.Employees)
            {
                item.Role = UserManager.GetRoles(item.Id).FirstOrDefault();
            }
            return View(warehouse);
        }

        // GET: Warehouses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warehouses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(WarehouseCreateModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                await service.NewWarehouseAsync(model.Name, model.Location);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Warehouses/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var item = await service.GetWarehouseAsync(id);
            return View(new WarehouseEditModel
            {
                Id = item.Id,
                Name = item.Name,
                Location = item.Location
            });
        }

        // POST: Warehouses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, WarehouseEditModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                if (await service.GetWarehouseAsync(id) != null)
                {
                    await service.ChangeWarehouseAsync(id, name: model.Name, location: model.Location);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // POST: Warehouses/ToggleDelete/5
        [HttpPost]
        public async Task<bool> ToggleDelete(int id)
        {
            return await service.ToggleRecyclingWarehouseAsync(id);
        }

        // POST: Warehouses/ToggleActive/5
        [HttpPost]
        public async Task<bool> ToggleActive(int id)
        {
            return await service.ToggleActivationWarehouseAsync(id);
        }
    }
}
