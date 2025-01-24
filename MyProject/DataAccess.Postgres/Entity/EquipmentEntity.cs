﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Entity
{
    public class EquipmentEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [Display(Name = "Название")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [Display(Name = "Тип")]
        public string Type { get; set; } = string.Empty;

        [Display(Name = "Описание")]
        public string? Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [Display(Name = "Станция")]
        public int PlantID { get; set; }

        public ICollection<SystemEntity>? System { get; set; }

        public ICollection<SampleEntity>? Sample { get; set; }

        public PlantEntity? Plant { get; set; }
    }
}
