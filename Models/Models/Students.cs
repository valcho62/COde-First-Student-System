using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class Students
    {
        public Students()
        {
           
            this.Cources = new HashSet<Courses>(); ;
        }

        
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }

        public DateTime? BirthDay { get; set; }
        public virtual ICollection<Courses> Cources { get; set; }

    }
}