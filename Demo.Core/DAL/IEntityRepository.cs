using Demo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Demo.Core.DAL
{
    public interface IEntityRepository<T>where T : class,IEntity,new()
    {


        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        //Expression içerisinde ToList(),SingleOrDefault(),FirstOrDefault gibi metotları barındıran classtır. Func ise bir delegedir metotu temsil eder. burada esas ana amacımız x=>x.UrunId=Id gibi lambda expression kullanmamıza olanak saglamaktadır...
        //T tipi dememimizin sebebi generic mimari olmasından dolayıdır buraya T tipindeki dedigimiz class olmalıdır bu class Urunler,Kategoriler gibi nesneler olmalıdır. Add(T entity) T yerine gelecek olan nesne Urunler yada Kategorilerdir.Urunlere Ekleme yapacagız bu yapıyı tüm nesnelerimiz icin kullanabiliriz ama sadece IEntity olan nesneler IEntity Products ve Categoriese implemente edilmiştir. baska bir class yazdıgımızda kabul etmyeecektir. cunku IEntityden türetilmemiştir. 
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
