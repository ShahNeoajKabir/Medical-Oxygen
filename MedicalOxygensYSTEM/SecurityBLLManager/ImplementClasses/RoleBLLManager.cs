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
    public class RoleBLLManager : IRoleBLLManager
    {

        private readonly DatabaseContext _context;
        public RoleBLLManager(DatabaseContext context)
        {
            _context = context;
        }
        #region Add Role
        public async Task<bool> AddRole(Role role)
        {
            try
            {
                var checkrole = _context.Role.Where(p => p.RoleName == role.RoleName).FirstOrDefaultAsync();
                if (role.RoleName != null && role.Status > 0)
                {
                    if (checkrole == null)
                    {
                        role.CreatedBy = "Admin";
                        role.CreatedDate = DateTime.Now;
                        await _context.Role.AddAsync(role);
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
                        throw new Exception("Role Already Exists");
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

        #region Get All Role List

        public List<Role> GetAllRole()
        {
            try
            {
                List<Role> role = _context.Role.ToList();
                return role;
            }
            catch (Exception)
            {

                throw new Exception(" ");
            }
        }
        #endregion

        #region Get All Active Role

        public List<Role> GetActiveRole()
        {
            try
            {
                List<Role> role = _context.Role.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).ToList();
                return role;
            }
            catch (Exception)
            {

                throw new Exception(" ");
            }
        }
        #endregion

        #region Get By Id
        public async Task<Role> GetById(Role role)
        {
            var roleid =await _context.Role.Where(p => p.RoleId == role.RoleId).FirstOrDefaultAsync();
            return roleid;
        }

        #endregion


        #region Delete Role
        public async Task<bool> DeleteRole(Role role)
        {
            try
            {
                var checkid = _context.Role.Where(p => p.RoleId == role.RoleId).AsNoTracking().FirstOrDefaultAsync();
                if (checkid != null)
                {
                    _context.Remove(role);
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


        #region Update Role

        public async Task<bool> UpdateRole(Role role)
        {
            try
            {
                var checkid = await _context.Role.Where(p => p.RoleId == role.RoleId).AsNoTracking().FirstOrDefaultAsync();
                if (checkid != null)
                {
                    role.UpdatedBy = "Admin";
                    role.UpdatedDate = DateTime.Now;
                    _context.Role.Update(role);
                    var res =await _context.SaveChangesAsync();
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
                    throw new Exception("Role Does not Found");
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
