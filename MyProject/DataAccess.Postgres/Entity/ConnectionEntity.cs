using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Entity
{
    public class ConnectionEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ParametersID { get; set; }

        public int SubsystemID { get; set; }

        public ParametersEntity? Parameters { get; set; }

        public SubsystemEntity? Subsystem { get; set; }

        public ICollection<UnityEntity>? Unity { get; set; }
    }
}
