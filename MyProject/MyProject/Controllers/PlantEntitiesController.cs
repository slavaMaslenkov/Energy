using DataAccess.Postgres.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class PlantEntitiesController : BaseController
    {

        private readonly IPlantService _plantService;

        public PlantEntitiesController(IEquipmentService equipmentService,
            IParametersService parametersService, ISampleService sampleService, 
            IUnityService unityService, IPlantService plantService, ISubsystemService subsystemService, ISystemService systemService)
            : base(equipmentService, parametersService, sampleService, unityService, plantService, subsystemService, systemService)
        {
            _plantService = plantService;
        }

        // GET: PlantEntity
        public async Task<IActionResult> Index()
        {
            return View(await _plantService.GetAllAsync());
        }

        // GET: PlantEntity/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlantEntity/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlantEntity plantEntity)
        {
            if (ModelState.IsValid)
            {
                await _plantService.Create(plantEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(plantEntity);
        }

        // GET: PlantEntity/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _plantService.FindById(id));
        }

        // POST: PlantEntity/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Control,Owner")] PlantEntity plantEntity)
        {
            if (id != plantEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _plantService.EditPost(plantEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_plantService.PlantEntityExists(plantEntity.Id))
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
            return View(plantEntity);
        }

        // POST: PlantEntity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _plantService.DeleteConfirmed(id);
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
                var plantEntity = await _plantService.FindById(id);
                if (plantEntity != null)
                {
                    await _plantService.DeleteConfirmed(id); // Удалить каждое устройство по ID
                }
            }

            return RedirectToAction(nameof(Index)); // Перенаправление на главную страницу
        }
    }
}
