using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.Interfaces
{
    public interface IProductBLLManage
    {
        Task<bool> AddProduct(Product product);
    }
}
