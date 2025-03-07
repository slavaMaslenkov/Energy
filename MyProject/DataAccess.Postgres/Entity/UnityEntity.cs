﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Entity
{
    public class UnityEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ParametersID { get; set; }

        public int SampleID { get; set; }

        [Display(Name = "Значение")]
        public string? Value { get; set; }

        public ParametersEntity? Parameters { get; set; }

        public SampleEntity? Sample { get; set; }
    }
}
