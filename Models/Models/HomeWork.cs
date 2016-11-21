using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public enum ContentType
    {
        Aplication,Pdf,Zip
    }
    public class HomeWork
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(100)]
        public string Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }

        [Required]
        public DateTime SubmisionDate { get; set; }

        [Required]
        public virtual Students Student { get; set; }

    }
}