using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentCRUDApp.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddStudentAsync(T item);
        Task<bool> UpdateStudentAsync(T item);
        Task<bool> DeleteStudentAsync(string id);
        Task<T> GetStudentAsync(string id);
        Task<IEnumerable<T>> GetAllStudentAsync(bool forceRefresh = false);
    }
}
