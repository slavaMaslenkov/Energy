﻿using Microsoft.AspNetCore.Mvc;
using DataAccess.Postgres.Entity;
using MyProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyProject.Controllers
{
    public class EquipmentEntitiesController : BaseController
    {

        private readonly IEquipmentService _equipmentService;

        private readonly IPlantService _plantService;

        public EquipmentEntitiesController(IEquipmentService equipmentService, 
            IParametersService parametersService, ISampleService sampleService, IUnityService unityService, IPlantService plantService) 
            : base(equipmentService, parametersService, sampleService, unityService, plantService) 
        {
            _equipmentService = equipmentService;
            _plantService = plantService;
        }

        // GET: EquipmentEntities
        public async Task<IActionResult> Index()
        {
            return View(await _equipmentService.GetAllAsync());
        }

        // GET: EquipmentEntities/Create
        public async Task<IActionResult> Create()
        {
            var plantList = await _plantService.GetAllAsync();
            ViewBag.PlantList = new SelectList(plantList, "Id", "Name");
            return View();
        }

        // POST: EquipmentEntities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EquipmentEntity equipmentEntity)
        {
            if (ModelState.IsValid)
            {
                 await _equipmentService.Create(equipmentEntity);
                 return RedirectToAction(nameof(Index));
            }
            var plantList = await _plantService.GetAllAsync();
            ViewBag.PlanttList = new SelectList(plantList, "Id", "Name");
            return View(equipmentEntity);
        }

        // GET: EquipmentEntities/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var plantList = await _plantService.GetAllAsync();
            ViewBag.PlantList = new SelectList(plantList, "Id", "Name");
            return View(await _equipmentService.FindById(id));
        }

        // POST: EquipmentEntities/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Description,PlantID")] EquipmentEntity equipmentEntity)
        {
            if (id != equipmentEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _equipmentService.EditPost(equipmentEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_equipmentService.EquipmentEntityExists(equipmentEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var plantList = await _plantService.GetAllAsync();
            ViewBag.PlantList = new SelectList(plantList, "Id", "Name");
            return View(equipmentEntity);
        }
        
        // POST: EquipmentEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _equipmentService.DeleteConfirmed(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSelected(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return RedirectToAction(nameof(Index));
            }

            var idList = ids.Split(',').Select(int.Parse).ToList();

            foreach (var id in idList)
            {
                var equipmentEntity = await _equipmentService.FindById(id);
                if (equipmentEntity != null)
                {
                    await _equipmentService.DeleteConfirmed(id); // Удалить каждое устройство по ID
                }
            }

            return RedirectToAction(nameof(Index)); // Перенаправление на главную страницу
        }
    }
}
