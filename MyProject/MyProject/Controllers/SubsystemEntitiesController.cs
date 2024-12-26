using DataAccess.Postgres.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProject.Models;
using MyProject.Models.IService;

namespace MyProject.Controllers
{
    public class SubsystemEntitiesController : BaseController
    {

        private readonly ISubsystemService _subsystemService;

        private readonly IParametersService _parametersService;

        private readonly IConnectionService _connectionService;

        public SubsystemEntitiesController(IEquipmentService equipmentService,
            IParametersService parametersService, ISampleService sampleService,
            IUnityService unityService, IPlantService plantService, ISubsystemService subsystemService, ISystemService systemService, IConnectionService connectionService)
            : base(equipmentService, parametersService, sampleService, unityService, plantService, subsystemService, systemService, connectionService)
        {
            _subsystemService = subsystemService;
            _parametersService = parametersService;
            _connectionService = connectionService;
        }

        // GET: SubsystemEntity
        public async Task<IActionResult> Index()
        {
            return View(await _subsystemService.GetAllAsync());
        }

        // GET: SubsystemEntity/Create
        public async Task<IActionResult> Create()
        {
            var parametersList = await _parametersService.GetAllAsync();

            // Передаем список параметров в представление
            ViewBag.ParametersList = new SelectList(parametersList, "Id", "Name");
            return View();
        }

        // POST: SubsystemEntity/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubsystemEntity subsystemEntity, List<int> parametersIds)
        {
            if (ModelState.IsValid)
            {
                await _subsystemService.Create(subsystemEntity);
                // Привязка выбранных параметров к системе
                await _connectionService.AttachParametersToSubsystem(subsystemEntity.Id, parametersIds);
                return RedirectToAction(nameof(Index));
            }

            var parametersList = await _parametersService.GetAllAsync();

            // Передаем список параметров в представление
            ViewBag.ParametersList = new SelectList(parametersList, "Id", "Name");
            return View(subsystemEntity);
        }

        // GET: SubsystemEntity/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _subsystemService.FindById(id));
        }

        // POST: SubsystemEntity/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Description")] SubsystemEntity subsystemEntity)
        {
            if (id != subsystemEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _subsystemService.EditPost(subsystemEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_subsystemService.SubsystemEntityExists(subsystemEntity.Id))
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
            return View(subsystemEntity);
        }

        // POST: EquipmentEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _subsystemService.DeleteConfirmed(id);
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
                var subsystemEntity = await _subsystemService.FindById(id);
                if (subsystemEntity != null)
                {
                    await _subsystemService.DeleteConfirmed(id); // Удалить каждое устройство по ID
                }
            }

            return RedirectToAction(nameof(Index)); // Перенаправление на главную страницу
        }
    }
}
