﻿using DataAccess.Postgres.Entity;

namespace MyProject.Models
{
    public interface ISampleService
    {
        /// <summary>
        /// Метод добавляет экзмепляр класса SampleEntity в БД./>.
        /// <summary>
        /// <param name="sampleEntity">Имя шаблона.</param>
        /// <returns>Экземпляр класса SampleEntity/>.</returns>
        Task<SampleEntity> Create(SampleEntity sampleEntity);

        /// <summary>
        /// Метод создает список экзмепляров класса UnityEntity на основе 
        /// другого экземпляра./>.
        /// <summary>
        /// <param name="equipmentID">Имя шаблона.</param>
        /// <returns>Экземпляр класса SampleEntity/>.</returns>
        Task<SampleEntity> CreateBasedOn(int equipmentID, SampleEntity sampleEntity);

        /// <summary>
        /// Метод получает все шаблоны из БД./>.
        /// </summary>
        /// <returns>Лист SampleEntity/>.</returns>
        Task<IEnumerable<SampleEntity>> GetAllAsync();

        /// <summary>
        /// Метод получает шаблоны из БД со статусом "В редакции"/>.
        /// </summary>
        /// <returns>Лист SampleEntity/>.</returns>
        Task<IEnumerable<SampleEntity>> GetAvailableAsync();

        /// <summary>
        /// Метод получает шаблоны определенного устройства./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Возвращает таблицу Sample по опрделенному шаблону./>.</returns>
        Task<List<SampleEntity>> GetByFilter(int id);

        /// <summary>
        /// Метод обновляет статус шаблона./>.
        /// <summary>
        /// <param name="values">Словарь объектов.</param>
        Task UpdateValues(Dictionary<int, bool> values);

        /// <summary>
        /// Метод получает статусы шаблона./>.
        /// <summary>
        /// <returns>Возвращает словарь ID:Status./>.</returns>
        Task<Dictionary<int, bool>> GetStatusesAsync();

        /// <summary>
        /// Метод поиска экземпляра по id.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса SampleEntity/>.</returns>
        Task<SampleEntity> FindById(int? id);

        /// <summary>
        /// Метод удаляет экзмепляр класса SampleEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        Task DeleteConfirmed(int? id);
    }
}
