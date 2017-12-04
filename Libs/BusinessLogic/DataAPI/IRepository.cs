using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLogic.DataAPI
{
    public interface IRepository<TModel>
        where TModel : BaseModel
    {
        void Add(TModel model);
        void AddRange(IEnumerable<TModel> models);
        void Delete(TModel model);
        void DeleteById(object id);
        
        void DeleteRange(IEnumerable<TModel> models);

        IList<TModel> GetAll();
        TModel Get(object id);
        IEnumerable<TModel> Find(Expression<Func<TModel, bool>> predicate);
    }
}
