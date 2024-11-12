using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Entity
{
    public class UnityEntity
    {
        public Guid Id { get; set; }

        public string ParameterID { get; set; }

        public string SampleID { get; set; }

        public float Value { get; set; }

        public ParametersEntity Parameter { get; set; }
        public SampleEntity Sample { get; set; }
    }
}
