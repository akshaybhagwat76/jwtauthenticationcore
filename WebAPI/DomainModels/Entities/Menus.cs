using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.Entities
{
    public class Menus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuID { get; set; }
        [Required, StringLength(200)]
        public string MenuName { get; set; }
    }
}
