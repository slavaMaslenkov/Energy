using DataAccess.Postgres.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class UnityEntitiesController : BaseController
    {
        private readonly IUnityService _unityService;

        private readonly ISampleService _sampleService;

        private readonly IParametersService _parametersService;

        public UnityEntitiesController(IEquipmentService equipmentService,
            IParametersService parametersService, ISampleService sampleService, IUnityService unityService)
            : base(equipmentService, parametersService, sampleService, unityService)
        {
            _unityService = unityService;
            _parametersService = parametersService;
            _sampleService = sampleService;
        }

        // GET: UnityEntities
        public async Task<IActionResult> Index()
        {
            var parametersList = await _parametersService.GetAllAsync();
            var sampleList = await _sampleService.GetAllAsync();
            // Загрузка списка параметров
            ViewBag.ParametersList = new SelectList(parametersList, "Id", "Name");
            // Загрузка списка шаблонов
            ViewBag.SampleList = new SelectList(sampleList, "Id", "Name");
            return View(await _unityService.GetAllAsync());
        }

        // GET: UnityEntities/Create
        public async Task<IActionResult> Create()
        {
            var parametersList = await _parametersService.GetAllAsync();
            var sampleList = await _sampleService.GetAllAsync();
            // Загрузка списка параметров
            ViewBag.ParametersList = new SelectList(parametersList, "Id", "Name");
            // Загрузка списка шаблонов
            ViewBag.SampleList = new SelectList(sampleList, "Id", "Name");
            return View();
        }

        // POST: UnityEntities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UnityEntity unityEntity)
        {
            if (ModelState.IsValid)
            {
                await _unityService.Create(unityEntity);
                return RedirectToAction(nameof(Index));
            }

            // Повторная загрузка списка оборудования при ошибке валидации
            var parametersList = await _parametersService.GetAllAsync();
            var sampleList = await _sampleService.GetAllAsync();
            ViewBag.ParametersList = new SelectList(parametersList, "Id", "Name");
            // Загрузка списка шаблонов
            ViewBag.SampleList = new SelectList(sampleList, "Id", "Name");
            return View(unityEntity);
        }

        public async Task<IActionResult> DeviceUnity(string deviceName)
        {
            if (string.IsNullOrEmpty(deviceName))
            {
                return NotFound();
            }

            var unityData = await _unityService.GetByFilter(deviceName);

            if (!unityData.Any())
            {
                return NotFound();
            }

            ViewBag.DeviceName = deviceName;
            return View("Index", unityData);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateValues(Dictionary<int, string> values, string deviceName)
        {
            await _unityService.UpdateValues(values);
            var unityData = await _unityService.GetByFilter(deviceName);
            ViewBag.DeviceName = deviceName;
            return View("Index", unityData);
        }

    }
}
