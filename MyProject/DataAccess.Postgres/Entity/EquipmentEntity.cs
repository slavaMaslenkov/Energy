using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Entity
{
    public class EquipmentEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Owner { get; set; } = string.Empty;

        public ICollection<SampleEntity> Sample { get; set; }
    }
}
