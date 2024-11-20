﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class BaseController : Controller
    {
        private readonly IEquipmentService _equipmentService;

        private readonly IParametersService _parametersService;

        private readonly ISampleService _sampleService;

        public BaseController(IEquipmentService equipmentService,
            IParametersService parametersService, ISampleService sampleService)
        {
            _equipmentService = equipmentService;
            _parametersService = parametersService;
            _sampleService = sampleService;
        }

        /// Метод необходим для выполнения базовой логики базового контроллера./>.
        /// <summary>
        public override void OnActionExecuting(ActionExecutingContext dbContext)
        {
            base.OnActionExecuting(dbContext);

            // Загружаем устройства и добавляем их в ViewBag
            var devices = _equipmentService.GetDeviceNamesAsync().Result;
            ViewBag.Devices = devices ?? new List<string>();
        }
    }
}
