using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Entity
{
    public class PlantEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "ДУ")]
        public string Control { get; set; } = string.Empty;

        [Display(Name = "Собственник")]
        public string Owner { get; set; } = string.Empty;

        public ICollection<EquipmentEntity>? Equipment { get; set; }
    }
}
