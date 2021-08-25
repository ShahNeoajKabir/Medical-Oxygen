using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.Interfaces
{
    public interface IRoleBLLManager
    {
        Task<bool> AddRole(Role role);
        List<Role> GetAllRole();
        List<Role> GetActiveRole();
        Task<bool> UpdateRole(Role role);
        Task<Role> GetById(Role role);
        Task<bool> DeleteRole(Role role);
    }
}
