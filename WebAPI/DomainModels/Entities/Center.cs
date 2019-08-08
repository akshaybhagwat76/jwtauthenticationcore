using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DomainModels.Entities
{
    public class Center
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CenterId { get; set; }
        [Required, StringLength(200)]
        public string CenterName { get; set; }
        public string Address { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
