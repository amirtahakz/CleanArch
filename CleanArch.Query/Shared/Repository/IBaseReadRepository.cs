﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Shared.Repository
{
    public interface IBaseReadRepository<TEntity> where TEntity : BaseReadModel
    {
        Task Delete(Guid id);

        Task<List<TEntity>> GetAll();

        Task<TEntity> GetById(Guid id);

        Task Insert(TEntity entity);

        Task Update(TEntity entity);
    }
}
