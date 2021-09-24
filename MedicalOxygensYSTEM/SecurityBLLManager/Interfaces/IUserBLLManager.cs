using ModelClass.DTO;
using ModelClass.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.Interfaces
{
    public interface IUserBLLManager
    {
        Task<bool> AddUser(User user);
        Task<List<VmUsers>> GetAll();
        List<User> GetActiveUser();
        Task<List<VmUsers>> GetAllModerator();
        Task<List<VmUsers>> GetDeliveryMan();
        Task<List<VmUsers>> GetCustomer();
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(User user);
        Task<bool> ChangePassword(VMChangePassword vMChangePassword);
        Task<User> GetById(int  user);
        Task<User> AddCustomer(User customer);


    }
}
