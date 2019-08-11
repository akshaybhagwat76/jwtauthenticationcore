using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DomainModels.Entities
{
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        [Required, StringLength(200)]
        public string StudentName { get; set; }
        public int? CenterId { get; set; }
        public virtual Center Center { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int ClassId { get; set; }
        public  virtual Class Class { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
