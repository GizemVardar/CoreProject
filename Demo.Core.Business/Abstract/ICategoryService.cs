using Demo.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Business.Abstract
{
    public interface ICategoryService
    {
        List<Categories> GetAll();
        //projeye devam etmek isteyen arkadaslar projeyi drive yukledikten sonra buradaki operasyonları ödev olarak yazmalıdırlar.
    }
}
