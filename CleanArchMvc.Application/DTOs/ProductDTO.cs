using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [Display(Name = "Name")]
        public string Name { get;  set; }
        
        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "The Price is Required")]
        [Column(TypeName ="decimal(18,12)")]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        [DataType(DataType.Currency)]
        [Display(Name ="Price")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
