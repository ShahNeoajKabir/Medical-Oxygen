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
    public class CategoriesBLLManager : ICategoriesBLLManager
    {
        private readonly DatabaseContext _context;
        public CategoriesBLLManager(DatabaseContext context)
        {
            _context = context;
        }

        #region Add Categories
        public async Task<bool> AddCategories(Categories categories)
        {
            try
            {
                var check = _context.Categories.Where(p => p.CategoriesName == categories.CategoriesName).FirstOrDefault();
                if(categories.CategoriesName!=null & categories.Image != null)
                {
                    if (check != null)
                    {
                        throw new Exception("Categories Already Exists");
                    }
                    else
                    {
                        categories.CreatedBy = "CoOrdinator";
                        categories.CreatedDate = DateTime.Now;
                        await _context.Categories.AddAsync(categories);
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


        #region Delete Categories

        public async Task<bool> DeleteCategories(Categories categories)
        {
            try
            {
                var checkid = await _context.Categories.Where(p => p.CategoriesId == categories.CategoriesId).AsNoTracking().FirstOrDefaultAsync();
                if (checkid != null)
                {
                    _context.Categories.Remove(categories);
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
                    throw new Exception("Categories Can not found");
                }
            }
            catch (Exception)
            {

                throw new Exception(" ");
            }
        }

        #endregion


        #region GetCategories
        public List<Categories> GetDeactiveCategories()
        {
            List<Categories> categories = _context.Categories.Where(p=>p.Status==(int)Common.Electricity.Enum.Enum.Status.Inactive).ToList();
            return categories;
        }

        #endregion


        #region Active Categiries

        public List<Categories> GetActiveCategories()
        {
            List<Categories> categories = _context.Categories.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).ToList();
            return categories;
        }

        #endregion

        #region GetById
        public async Task<Categories> GetById(Categories categories)
        {
            var checkid = await _context.Categories.Where(p => p.CategoriesId == categories.CategoriesId).FirstOrDefaultAsync();
            return checkid;
        }

        #endregion


        #region Update Categories
        public async Task<bool> UpdateCategories(Categories categories)
        {
            try
            {
                var checkid = await _context.Categories.Where(p => p.CategoriesId == categories.CategoriesId).AsNoTracking().FirstOrDefaultAsync();
                if (checkid != null)
                {
                    if(categories.CategoriesName!=null & categories.Image != null)
                    {
                        categories.UpdatedBy = "CoOrdinator";
                        categories.UpdatedDate = DateTime.Now;
                        _context.Categories.Update(categories);
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

                else
                {
                    throw new Exception("Something is wrong");
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
