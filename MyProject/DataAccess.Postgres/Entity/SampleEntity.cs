using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Entity
{
    public class SampleEntity
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public string Name { get; set; } = string.Empty;

        public Guid EquipmentID { get; set; }

        public EquipmentEntity Equipment { get; set; }

        public ICollection<UnityEntity> Unity { get; set; }
    }
}
