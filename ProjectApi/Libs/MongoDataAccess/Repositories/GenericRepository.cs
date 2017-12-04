using BusinessLogic.DataAPI;
using BusinessLogic.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MongoDataAccess.Repositories
{
    public class GenericRepository<TModel> : IRepository<TModel> 
        where TModel : BaseModel
    {
        private readonly IMongoCollection<TModel> mongoCollection;

        public GenericRepository(IMongoDatabase database)
        {
            mongoCollection = database.GetCollection<TModel>(typeof(TModel).Name);
        }

        public void Add(TModel model)
        {
            mongoCollection.InsertOne(model);
        }

        public void AddRange(IEnumerable<TModel> models)
        {
            mongoCollection.InsertMany(models);
        }

        public void Delete(TModel model)
        {
            mongoCollection.DeleteOne(u => u.Id.Equals(model.Id));
        }

        public void DeleteById(object id)
        {
            mongoCollection.DeleteOne(u => u.Id.Equals(id));
        }

        public void DeleteRange(IEnumerable<TModel> models)
        {
            foreach (TModel model in models)
            {
                Delete(model);
            }
        }

        public IEnumerable<TModel> Find(Expression<Func<TModel, bool>> predicate)
        {
            return mongoCollection.Find(predicate).ToEnumerable();
        }

        public TModel Get(object id)
        {
            return mongoCollection.Find(u => u.Equals(id)).FirstOrDefault();
        }

        public IList<TModel> GetAll()
        {
           
            return mongoCollection.AsQueryable().ToList();
        }
    }
}
