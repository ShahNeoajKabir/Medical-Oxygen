using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.Interfaces
{
    public interface IUserRoleBLLManager
    {
        Task<bool> AddUserRole(UserRole userRole);
        Task<bool> UpdateUserRole(UserRole userRole);
        Task<bool> DeleteUserRole(UserRole userRole);
        List<UserRole> GetAll();
        Task<UserRole> GetById(UserRole userRole);
    }
}
