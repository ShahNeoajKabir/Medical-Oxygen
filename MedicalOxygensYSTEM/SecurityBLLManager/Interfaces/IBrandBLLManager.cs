using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.Interfaces
{
    public interface IBrandBLLManager
    {
        Task<bool> AddBrand(Brand brand);
        Task<bool> UpdateBrand(Brand brand);
        Task<bool> DeleteBrand(Brand brand);
        Task<Brand> GetById(Brand brand);
        List<Brand> GetDeactiveBrand();
        List<Brand> GetActiveBrand();
    }
}
