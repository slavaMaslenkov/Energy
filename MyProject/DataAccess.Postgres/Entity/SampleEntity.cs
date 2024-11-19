using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Entity
{
    public class SampleEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public string Name { get; set; } = string.Empty;

        public Guid EquipmentID { get; set; }

        public EquipmentEntity Equipment { get; set; }

        public ICollection<UnityEntity> Unity { get; set; }
    }
}
