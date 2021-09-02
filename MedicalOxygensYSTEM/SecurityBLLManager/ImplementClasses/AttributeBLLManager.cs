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
    public class AttributeBLLManager:IAttributesBLLManager
    {
        private readonly DatabaseContext _context;
        public AttributeBLLManager(DatabaseContext context)
        {
            _context = context;
        }
        #region Add Attribute
        public async Task<bool> AddAttribute(Attributesss attributesss)
        {
            try
            {
                var check = await _context.Attribute.Where(p => p.AttributeName == attributesss.AttributeName).FirstOrDefaultAsync();
                if (check != null)
                {
                    throw new Exception(" ");
                }
                else
                {
                    if (attributesss.AttributeName != null && attributesss.AttributeValue != null)
                    {
                        attributesss.CreatedBy = "CoOrdinator";
                        attributesss.CreatedDate = DateTime.Now;
                        await _context.Attribute.AddAsync(attributesss);
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

        #region Delete Attribute

        public async Task<bool> DeleteAttribute(Attributesss attributesss)
        {
            try
            {
                var checkid = await _context.Attribute.Where(p => p.AttributeId == attributesss.AttributeId).AsNoTracking().FirstOrDefaultAsync();
                if (checkid != null)
                {
                    _context.Attribute.Remove(attributesss);
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


        #region Get Active Attribute
        public List<Attributesss> GetActiveAttribute()
        {
            List<Attributesss> attribute = _context.Attribute.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).ToList();
            return attribute;
        }

        #endregion

        #region Get DeactiveAttribute
        public List<Attributesss> GetDeactiveAttribute()
        {
            List<Attributesss> attributessses = _context.Attribute.ToList();
            return attributessses;
        }

        #endregion


        #region Get By Id
        public async Task<Attributesss> GetById(Attributesss attributesss)
        {
            var Attributeid = await _context.Attribute.Where(p => p.AttributeId == attributesss.AttributeId).FirstOrDefaultAsync();
            return Attributeid;
        }

        #endregion


        #region Update Attribute

        public async Task<bool> UpdateAttribute(Attributesss attributesss)
        {
            try
            {
                var checkid = await _context.Attribute.Where(p => p.AttributeId == attributesss.AttributeId).AsNoTracking().FirstOrDefaultAsync();
                if (checkid != null)
                {
                   
                   
                        attributesss.UpdatedBy = "CoOrdinator";
                        attributesss.UpdatedDate = DateTime.Now;
                        _context.Attribute.Update(attributesss);
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
