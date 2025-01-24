using DataAccess.Postgres.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProject.Models;
using MyProject.Models.IService;
using System.Numerics;
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

        private readonly IRoleService _roleService;

        private readonly IRightService _rightService;

        public UnityEntitiesController(IEquipmentService equipmentService,
            IParametersService parametersService, ISampleService sampleService, IUnityService unityService, 
            IPlantService plantService, ISubsystemService subsystemService, ISystemService systemService, 
            IConnectionService connectionService, IUserService userService, IRoleService roleService, IRightService rightService)
            : base(equipmentService, parametersService, sampleService, unityService, plantService, 
                  subsystemService, systemService, connectionService, userService, roleService, rightService)
        {
            _unityService = unityService;
            _parametersService = parametersService;
            _sampleService = sampleService;
            _subsystemService = subsystemService;
            _systemService = systemService;
            _equipmentService = equipmentService;
            _connectionService = connectionService;
            _roleService = roleService;
            _rightService = rightService;
        }

        // GET: UnityEntities
        public async Task<IActionResult> Index(int? sampleId = null)
        {
            var parametersList = await _parametersService.GetAllAsync();
            var sampleList = await _sampleService.GetAllAsync();
            var subsystemList = await _subsystemService.GetAllAsync();
            var roleList = await _roleService.GetAllAsync();

            ViewBag.ParametersList = new SelectList(parametersList, "Id", "Name");
            ///ViewBag.SampleList = new SelectList(sampleList, "Id", "Name");
            ViewBag.SubsystemList = new SelectList(subsystemList, "Id", "Name");
            ViewBag.RoleList = new SelectList(roleList, "Id", "Name");

            return View();
        }

        // GET: UnityEntities/Create
        [HttpGet]
        public async Task<IActionResult> Create(int equipmentId, int sampleId)
        {
            var roleList = await _roleService.GetAllAsyncWithoutAdmin();
            var sampleList = await _sampleService.GetByFilter(equipmentId);
            var subsystemList = await _systemService.GetAllByEquipment(equipmentId);

            ViewBag.RoleList = new SelectList(roleList, "Id", "Name");
            ViewBag.SampleList = new SelectList(sampleList, "Id", "Name");
            ViewBag.SubsystemList = new SelectList(subsystemList.Select(s => s.Subsystem), "Id", "Name");
            ViewBag.DeviceId = equipmentId;
            ViewBag.SampleId = sampleId;
            return View();
        }

        // POST: UnityEntities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UnityEntity unityEntity, int equipmentId, int subsystemId, int parameterId, int roleId, int sampleId)
        {
            if (ModelState.IsValid)
            {
                ViewBag.DeviceId = equipmentId;
                ViewBag.SampleId = sampleId;
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

                // Привязка выбранных ролей к параметру
                await _rightService.AttachRoleToUnity(unityEntity.Id, roleId);

                // Перенаправление на другую страницу (например, устройство)
                return RedirectToAction(nameof(DeviceUnity), new { equipmentId, sampleId });
            }

            // Повторная загрузка списка при ошибке валидации
            var parametersList = await _parametersService.GetAllAsync();
            var sampleList = await _sampleService.GetAvailableAsync();
            var subsystemList = await _subsystemService.GetByEquipmentIdAsync(equipmentId);
            var roleList = await _roleService.GetAllAsyncWithoutAdmin();

            ViewBag.ParametersList = new SelectList(parametersList, "Id", "Name");
            ViewBag.SampleList = new SelectList(sampleList, "Id", "Name");
            ViewBag.SubsystemList = new SelectList(subsystemList, "Id", "Name");
            ViewBag.RoleList = new SelectList(roleList, "Id", "Name");
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
        public async Task<IActionResult> DeleteConfirmed(int id, int equipmentId)
        {
            await _unityService.DeleteConfirmed(id);
            return RedirectToAction(nameof(DeviceUnity), new { equipmentId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSelected(string ids, int equipmentId)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return RedirectToAction(nameof(DeviceUnity), new { equipmentId });
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

                return RedirectToAction(nameof(DeviceUnity), new { equipmentId });
            }
            catch (Exception ex)
            {
                return View("Error", new { message = "Ошибка при удалении выбранных элементов." });
            }
        }

        public async Task<IActionResult> DeviceUnity(int equipmentId, int? sampleId = null)
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
                return RedirectToAction("Create", "UnityEntities", new { equipmentId, sampleId });
            }

            var nameDevice = await _equipmentService.FindById(equipmentId);
            ViewBag.nameDevice = nameDevice.Name;

            ViewBag.SampleId = sampleId;

            var sampleAdd = await _sampleService.FindById(sampleId);
            ViewBag.sampleStatus = sampleAdd.Status;

            ViewBag.DeviceId = equipmentId;
            /////////////////////////////
            var sampleList = await _sampleService.GetByFilter(equipmentId);

            ViewBag.Samples = sampleList.Select(sampleList => new SelectListItem
            {
                Value = sampleList.Id.ToString(),
                Text = $"{sampleList.Name} - {sampleList.DateCreated:dd.MM.yy}"
            }).ToList();

            var selectedSampleId = sampleId ?? null;
            ViewBag.SelectedSampleId = selectedSampleId;
            if (selectedSampleId != null)
            {
                unityData = await _unityService.GetBySampleIdAsync(selectedSampleId);
            }

            return View("Index", unityData);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateValues(Dictionary<int, string> values, int id)
        {
            await _unityService.UpdateValues(values);
            var unityData = await _unityService.GetByFilter(id);
            ///ViewBag.DeviceId = id;
            return RedirectToAction(nameof(DeviceUnity), new { id });
        }

    }
}
