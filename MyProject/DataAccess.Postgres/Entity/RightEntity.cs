using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Entity
{
    public class RightEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RoleID { get; set; }

        public int UnityID { get; set; }

        public RoleEntity? Role { get; set; }

        public UnityEntity? Unity { get; set; }
    }
}
