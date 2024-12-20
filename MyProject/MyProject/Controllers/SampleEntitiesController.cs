using DataAccess.Postgres.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class SampleEntitiesController : BaseController
    {

        private readonly ISampleService _sampleService;

        private readonly IEquipmentService _equipmentService;

        public SampleEntitiesController(IEquipmentService equipmentService, 
            IParametersService parametersService, ISampleService sampleService, IUnityService unityService, 
            IPlantService plantService, ISubsystemService subsystemService, ISystemService systemService) 
            : base(equipmentService, parametersService, sampleService, unityService, plantService, subsystemService, systemService)
        {
            _sampleService = sampleService;
            _equipmentService = equipmentService;
        }

        // GET: SampleEntities
        public async Task<IActionResult> Index()
        {
            return View(await _sampleService.GetAllAsync());
        }

        // GET: SampleEntitiesController/Create
        public async Task<IActionResult> Create()
        {
            var equipmentList = await _equipmentService.GetAllAsync();
            var sampleList = await _sampleService.GetAllAsync();
            // Загрузка списка оборудования
            ViewBag.EquipmentList = new SelectList(equipmentList, "Id", "Name");
            ViewBag.SampleList = new SelectList(sampleList, "EquipmentID", "Name");
            return View();
        }

        // POST: SampleEntities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SampleEntity sampleEntity)
        {
            if (ModelState.IsValid)
            {
                await _sampleService.Create(sampleEntity);
                return RedirectToAction(nameof(Index));
            }

            // Повторная загрузка списка оборудования при ошибке валидации
            var equipmentList = await _equipmentService.GetAllAsync();
            var sampleList = await _sampleService.GetAllAsync();
            ViewBag.EquipmentList = new SelectList(equipmentList, "Id", "Name");
            ViewBag.SampleList = new SelectList(sampleList, "EquipmentID", "Name");
            return View(sampleEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBasedOn(int equipmentID, SampleEntity sampleEntity)
        {
            if (ModelState.IsValid)
            {
                await _sampleService.CreateBasedOn(equipmentID, sampleEntity);
                return RedirectToAction(nameof(Index));
            }

            // Повторная загрузка списка оборудования при ошибке валидации
            var equipmentList = await _equipmentService.GetAllAsync();
            var sampleList = await _sampleService.GetAllAsync();
            ViewBag.EquipmentList = new SelectList(equipmentList, "Id", "Name");
            ViewBag.SampleList = new SelectList(sampleList, "EquipmentID", "Name");
            return View(sampleEntity);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateValues([FromBody] Dictionary<int, bool> values)
        {
            if (values == null || !values.Any())
                return RedirectToAction(nameof(Index));

            // Загружаем текущие статусы и обновляем только измененные
            var currentStatuses = await _sampleService.GetStatusesAsync();
            var updatedStatuses = values
                .Where(kv => currentStatuses[kv.Key] != kv.Value)
                .ToDictionary(kv => kv.Key, kv => kv.Value);

            if (updatedStatuses.Any())
            {
                await _sampleService.UpdateValues(updatedStatuses);
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: SampleEntity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _sampleService.DeleteConfirmed(id);
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
                var sampleEntity = await _sampleService.FindById(id);
                if (sampleEntity != null)
                {
                    await _sampleService.DeleteConfirmed(id); // Удалить каждый шаблон по ID
                }
            }

            return RedirectToAction(nameof(Index)); // Перенаправление на главную страницу
        }
    }
}
