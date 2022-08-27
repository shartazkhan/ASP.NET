using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRepository<T, ID>
    {
        void Add(T e); 
        void Edit(T e);
        void Delete(ID id);
        T Get(ID id);
        List<T> Get();
    }
}
