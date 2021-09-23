using ModelClass.DTO;
using ModelClass.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.Interfaces
{
    public interface IProductBLLManage
    {
        Task<bool> AddProduct(Product product);
        List<Product> ActiveProduct();
        List<Product> DeactiveProduct();
        Task<Product> GetById(Product product);
        List<Product> ProductDetails(int productid);
    }
}
