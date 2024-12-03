﻿using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Repositories;

namespace MyProject.Models
{
    internal class ParametersService(IParametersRepository parametersRepository) : IParametersService
    {
        /// <summary>
        /// Метод добавляет экзмепляр класса ParametersEntity в БД./>.
        /// <summary>
        /// <param name="parametersEntity">Имя объекта.</param>
        /// <returns>Экземпляр класса ParametersEntity/>.</returns>
        public async Task<ParametersEntity> Create(ParametersEntity parametersEntity)
        {
            return await parametersRepository.Create(parametersEntity);
        }

        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист ParametersEntity/>.</returns>
        public async Task<IEnumerable<ParametersEntity>> GetAllAsync()
        {
            return await parametersRepository.GetAllAsync();
        }

        /// <summary>
        /// Метод ищет экзмепляр класса ParametersEntity в БД по id./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса ParametersEntity/>.</returns>
        public async Task<ParametersEntity> Delete(Guid? id)
        {
            return await parametersRepository.Delete(id);
        }

        /// <summary>
        /// Метод удаляет экзмепляр класса ParametersEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        public async Task DeleteConfirmed(Guid? id)
        {
            await parametersRepository.DeleteConfirmed(id);
        }

        /// <summary>
        /// Метод получения возможности редактирования.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса ParametersEntity/>.</returns>
        public async Task<ParametersEntity> Edit(Guid? id)
        {
            return await parametersRepository.Edit(id);
        }

        /// <summary>
        /// Метод редактирования экземпляра ParametersEntity.
        /// <summary>
        /// <param name="parametersEntity">Имя объекта.</param>
        public async Task EditPost(ParametersEntity parametersEntity)
        {
            await parametersRepository.EditPost(parametersEntity);
        }

        /// <summary>
        /// Метод проверки наличия экземпляра.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Булевое значение/>.</returns>
        public bool ParametersEntityExists(Guid id)
        {
            return parametersRepository.ParametersEntityExists(id);
        }
    }
}
