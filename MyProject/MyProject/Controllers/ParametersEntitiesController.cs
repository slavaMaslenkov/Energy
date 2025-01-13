using DataAccess.Postgres.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Models;
using MyProject.Models.IService;

namespace MyProject.Controllers
{
    public class ParametersEntitiesController : BaseController
    {

        private readonly IParametersService _parametersService;

        public ParametersEntitiesController(IEquipmentService equipmentService, 
            IParametersService parametersService, ISampleService sampleService, IUnityService unityService, 
            IPlantService plantService, ISubsystemService subsystemService, ISystemService systemService, 
            IConnectionService connectionService, IUserService userService, IRoleService roleService) 
            : base(equipmentService, parametersService, sampleService, unityService, plantService, 
                  subsystemService, systemService, connectionService, userService, roleService) 
        {
            _parametersService = parametersService;
        }

        // GET: ParametersEntities
        public async Task<IActionResult> Index()
        {
            return View(await _parametersService.GetAllAsync());
        }

        // GET: ParametersEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParametersEntities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ParametersEntity parametersEntity)
        {
            if (ModelState.IsValid)
            {
                await _parametersService.Create(parametersEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(parametersEntity);
        }
        
        // POST: ParametersEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _parametersService.DeleteConfirmed(id);
            return RedirectToAction(nameof(Index));
        }
        
        [HttpPost]
        public async Task<IActionResult> DeleteSelected(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return RedirectToAction(nameof(Index));
            }

            var idList = ids.Split(',').Select(int.Parse).ToList();

            foreach (var id in idList)
            {
                var parametersEntity = await _parametersService.FindById(id);
                if (parametersEntity != null)
                {
                    await _parametersService.DeleteConfirmed(id); // Удалить каждое устройство по ID
                }
            }

            return RedirectToAction(nameof(Index)); // Перенаправление на главную страницу
        }

        // GET: ParametersEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _parametersService.FindById(id));
        }

        // POST: ParametersEntities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Measure")] ParametersEntity parametersEntities)
        {
            if (id != parametersEntities.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _parametersService.EditPost(parametersEntities);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_parametersService.ParametersEntityExists(parametersEntities.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(parametersEntities);
        }
    }
}
