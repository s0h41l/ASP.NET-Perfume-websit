using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scentasy.Models
{
    public class CustomCartViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public string Size { get; set; }
        public int? ScentId { get; set; }
        public List<Scent> ScentList = new List<Scent>();
    }
}