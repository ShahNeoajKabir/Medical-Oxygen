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
    public class UserRoleBLLManager:IUserRoleBLLManager
    {
        private readonly DatabaseContext _context;
        public UserRoleBLLManager(DatabaseContext context)
        {
            _context = context;
        }
        #region Add User Role
        public async Task<bool> AddUserRole(UserRole userRole)
        {
            try
            {
                if(userRole.RoleId>0 && userRole.UserId > 0)
                {
                    userRole.CreatedDate = DateTime.Now;
                    await _context.UserRole.AddAsync(userRole);
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


        #region Delete User Role
        public async Task<bool> DeleteUserRole(UserRole userRole)
        {
            try
            {
                var checkid = await _context.UserRole.Where(p => p.UserRoleId == userRole.UserRoleId).AsNoTracking().FirstOrDefaultAsync();
                if(checkid!=null && userRole.RoleId > 0)
                {
                    _context.UserRole.Remove(userRole);
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


        #region Get Active User Role
        public List<UserRole> GetActive()
        {
            List<UserRole> userRole = _context.UserRole.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).Select(t => new UserRole()
            {
                CreatedBy=t.CreatedBy,
                CreatedDate=t.CreatedDate,
                User=t.User,
                Role=t.Role,
                UpdatedBy=t.UpdatedBy,
                UpdatedDate=t.UpdatedDate,
                Status=t.Status,
                UserRoleId=t.UserRoleId
            }).ToList();

            return userRole;
        }
        #endregion

        #region Get Deactive User Role
        public List<UserRole> GetDeactive()
        {
            List<UserRole> userRole = _context.UserRole.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Inactive).Select(t => new UserRole()
            {
                CreatedBy = t.CreatedBy,
                CreatedDate = t.CreatedDate,
                User = t.User,
                Role = t.Role,
                UpdatedBy = t.UpdatedBy,
                UpdatedDate = t.UpdatedDate,
                Status = t.Status,
                UserRoleId = t.UserRoleId
            }).ToList();

            return userRole;
        }
        #endregion


        #region GetById
        public async Task<UserRole> GetById(UserRole userRole)
        {
            var res = await _context.UserRole.Where(p => p.UserRoleId == userRole.UserRoleId).FirstOrDefaultAsync();
            return res;
        }
        #endregion


        #region Update User Role
        public async Task<bool> UpdateUserRole(UserRole userRole)
        {
            try
            {
                var checkid = await _context.UserRole.Where(p => p.UserRoleId == userRole.UserRoleId).AsNoTracking().FirstOrDefaultAsync();
                if(checkid!=null && userRole.UserId > 0)
                {
                    userRole.UpdatedDate = DateTime.Now;
                    _context.UserRole.Update(userRole);
                    var res=await _context.SaveChangesAsync();
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
    }
}
