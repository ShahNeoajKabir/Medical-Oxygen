using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.Interfaces
{
    public interface ICategoriesBLLManager
    {
        Task<bool> AddCategories(Categories categories);
        Task<bool> UpdateCategories(Categories categories);
        Task<bool> DeleteCategories(Categories categories);
        Task<Categories> GetById(Categories categories);
        List<Categories> GetAll();
    }
}
