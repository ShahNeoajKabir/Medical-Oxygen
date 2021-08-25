﻿using Common.Electricity.Utility;
using Context;
using Microsoft.EntityFrameworkCore;
using ModelClass.DTO;
using ModelClass.ViewModel;
using SecurityBLLManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager
{
    public class UserBLLManager: IUserBLLManager
    {
        private readonly DatabaseContext _context;
        public UserBLLManager(DatabaseContext context)
        {
            _context = context;
        }
        #region AddUser
        public async Task<bool> AddUser(User user)
        {
            try
            {
                var check = _context.User.Where(p => p.Email == user.Email).FirstOrDefault();
                if(user.Email!=null && user.UserName!=null&& user.MobileNumber!=null&& user.Password != null)
                {
                    if (check != null)
                    {
                        throw new Exception("Email is already used");
                    }
                    else
                    {
                        user.CreatedBy = "Tanbin";
                        user.CreatedDate = DateTime.Now;
                        user.Password = new EncryptionService().Encrypt(user.Password);
                        await _context.User.AddAsync(user);
                        var resuly =await _context.SaveChangesAsync();
                        if (resuly > 0)
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
                    throw new Exception("Something is wrong");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        //All Assign and UnAssign User List
        #region ListAllUser
        public List<User> GetAllUser()
        {
            try
            {
                List<User> user = _context.User.ToList();
                return user;
            }
            catch (Exception)
            {
                throw new Exception("");
            }
        }
        #endregion

        #region All Active User
        public List<User> GetActiveUser()
        {
            try
            {
                List<User> user = _context.User.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).ToList();
                return user;
            }
            catch (Exception)
            {

                throw new Exception("");
            }
        }
        #endregion

        #region Get CoOrdinator
        public List<User> GetCoOrdinator()
        {

            try
            {
                List<User> user = _context.User.Where(p => p.UserType == (int)Common.Electricity.Enum.Enum.UserType.CoOrdinator).ToList();
                return user;
            }
            catch (Exception)
            {

                throw new Exception(" ");
            }
        }

        #endregion

        #region Get DeliveryMan

        public List<User> GetDeliveryMan()
        {
            try
            {
                List<User> user = _context.User.Where(p => p.UserType == (int)Common.Electricity.Enum.Enum.UserType.DeliveryMan).ToList();
                return user;
            }
            catch (Exception)
            {

                throw new Exception(" ");
            }
        }
        #endregion

        #region Update User
        public async Task<bool>UpdateUser(User user)
        {
            try
            {
                var id = _context.User.Where(p => p.UserId == user.UserId).AsNoTracking().FirstOrDefaultAsync();
                if (id != null)
                {
                    var checkmail = _context.User.Where(p => p.Email == user.Email).AsNoTracking().FirstOrDefaultAsync();
                    if (checkmail != null)
                    {
                        throw new Exception("Email Already Exists");
                    }
                    else
                    {
                        user.UpdatedBy = user.UserName;
                        user.UpdatedDate = DateTime.Now;
                        user.Password = new EncryptionService().Encrypt(user.Password);
                        _context.User.Update(user);
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
                    throw new Exception("");
                }
            }
            catch (Exception)
            {

                throw new Exception(" ");
            }
        }

        #endregion


        #region Delete User

        public async Task<bool>DeleteUser(User user)
        {
            try
            {
                var id = _context.User.Where(p => p.UserId == user.UserId).AsNoTracking().FirstOrDefaultAsync();
                if (id != null)
                {
                    _context.User.Remove(user);
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

        #region GetById
        public async Task<User>GetById(int Id)
        {
            try
            {
                var checkid = await _context.User.Where(p => p.UserId == Id).FirstOrDefaultAsync();
                var res = await _context.UserRole.Where(p => p.UserId == Id && p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).FirstOrDefaultAsync();
                if (res != null)
                {
                    checkid.Role = res.RoleId;
                }
                return checkid;
            }
            catch (Exception)
            {

                throw new Exception(" ");
            }
        }
        #endregion


        #region Change Password
        public async Task<bool> ChangePassword(VMChangePassword vMChangePassword)
        {
            bool res = false;
            try
            {
                vMChangePassword.OldPassword = new EncryptionService().Encrypt(vMChangePassword.OldPassword);
                vMChangePassword.NewPassword = new EncryptionService().Encrypt(vMChangePassword.NewPassword);
                vMChangePassword.RetypePassword = new EncryptionService().Encrypt(vMChangePassword.RetypePassword);

                var check = await _context.User.Where(p => p.UserId == vMChangePassword.VMUserId && p.Email == vMChangePassword.Email && p.Password == vMChangePassword.OldPassword).FirstOrDefaultAsync();
                if (check != null)
                {
                    if (vMChangePassword.NewPassword == vMChangePassword.RetypePassword && vMChangePassword.NewPassword != vMChangePassword.OldPassword)
                    {
                        check.Password = vMChangePassword.NewPassword;
                        check.UpdatedDate = DateTime.Now;
                        check.UpdatedBy = check.UserName;

                        _context.User.Update(check);
                        var count = _context.SaveChanges();
                        if (count > 0)
                        {
                            res = true;
                        }

                    }
                    else
                    {
                        throw new Exception("Something Is Wrong");
                    }
                }

                return res;
            }
            catch (Exception ex)
            {

                throw new Exception("Something Is Wrong");
            }
        }

        #endregion

    }



}
