using Context;
using Microsoft.EntityFrameworkCore;
using ModelClass.DTO;
using ModelClass.ViewModel;
using SecurityBLLManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ImplementClasses
{
    public class ProductBLLManager:IProductBLLManage
    {
        private readonly DatabaseContext _context;
        public ProductBLLManager(DatabaseContext context)
        {
            _context = context;
        }

        #region Add Product

        public async Task<bool>AddProduct(Product product)
        {
            try
            {
                if(product.AttributeId>0 && product.BrandId>0 && product.CategoriesId>0 && product.Description!=null && product.StockQuantity>0
                     && product.Title != null && product.RegularPrice>0)
                {
                    product.CreatedDate = DateTime.Now;
                    await _context.Product.AddAsync(product);
                    var res = await _context.SaveChangesAsync();
                    if (res > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
                else
                {
                    throw new Exception(" ");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Active Product

        public List<Product> ActiveProduct()
        {
            try
            {
                List<Product> product = _context.Product.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).Select(t => new Product()
                {
                    ProductCode=t.ProductCode,
                    Title=t.Title,
                    DiscountPrice=t.DiscountPrice,
                    RegularPrice=t.RegularPrice,
                    Attribute=t.Attribute,
                    ProductId=t.ProductId,
                    Brand=t.Brand,
                    Categories=t.Categories,
                    CreatedBy=t.CreatedBy,
                    CreatedDate=t.CreatedDate,
                    Description=t.Description,
                    Image=t.Image,
                    Status=t.Status,
                    StockQuantity=t.StockQuantity,
                    UpdatedBy=t.UpdatedBy,
                    UpdatedDate=t.UpdatedDate
                }).ToList();
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion


        #region Deactive Product

        public List<Product> DeactiveProduct()
        {
            try
            {
                List<Product> product = _context.Product.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Inactive).Select(t => new Product()
                {
                    ProductCode = t.ProductCode,
                    Title = t.Title,
                    DiscountPrice = t.DiscountPrice,
                    RegularPrice = t.RegularPrice,
                    Attribute = t.Attribute,
                    ProductId = t.ProductId,
                    Brand = t.Brand,
                    Categories = t.Categories,
                    CreatedBy = t.CreatedBy,
                    CreatedDate = t.CreatedDate,
                    Description = t.Description,
                    Image = t.Image,
                    Status = t.Status,
                    StockQuantity = t.StockQuantity,
                    UpdatedBy = t.UpdatedBy,
                    UpdatedDate = t.UpdatedDate,
                }).ToList();
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        public async Task<Product>GetById(Product product)
        {
            try
            {
                var productid = await _context.Product.Where(p => p.ProductId == product.ProductId).FirstOrDefaultAsync();
                return productid;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<Product> ProductDetails(int productid)
        {
            List<Product> products = _context.Product.Where(p => p.ProductId == productid).Select(t => new Product()
            {
                ProductCode=t.ProductCode,
                DiscountPrice=t.DiscountPrice,
                RegularPrice=t.RegularPrice,
                Brand=t.Brand,
                BrandId=t.BrandId,
                Categories=t.Categories,
                CategoriesId=t.CategoriesId,
                Attribute=t.Attribute,
                AttributeId=t.AttributeId,
                Title=t.Title,
                Description=t.Description,
                Image=t.Image,
                StockQuantity=t.StockQuantity,
                Status=t.Status,
                ProductId=t.ProductId
            }).ToList();

            List<Product> products1 = new List<Product>();
            foreach (var item in products1)
            {
                item.BrandName = _context.Brand.Where(p => p.BrandId == item.BrandId).FirstOrDefault().BrandName;
                item.CategoriesName = _context.Categories.Where(p => p.CategoriesId == item.CategoriesId).FirstOrDefault().CategoriesName;
                item.AttributeValue = _context.Attribute.Where(p => p.AttributeId == item.AttributeId).FirstOrDefault().AttributeValue;
            }
            return products1;
        }
       

    }
}
