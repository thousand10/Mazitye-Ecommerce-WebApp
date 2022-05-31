using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace mazitye.Models
{
    public class Product
    {
        [Key]
        public int Id { get;set; }
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get;set; }
        [Required]
        [DataType(DataType.Currency)]
        public string? Price { get;set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get;set; }
        // [Required]
        // [DataType(DataType.Upload)]
        // public IFormFile? Image { get;set; }
        
    }
}