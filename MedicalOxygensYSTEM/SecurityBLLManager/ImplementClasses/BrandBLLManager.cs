using Context;
using Microsoft.EntityFrameworkCore;
using ModelClass.DTO;
using SecurityBLLManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ImplementClasses
{
    public class BrandBLLManager:IBrandBLLManager
    {
        private readonly DatabaseContext _context;
        public BrandBLLManager(DatabaseContext context)
        {
            _context = context;
        }
        #region Add Brand
        public async Task<bool> AddBrand(Brand brand)
        {
            try
            {
                var check = await _context.Brand.Where(p => p.BrandName == brand.BrandName).FirstOrDefaultAsync();
                if (check != null)
                {
                    throw new Exception(" ");
                }
                else
                {
                    if(brand.BrandName!=null && brand.Image != null)
                    {
                        brand.CreatedBy = "CoOrdinator";
                        brand.CreatedDate = DateTime.Now;
                        await _context.Brand.AddAsync(brand);
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
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Delete Brand

        public async Task<bool> DeleteBrand(Brand brand)
        {
            try
            {
                var checkid = await _context.Brand.Where(p => p.BrandId == brand.BrandId).AsNoTracking().FirstOrDefaultAsync();
                if (checkid != null)
                {
                    _context.Brand.Remove(brand);
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

                throw new Exception(" ");
            }
        }

        #endregion


        #region Get Active Brand
        public List<Brand> GetActiveBrand()
        {
            List<Brand> brand = _context.Brand.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).ToList();
            return brand;
        }

        #endregion

        #region Get All Deactive
        public List<Brand> GetDeactiveBrand()
        {
            List<Brand> brand = _context.Brand.Where(p=>p.Status==(int)Common.Electricity.Enum.Enum.Status.Inactive).ToList();
            return brand;
        }

        #endregion


        #region Get By Id
        public async Task<Brand> GetById(Brand brand)
        {
            var brandid = await _context.Brand.Where(p => p.BrandId == brand.BrandId).FirstOrDefaultAsync();
            return brandid;
        }

        #endregion


        #region Update Brand

        public async Task<bool> UpdateBrand(Brand brand)
        {
            try
            {
                var checkid = await _context.Brand.Where(p => p.BrandId == brand.BrandId).AsNoTracking().FirstOrDefaultAsync();
                if (checkid != null)
                {
                    
                    
                        brand.UpdatedBy = "CoOrdinator";
                        brand.UpdatedDate = DateTime.Now;
                        _context.Brand.Update(brand);
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
                    throw new Exception("Brand Name Does not exists");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
