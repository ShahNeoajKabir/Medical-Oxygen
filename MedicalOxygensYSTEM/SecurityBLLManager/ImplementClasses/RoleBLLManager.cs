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

            }
            catch (Exception)
            {

                throw new Exception(" ");
            }
        }
        #endregion
        public Task<bool> DeleteRole(Role role)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetActiveRole()
        {
            throw new NotImplementedException();
        }

        public List<Role> GetAllRole()
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetById(Role role)
        {
            throw new NotImplementedException();
        }



        public Task<bool> UpdateRole(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
