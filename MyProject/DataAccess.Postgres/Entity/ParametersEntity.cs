﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Entity
{
    public class ParametersEntity
    {

        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Measure { get; set; } = string.Empty;

        public ICollection<UnityEntity> Unity { get; set; }
    }
}
