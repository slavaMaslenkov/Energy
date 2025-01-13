using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Entity
{
    public class UserEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Логин")]
        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        [Display(Name = "Имя")]
        public string PersonName { get; set; } = string.Empty;

        [Display(Name = "Фамилия")]
        public string PersonSurname { get; set; } = string.Empty;

        [Display(Name = "Отчество")]
        public string PersonPatronymic { get; set; } = string.Empty;

        public int RoleID { get; set; }

        public RoleEntity? Role { get; set; }
    }
}
