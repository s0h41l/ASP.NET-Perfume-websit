using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Scentasy.Models.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? TypeId { get; set; }
        public string Type { get; set; }
        [Required]
        public double? Price { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public string Photo { get; set; }
    }
}