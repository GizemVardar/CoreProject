using Demo.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.DAL.Abstract
{
    public interface IProductDal:IEntityRepository<Products>
    {

        //özel operasyonlarımızı bu ınterface içerisinde yazabiliriz ornegin bir view yada sp,fn gibi operasyonumuz var ise burada kullanmamız dogru olacaktır. tabiki bu projenin işleviyle alakalıdır. 


    }
}
