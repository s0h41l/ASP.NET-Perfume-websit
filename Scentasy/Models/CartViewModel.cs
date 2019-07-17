using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scentasy.Models
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public int? Quantity { get; set; }
        public int? ProductId { get; set; }

        public string ProductName { get; set; }
        public string Image { get; set; }
        public double? Price { get; set; }
    }
}