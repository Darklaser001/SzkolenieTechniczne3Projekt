using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using SzkolenieTechniczne.Common.CrossCutting.Enums;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.Common.API.Service
{
    public class CrudServiceBase<TdbContext,TEntity,TDto>
        where TdbContext: DbContext
        where TEntity : BaseEntity
        where TDto : class
    {
        private readonly TdbContext _dbContext;
        protected virtual Task OnBeforeRecordCreateAsync(TdbContext dbContext, TEntity entity) => Task.CompletedTask;
        protected virtual Task OnAfterRecordCreateAsync(TdbContext dbContext, TEntity entity) => Task.CompletedTask;

       public CrudServiceBase(TdbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CrudOperationResult<TDto>> Delete(Guid id)
        {
            var entity = await _dbContext
                .Set<TEntity>()
                .SingleOrDefaultAsync(e => e.Id!.Equals(id));

            if (entity == null) 
            {
                return new CrudOperationResult<TDto>()
                {
                    Status = CrudOperationResultStatus.RecordNotFound,
                };
            }
                
                _dbContext.Set<TEntity>().Remove(entity);

            await _dbContext.SaveChangesAsync();

            return new CrudOperationResult<TDto>
            {
                Status = CrudOperationResultStatus.Success,
            };
        }
        public async Task<Guid> Create(TEntity entity)
        {
            await OnBeforeRecordCreateAsync(_dbContext, entity);

            _dbContext
                .Set<TEntity>()
                .Add(entity);


            await _dbContext .SaveChangesAsync();

            await OnAfterRecordCreateAsync(_dbContext, entity);

            return entity.Id;
        }
        public async Task<CrudOperationResult<TDto>> Update (TEntity newEntity)
        {
            var entityBeforeUpdate = await GetById(newEntity.Id);

            if (entityBeforeUpdate == null)
            {
                return new CrudOperationResult<TDto>
                {
                    Status = CrudOperationResultStatus.RecordNotFound,
                };
            }

            _dbContext.Entry(newEntity).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return new CrudOperationResult<TDto>
            {
                Status = CrudOperationResultStatus.Success,
            };
        }
        protected async virtual Task<TEntity> GetById(Guid id)
        {
            var entity = await _dbContext
                .Set<TEntity>()
                .AsNoTracking()
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync();
            return entity;
        }
        public async virtual Task<IEnumerable<TEntity>> Get()
        {
            var entities = await _dbContext
                .Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();

            return entities;
        }

        protected virtual IQueryable<TEntity> ConfigureFromIncludes(IQueryable<TEntity> linq)
        {
            return linq;
        }
    }
}
