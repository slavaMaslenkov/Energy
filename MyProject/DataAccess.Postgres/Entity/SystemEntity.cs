using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Entity
{
    public class SystemEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EquipmentID { get; set; }

        public int SubsystemID { get; set; }

        public EquipmentEntity? Equipment { get; set; }

        public SubsystemEntity? Subsystem { get; set; }

        public ICollection<SampleEntity>? Sample { get; set; }
    }
}
