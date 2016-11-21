using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class Courses
    {
        public Courses( )
        {
            
            this.Students = new HashSet<Students>();
            this.Resources = new HashSet<Resources>();
            this.HomeWorks = new HashSet<HomeWork>();
        }

        
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<Students> Students { get; set; }
        public virtual ICollection<Resources> Resources { get; set; }
        public virtual ICollection<HomeWork> HomeWorks { get; set; }

    }
}