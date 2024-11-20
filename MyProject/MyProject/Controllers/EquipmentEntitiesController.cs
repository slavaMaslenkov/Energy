﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Postgres;
using DataAccess.Postgres.Entity;
using MyProject.Models;
using System.Xml.Linq;

namespace MyProject.Controllers
{
    public class EquipmentEntitiesController : BaseController
    {
        /*private readonly DataContext _context;

        public EquipmentEntitiesController(DataContext context)
        {
            _context = context;
        }*/

        private readonly IEquipmentService _equipmentService;

        public EquipmentEntitiesController(IEquipmentService equipmentService) : base(equipmentService) { }

        // GET: EquipmentEntities
        public async Task<IActionResult> Index()
        {
            return View(await _equipmentService.GetAllAsync());
        }

        /*// GET: EquipmentEntities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipmentEntity = await _context.Equipment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipmentEntity == null)
            {
                return NotFound();
            }

            return View(equipmentEntity);
        }*/

        // GET: EquipmentEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EquipmentEntities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EquipmentEntity equipmentEntity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Генерация Guid, если он не задан
                    if (equipmentEntity.Id == Guid.Empty)
                    {
                        equipmentEntity.Id = Guid.NewGuid();
                    }
                    await _equipmentService.Create(equipmentEntity);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex}"); // Вывод полной информации об ошибке
                    ModelState.AddModelError("", $"Ошибка при сохранении данных: {ex.Message}");
                }
            }
            return View(equipmentEntity);
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

        /*// GET: EquipmentEntities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipmentEntity = await _context.Equipment.FindAsync(id);
            if (equipmentEntity == null)
            {
                return NotFound();
            }
            return View(equipmentEntity);
        }

        // POST: EquipmentEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Type,Description,Owner")] EquipmentEntity equipmentEntity)
        {
            if (id != equipmentEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipmentEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentEntityExists(equipmentEntity.Id))
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
            return View(equipmentEntity);
        }*/

        // GET: EquipmentEntities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _equipmentService.Delete(id));
        }

        // POST: EquipmentEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _equipmentService.DeleteConfirmed(id);
            return RedirectToAction(nameof(Index));
        }
        /*
        private bool EquipmentEntityExists(Guid id)
        {
            return _context.Equipment.Any(e => e.Id == id);
        }*/
    }
}
