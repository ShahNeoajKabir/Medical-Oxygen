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
    public class TagBLLManager:ITagBLLManager
    {
        private readonly DatabaseContext _context;
        public TagBLLManager(DatabaseContext context)
        {
            _context = context;
        }
        #region Add Tag
        public async Task<bool> AddTag(Tag tag)
        {
            try
            {
                var check = await _context.Tag.Where(p => p.TagName == tag.TagName).FirstOrDefaultAsync();
                if (check != null)
                {
                    throw new Exception(" ");
                }
                else
                {
                    if (tag.TagName != null )
                    {
                        tag.CreatedBy = "CoOrdinator";
                        tag.CreatedDate = DateTime.Now;
                        await _context.Tag.AddAsync(tag);
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

        #region Delete Tag

        public async Task<bool> DeleteTag(Tag tag)
        {
            try
            {
                var checkid = await _context.Tag.Where(p => p.TagId == tag.TagId).AsNoTracking().FirstOrDefaultAsync();
                if (checkid != null)
                {
                    _context.Tag.Remove(tag);
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


        #region Get Active Tag
        public List<Tag> GetActiveTag()
        {
            List<Tag> tag = _context.Tag.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).ToList();
            return tag;
        }

        #endregion

        #region Get DeActiveTag
        public List<Tag> GetDeactiveTag()
        {
            List<Tag> tag = _context.Tag.ToList();
            return tag;
        }

        #endregion


        #region Get By Id
        public async Task<Tag> GetById(Tag tag)
        {
            var tagid = await _context.Tag.Where(p => p.TagId == tag.TagId).FirstOrDefaultAsync();
            return tagid;
        }

        #endregion


        #region Update Tag

        public async Task<bool> UpdateTag(Tag tag)
        {
            try
            {
                var checkid = await _context.Tag.Where(p => p.TagId == tag.TagId).AsNoTracking().FirstOrDefaultAsync();
                if (checkid != null)
                {
                  
                   
                        tag.UpdatedBy = "CoOrdinator";
                        tag.UpdatedDate = DateTime.Now;
                        _context.Tag.Update(tag);
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
