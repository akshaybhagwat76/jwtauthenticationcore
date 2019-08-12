
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.Entities
{
    public class SubMenus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubMenuID { get; set; }
        [Required, StringLength(200)]
        public string SubMenuName { get; set; }

        public int MenuID { get; set; }
        [ForeignKey("MenuID")]
        public virtual Menus Menu { get; set; }

        public string URL { get; set; }
    }
}
