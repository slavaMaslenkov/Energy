using DataAccess.Postgres.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class ParametersEntitiesController : Controller
    {

        private readonly IParametersService _parametersService;

        public ParametersEntitiesController(IParametersService parametersService)
        {
            _parametersService = parametersService;
        }

        // GET: ParametersEntities
        public async Task<IActionResult> Index()
        {
            return View(await _parametersService.GetAllAsync());
        }

        // GET: ParametersEntitiesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParametersEntities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ParametersEntity parametersEntity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Генерация Guid, если он не задан
                    if (parametersEntity.Id == Guid.Empty)
                    {
                        parametersEntity.Id = Guid.NewGuid();
                    }
                    await _parametersService.Create(parametersEntity);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex}"); // Вывод полной информации об ошибке
                    ModelState.AddModelError("", $"Ошибка при сохранении данных: {ex.Message}");
                }
            }
            return View(parametersEntity);
        }




    }
}
