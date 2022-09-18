using Demo.Core.Entities.Concrete;
using System.Collections.Generic;

namespace Demo.Core.MvcUI.Models
{
    public class ProductUpdateViewModel
    {

        public List<Categories> Categories { get; set; }
        public Products Products { get; set; }

    }
}
