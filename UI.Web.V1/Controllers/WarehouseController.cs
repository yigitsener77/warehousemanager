using BusinessLogic.Services;
using Core.Abstracts.IRepositories;
using Core.Abstracts.IServices;
using Core.Concretes.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI.Web.V1.Models;

namespace UI.Web.V1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService service = new WarehouseService();
        private ApplicationUserManager userManager;
        public ApplicationUserManager UserManager
        {
            get => userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            set => userManager = value;
        }

        public WarehouseController() {}
        public WarehouseController(ApplicationUserManager userManager)
        {
            this.userManager = userManager;
        }

        // GET: Warehouse
        public async Task<ActionResult> Index()
        {
            return View(await service.GetWarehousesAsync());
        }

        // GET: Warehouse/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var warehouse = await service.GetWarehousesAsync(id);
            if (warehouse == null)
                return HttpNotFound();

            foreach (var item in warehouse.Employees)
            {
                item.Role = UserManager.GetRoles(item.Id).FirstOrDefault();
            }
            return View(warehouse);
        }


        // GET: Warehouse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warehouse/Create
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

        // GET: Warehouse/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var item = await service.GetWarehousesAsync(id);
            return View(new WarehouseEditModel
            {
                Id = item.Id,
                Name = item.Name,
                Location = item.Location
            });
        }

        // POST: Warehouse/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, WarehouseEditModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                if (await service.GetWarehousesAsync(id) != null)
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


        // POST: Warehouse/Delete/5
        [HttpPost]
        public async Task<bool> ToggleDelete(int id)
        {
            return await service.ToggleRecyclingWarehouseAsync(id);

        }

        [HttpPost]
        public async Task<bool> ToggleActive(int id)
        {
            return await service.ToggleActivationWarehouseAsync(id);

        }
    }
}
