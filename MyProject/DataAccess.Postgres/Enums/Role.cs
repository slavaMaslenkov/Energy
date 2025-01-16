using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Postgres.Enums
{
    public enum Role
    {
        Admin = 1,

        [Description("АО «СО ЕЭС»")]
        User1 = 2,

        [Description("Собственник")]
        User2 = 3,

        [Description("Гость")]
        User3 = 4,
    }
}
