using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DomainModels.Entities
{
    public class Class
    {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ClassId { get; set; }
            [Required, StringLength(200)]
            public string ClassName { get; set; }
            [Required]
            public bool IsActive { get; set; }
    }
}
