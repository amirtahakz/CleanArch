﻿using CleanArch.Query.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Shared.Repository
{
    public class BaseReadRepository<TEntity> : IBaseReadRepository<TEntity> where TEntity : BaseReadModel
    {
        protected readonly IMongoCollection<TEntity> _collection;

        public BaseReadRepository(IMongoClient client)
        {
            var database = client.GetDatabase("CleanArch");
            _collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task Delete(Guid id)
        {
            await _collection.DeleteOneAsync(f => f.Id == id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            var res = await _collection.FindAsync(r => true);
            return res.ToList();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            var res = await _collection.FindAsync(f => f.Id == id);
            return res.FirstOrDefault();
        }

        public async Task Insert(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            await _collection.ReplaceOneAsync(f => f.Id == entity.Id, entity);
        }
    }
}
