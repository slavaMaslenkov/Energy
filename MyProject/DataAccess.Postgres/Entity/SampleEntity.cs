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



        public EquipmentEntity Equipment { get; set; }

        public ICollection<UnityEntity> Unity { get; set; }
    }
}
