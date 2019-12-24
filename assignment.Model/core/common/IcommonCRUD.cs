using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Model.core.common
{
    public interface IcommonCRUD<T>
    {
        T get();
        

        IEnumerable<T> List();

        void Insert(T data);
        void Update(T data);
     
    }
}
