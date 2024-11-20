using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            return View(await _unityService.GetAllAsync());
        }

        // GET: UnityEntitiesController/Create
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

    }
}
