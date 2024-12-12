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
            IParametersService parametersService, ISampleService sampleService, IUnityService unityService) 
            : base(equipmentService, parametersService, sampleService, unityService)
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
            // Загрузка списка оборудования
            ViewBag.EquipmentList = new SelectList(equipmentList, "Id", "Name");
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
            ViewBag.EquipmentList = new SelectList(equipmentList, "Id", "Name");
            return View(sampleEntity);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateValues(Dictionary<int, bool> values)
        {
            await _sampleService.UpdateValues(values);
            return View("Index");
        }
    }
}
