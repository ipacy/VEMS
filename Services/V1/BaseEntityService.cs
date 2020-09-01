using VEMS.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.Models;

namespace VEMS.Services.V1
{
    public class BaseEntityService<T> : IBaseEntityService<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;

        public BaseEntityService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var entity = await dbContext.FindAsync<T>(id);
                dbContext.Set<T>().Remove(entity);
                await dbContext.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }

        }
        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var entity = await dbContext.FindAsync<T>(id);
                dbContext.Set<T>().Remove(entity);
                await dbContext.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }

        }

        public async Task<ApiResponse<List<T>>> Get()
        {
            var response = new ApiResponse<List<T>>();
            try
            {
                response.Data = await dbContext.Set<T>().ToListAsync();
                response.AddSuccess();
                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                response.AddError(ex: "Unable to fetch records");
                return await Task.FromResult(response);
            }
        }

        public async Task<T> Post(T entity)
        {
            try
            {
                await dbContext.AddAsync<T>(entity);
                await dbContext.SaveChangesAsync();
                return await Task.FromResult(entity);
            }
            catch (Exception)
            {
                return entity;
            }
        }

        public async Task<T> Put(T entity)
        {
            try
            {
                dbContext.Set<T>().Update(entity);
                await dbContext.SaveChangesAsync();
                return await Task.FromResult(entity);
            }
            catch (Exception)
            {
                return entity;
            }
        }
    }
}
