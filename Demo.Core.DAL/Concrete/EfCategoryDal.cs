using Demo.Core.DAL.Abstract;
using Demo.Core.DAL.EntityFramework;
using Demo.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.DAL.Concrete
{
    public class EfCategoryDal : EfEntityRepositoryBase<Categories>, ICategoryDal
    {
        public EfCategoryDal(NorthwindContext northwindContext) : base(northwindContext)
        {
        }
    }
}
