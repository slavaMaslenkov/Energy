using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Entity
{
    public class SubsystemEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Тип")]
        public string Type { get; set; } = string.Empty;

        [Display(Name = "Описание")]
        public string? Description { get; set; } = string.Empty;

        public ICollection<SystemEntity>? System { get; set; }

        public ICollection<ConnectionEntity>? Connection { get; set; }
    }
}
