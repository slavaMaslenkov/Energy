using DataAccess.Postgres.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProject.Models;
using MyProject.Models.IService;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace MyProject.Controllers
{
    public class UnityEntitiesController : BaseController
    {
        private readonly IUnityService _unityService;

        private readonly ISampleService _sampleService;

        private readonly IParametersService _parametersService;

        private readonly ISubsystemService _subsystemService;

        private readonly ISystemService _systemService;

        private readonly IEquipmentService _equipmentService;

        private readonly IConnectionService _connectionService;

        public UnityEntitiesController(IEquipmentService equipmentService,
            IParametersService parametersService, ISampleService sampleService, IUnityService unityService, 
            IPlantService plantService, ISubsystemService subsystemService, ISystemService systemService, IConnectionService connectionService)
            : base(equipmentService, parametersService, sampleService, unityService, plantService, subsystemService, systemService, connectionService)
        {
            _unityService = unityService;
            _parametersService = parametersService;
            _sampleService = sampleService;
            _subsystemService = subsystemService;
            _systemService = systemService;
            _equipmentService = equipmentService;
            _connectionService = connectionService;
        }

        // GET: UnityEntities
        public async Task<IActionResult> Index()
        {
            var parametersList = await _parametersService.GetAllAsync();
            var sampleList = await _sampleService.GetAllAsync();
            var subsystemList = await _subsystemService.GetAllAsync();

            ViewBag.ParametersList = new SelectList(parametersList, "Id", "Name");
            ViewBag.SampleList = new SelectList(sampleList, "Id", "Name");
            ViewBag.SubsystemList = new SelectList(subsystemList, "Id", "Name");
            return View(await _unityService.GetAllAsync());
        }

        // GET: UnityEntities/Create
        [HttpGet]
        public async Task<IActionResult> Create(int equipmentId)
        {
            var sampleList = await _sampleService.GetByFilter(equipmentId);
            var subsystemList = await _systemService.GetAllByEquipment(equipmentId);

            ViewBag.SampleList = new SelectList(sampleList, "Id", "Name");
            ViewBag.SubsystemList = new SelectList(subsystemList.Select(s => s.Subsystem), "Id", "Name");
            ViewBag.DeviceId = equipmentId;
            return View();
        }

        // POST: UnityEntities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UnityEntity unityEntity, int equipmentId, int subsystemId, int parameterId)
        {
            if (ModelState.IsValid)
            {
                ViewBag.DeviceId = equipmentId;
                // Получаем ConnectionID из таблицы Connection на основе выбранных параметров
                var connection = await _connectionService.GetConnectionBySubsystemAndParameterAsync(subsystemId, parameterId);

                if (connection == null)
                {
                    // Обработать случай, если связь не найдена (например, вернуться с ошибкой или уведомлением)
                    ModelState.AddModelError(string.Empty, "Не удалось найти связь между подсистемой и параметром.");
                    return View(unityEntity);
                }

                // Устанавливаем найденное ConnectionID в unityEntity
                unityEntity.ConnectionID = connection.Id;

                // Создание новой сущности UnityEntity
                await _unityService.Create(unityEntity);

                // Перенаправление на другую страницу (например, устройство)
                return RedirectToAction(nameof(DeviceUnity), new { equipmentId });
            }

            // Повторная загрузка списка при ошибке валидации
            var parametersList = await _parametersService.GetAllAsync();
            var sampleList = await _sampleService.GetAvailableAsync();
            var subsystemList = await _subsystemService.GetByEquipmentIdAsync(equipmentId);

            ViewBag.ParametersList = new SelectList(parametersList, "Id", "Name");
            ViewBag.SampleList = new SelectList(sampleList, "Id", "Name");
            ViewBag.SubsystemList = new SelectList(subsystemList, "Id", "Name");
            ViewBag.EquipmentId = equipmentId;

            return View(unityEntity);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetParametersBySubsystem(int subsystemId)
        {
            var connectionList = await _connectionService.GetParametersBySubsystem(subsystemId);

            return Json(connectionList);
        }
        
        // POST: UnityEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unityService.DeleteConfirmed(id);
            return RedirectToAction(nameof(DeviceUnity), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSelected(string ids, int deviceId)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return RedirectToAction(nameof(DeviceUnity), new { deviceId });
            }

            try
            {
                // Преобразуем строку с ID в список чисел
                var idList = ids.Split(',')
                                .Where(id => int.TryParse(id, out _))
                                .Select(int.Parse)
                                .ToList();

                foreach (var id in idList)
                {
                    var unityEntity = await _unityService.FindById(id);
                    if (unityEntity != null)
                    {
                        await _unityService.DeleteConfirmed(id); // Удаляем UnityEntity
                    }
                }

                return RedirectToAction(nameof(DeviceUnity), new { deviceId });
            }
            catch (Exception ex)
            {
                return View("Error", new { message = "Ошибка при удалении выбранных элементов." });
            }
        }

        public async Task<IActionResult> DeviceUnity(int equipmentId)
        {
            if (string.IsNullOrEmpty(equipmentId.ToString()))
            {
                return View("Error");
            }

            var unityData = await _unityService.GetByFilter(equipmentId);
            var sampleData = await _sampleService.GetByFilter(equipmentId);

            if (!sampleData.Any())
            {
                return RedirectToAction("Create", "SampleEntities");
            }
            if (!unityData.Any())
            {
                return RedirectToAction("Create", "UnityEntities", new { equipmentId });
            }

            var nameDevice = await _equipmentService.FindById(equipmentId);
            ViewBag.nameDevice = nameDevice.Name;

            ViewBag.DeviceId = equipmentId;
            return View("Index", unityData);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateValues(Dictionary<int, string> values, int id)
        {
            await _unityService.UpdateValues(values);
            var unityData = await _unityService.GetByFilter(id);
            ViewBag.DeviceId = id;
            return View("Index", unityData);
        }

    }
}
