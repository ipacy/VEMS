using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.Models;

namespace VEMS.Services.V1
{
    public interface IBaseEntityService<T>
    {
        Task<ApiResponse<List<T>>> Get();
        Task<T> Post(T entity);
        Task<T> Put(T entity);
        Task<bool> Delete(int id);
        Task<bool> Delete(Guid id);
    }
}
