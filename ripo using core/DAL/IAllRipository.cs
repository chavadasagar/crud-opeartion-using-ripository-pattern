using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_using_ripository_pattern.DAL
{
    interface IAllRipository<T> where T : class
    {
        IEnumerable<T> All();
        void InsertModel(T model);
        void UpdateModel(T model);
        void DeleteModel(int id);
        T getModel(int modelid);
        void save();
        IQueryable<T> spexecution(string SpName, params object[] parameters);

    }
}
