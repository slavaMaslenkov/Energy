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
            // ��������� ������ ��������� �� ���� ������
            var devices = await _equipmentService.GetDeviceNamesAsync();
            Console.WriteLine("������ ");
            // �������� ������ � ViewBag
            ViewBag.Devices = devices;
            return View();
        }
    }
}
