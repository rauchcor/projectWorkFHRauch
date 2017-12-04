using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DataAPI;
using BusinessLogic.Models;

namespace EntityFrameworkDataAccess.Repositories
{
    public class BaseRepository<TEntity>
    {
    } /* : IRepository<TEntity>, ISetContextProvider
        where TEntity : BaseModel
    {
        protected IProvideDbContext<FIFOContext> _contextProvider;

        public BaseRepository()
        {
            
        }

        protected void RunInContext(Action<FIFOContext> dbAction)
        {
            if (dbAction == null)
                throw new ArgumentNullException(nameof(dbAction));

            dbAction(_contextProvider.GetContext());
        }

        protected TReturn RunInContext<TReturn>(Func<FIFOContext, TReturn> dbFunc)
        {
            if (dbFunc == null)
                throw new ArgumentNullException(nameof(dbFunc));

            TReturn retValue = default(TReturn);
            RunInContext((Action<FIFOContext>)(context => { retValue = dbFunc(context); }));
            return retValue;
        }

        public TEntity Add(TEntity model)
        {
            return RunInContext(context => {
                context.Set<TEntity>().Add(model);
                return model;
            });
        }

        public void AddRange(IEnumerable<TEntity> models)
        {
            RunInContext(context => {
                context.Set<TEntity>().AddRange(models);
            });
        }

        public virtual void Delete(TEntity model)
        {
            RunInContext(context => {
                context.Set<TEntity>().Remove(model);
            });
        }

        public virtual void DeleteById(long id)
        {
            RunInContext(context => {
                Delete(Get(id));
            });
        }

        public virtual void DeleteRange(IEnumerable<TEntity> models)
        {
            RunInContext(context => {
                context.Set<TEntity>().RemoveRange(models);
            });
        }

        public virtual TEntity[] GetAll()
        {
            // Note that here I've repeated Context.Set<TEntity>() in every method and this is causing
            // too much noise. I could get a reference to the DbSet returned from this method in the 
            // constructor and store it in a private field like _entities. This way, the implementation
            // of our methods would be cleaner:
            // 
            // _entities.ToList();
            // _entities.Where();
            // _entities.SingleOrDefault();
            // 
            // I didn't change it because I wanted the code to look like the videos. But feel free to change
            // this on your own.
            return RunInContext(context => context.Set<TEntity>().ToArray()) ?? new TEntity[0];
        }

        public virtual TEntity Get(long id)
        {
            // Here we are working with a DbContext, not PlutoContext. So we don't have DbSets 
            // such as Courses or Authors, and we need to use the generic Set() method to access them.
            return RunInContext(context => context.Set<TEntity>().Where(x => x.Id.Equals(id)).SingleOrDefault());
        }

        public TEntity[] Find(Expression<Func<TEntity, bool>> predicate)
        {
            return RunInContext(context => context.Set<TEntity>().Where(predicate)).ToArray() ?? new TEntity[0];
        }

        public virtual void SetContextProvider(IProvideDbContext<FIFOContext> contextProvider)
        {
            _contextProvider = contextProvider ?? throw new ArgumentNullException(nameof(contextProvider));
        }
        
    }*/
}
