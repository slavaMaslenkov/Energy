using DataAccess.Postgres.Entity;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class SampleEntitiesController : BaseController
    {

        private readonly IParametersService _sampleService;

        public SampleEntitiesController(ISampleService sampleService) : base(sampleService) { }

        // GET: ParametersEntities
        public async Task<IActionResult> Index()
        {
            return View(await _sampleService.GetAllAsync());
        }

        // GET: ParametersEntitiesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParametersEntities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SampleEntity sampleEntity)
        {
            if (ModelState.IsValid)
            {
                await _sampleService.Create(sampleEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(sampleEntity);
        }
    }
}
