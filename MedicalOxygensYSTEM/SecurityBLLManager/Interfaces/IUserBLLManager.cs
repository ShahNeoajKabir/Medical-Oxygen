﻿using ModelClass.DTO;
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
        List<User> GetAllUser();
        List<User> GetActiveUser();
        List<User> GetModerator();
        List<User> GetDeliveryMan();
        List<User> GetAllCustomer();
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(User user);
        Task<bool> ChangePassword(VMChangePassword vMChangePassword);
        Task<User> GetById(User user);


    }
}
