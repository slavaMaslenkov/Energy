using System;
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

        public int ConnectionID { get; set; }

        public int SampleID { get; set; }

        [Display(Name = "Значение")]
        public string? Value { get; set; }

        [Display(Name = "Диапазон изменения")]
        public string? Range { get; set; }

        [Display(Name = "Доступ к изменению")]
        public string? Access { get; set; }

        public ConnectionEntity? Connection { get; set; }

        public SampleEntity? Sample { get; set; }
    }
}
