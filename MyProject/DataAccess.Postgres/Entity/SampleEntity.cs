using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Entity
{
    public class SampleEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; } = DateTime.Now.ToUniversalTime();

        [Display(Name = "Шаблон")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Статус")]
        public bool Status { get; set; } = true;

        public int EquipmentID { get; set; }

        [Display(Name = "Название")]
        public EquipmentEntity? Equipment { get; set; }

        public ICollection<UnityEntity>? Unity { get; set; }
    }
}
