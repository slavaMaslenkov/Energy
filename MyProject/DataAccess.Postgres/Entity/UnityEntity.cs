using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Entity
{
    public class UnityEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public Guid ParametersID { get; set; }

        public Guid SampleID { get; set; }

        public float Value { get; set; }

        public ParametersEntity Parameters { get; set; }

        public SampleEntity Sample { get; set; }
    }
}
