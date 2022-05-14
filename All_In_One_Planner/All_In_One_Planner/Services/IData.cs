using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace All_In_One_Planner.Services
{
    public interface IData<T>
    {
        Task<bool> AddMemoAsync(T item);
        Task<bool> UpdateMemoAsync(T item);
        Task<bool> DeleteMemoAsync(string id);
        Task<T> GetMemoAsync(string id);
        Task<IEnumerable<T>> GetMemoAsync(bool forceRefresh = false);
    }
}
