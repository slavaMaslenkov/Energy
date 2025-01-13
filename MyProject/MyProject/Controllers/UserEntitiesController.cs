using DataAccess.Postgres.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Models.IService;
using MyProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;

namespace MyProject.Controllers
{
    public class UserEntitiesController : BaseController
    {
        private readonly IUserService _userService;

        private readonly IRoleService _roleService;

        public UserEntitiesController(IEquipmentService equipmentService,
            IParametersService parametersService, ISampleService sampleService, IUnityService unityService,
            IPlantService plantService, ISubsystemService subsystemService, ISystemService systemService, 
            IConnectionService connectionService, IUserService userService, IRoleService roleService)
            : base(equipmentService, parametersService, sampleService, unityService, plantService, 
                  subsystemService, systemService, connectionService, userService, roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        // GET: UserEntities
        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetAllAsync());
        }

        // GET: UserEntities/Create
        public async Task<IActionResult> Create()
        {
            var roleList = await _roleService.GetAllAsync();
            ViewBag.RoleList = new SelectList(roleList, "Id", "Name");

            return View();
        }

        // POST: UserEntities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserEntity userEntity)
        {
            if (ModelState.IsValid)
            {
                var passwordHasher = new PasswordHasher<UserEntity>();
                userEntity.Password = passwordHasher.HashPassword(userEntity, userEntity.Password);


                await _userService.Create(userEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(userEntity);
        }

        // POST: UserEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userService.DeleteConfirmed(id);
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
                var userEntity = await _userService.FindById(id);
                if (userEntity != null)
                {
                    await _userService.DeleteConfirmed(id); // Удалить каждое устройство по ID
                }
            }

            return RedirectToAction(nameof(Index)); // Перенаправление на главную страницу
        }

        // GET: UserEntities/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleList = await _roleService.GetAllAsync();
            ViewBag.RoleList = new SelectList(roleList, "Id", "Name");
            return View(await _userService.FindById(id));
        }

        // POST: UserEntities/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,PersonName, PersonSurname, PersonPatronymic, RoleID")] UserEntity userEntities)
        {
            if (id != userEntities.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.EditPost(userEntities);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_userService.UserEntityExists(userEntities.Id))
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
            var roleList = await _roleService.GetAllAsync();
            ViewBag.RoleList = new SelectList(roleList, "Id", "Name");
            return View(userEntities);
        }

        [HttpGet]
        public IActionResult ValidateOldPassword(int userId)
        {
            ViewBag.UserId = userId;
            return View(userId);
        }

        [HttpPost]
        public async Task<IActionResult> ValidateOldPassword(int userId, string oldPassword)
        {
            var user = await _userService.FindById(userId);
            if (user == null)
            {
                ModelState.AddModelError("", "Пользователь не найден.");
                return View();
            }



            var isValid = await _userService.ValidatePasswordAsync(userId, oldPassword);
            if (!isValid)
            {
                ModelState.AddModelError("", "Старый пароль неверен.");
                return View();
            }

            // Сохраняем успешное прохождение проверки
            TempData["PasswordValidated"] = true; // Помечаем, что проверка пройдена
            TempData["UserId"] = userId; // Сохраняем ID пользователя
            return RedirectToAction("ChangePassword");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            // Проверяем, был ли установлен флаг успешной проверки
            if (TempData["PasswordValidated"] == null || !(bool)TempData["PasswordValidated"])
            {
                return RedirectToAction("ValidateOldPassword");
            }

            // Передаём ID пользователя в представление
            ViewBag.UserId = TempData["UserId"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(int userId, string newPassword)
        {
            var user = await _userService.FindById(userId);
            if (user == null)
            {
                ModelState.AddModelError("", "Пользователь не найден.");
                return View();
            }

            await _userService.ChangePasswordAsync(userId, newPassword);
            TempData["SuccessMessage"] = "Пароль успешно изменён.";
            return RedirectToAction("MainPage", "Home");
        }
    }
}
