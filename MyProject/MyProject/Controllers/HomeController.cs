using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System.Diagnostics;

namespace MyProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEquipmentService _equipmentService;

        public HomeController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }
        public async Task<IActionResult> MainPage()
        {
            // Получение списка устройств из базы данных
            var devices = await _equipmentService.GetDeviceNamesAsync();
            Console.WriteLine("Привет ");
            // Передача списка в ViewBag
            ViewBag.Devices = devices;
            return View();
        }
    }
}
