using Demo.Core.Entities.Concrete;
using System.Collections.Generic;

namespace Demo.Core.MvcUI.Models
{
    public class ProductListViewModel
    {
        public int CurrentCategory { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public List<Products> Products { get; set; }
    }
}
