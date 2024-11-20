﻿using DataAccess.Postgres.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class ParametersEntitiesController : BaseController
    {

        private readonly IParametersService _parametersService;

        public ParametersEntitiesController(IParametersService parametersService) : base(parametersService) { }

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
                await _parametersService.Create(parametersEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(parametersEntity);
        }
    }
}
