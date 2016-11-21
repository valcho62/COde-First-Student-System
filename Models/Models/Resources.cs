using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public enum TypeResource
    {
        Video,Presentation,Document,Other
    }
    public class Resources
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

       [Required]
        public TypeResource TypeResource { get; set; }
        [Required]
        public string URL { get; set; }

        public ICollection<Courses> Cources { get; set; }
        public ICollection<License> Licenses { get; set; }

    }
}