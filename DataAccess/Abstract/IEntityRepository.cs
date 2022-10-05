using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{   
    //generic constraint 
    //class     : referans tip olabilir anlamına gelir
    //IEntity   : IEntity veya ondan türeyen olabilir
    //new()     : Sadece new lenebilen yani somut nesnelere izin verir, doğrudan IEntity kullanılamaz
    public interface IEntityRepositoryIEntityRepository<T> where T:class,IEntity,new()  /*Burada class şart mı?*/
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter );
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //List<T> GetAllByCategory(int categoryId); //(Expression<Func<T,bool>> filter=null); yazıldığı için bu satır obselete oldu
    }
}
 