using Common.Electricity.Utility;
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
        public async Task<List<VmUsers>> GetAll()
        {
            List<VmUsers> user = await _context.User.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).Select(c => new VmUsers()
            {

                Email = c.Email,
                MobileNo = c.MobileNumber,
                RoleName = c.UserRole.Where(p => p.Status == 1).FirstOrDefault().Role.RoleName,
                Status = c.Status,
                UserId = c.UserId,
                UserName = c.UserName

            }).ToListAsync();
            return user;
        }
        #endregion

        #region All Active User
        public List<User> GetActiveUser()
        {
            try
            {
                List<User> user = _context.User.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active ).Select(t=>new User(){
                    UserName=t.UserName,
                    Email=t.Email,
                    MobileNumber=t.MobileNumber,
                    Status=t.Status,
                    CreatedBy=t.CreatedBy,
                    CreatedDate=t.CreatedDate,
                    UpdatedBy=t.UpdatedBy,
                    UpdatedDate=t.UpdatedDate,
                    UserType=t.UserType,
                    Password=t.Password,
                    Image=t.Image
                    }).ToList();
                return user;
            }
            catch (Exception)
            {

                throw new Exception("");
            }
        }
        #endregion

        #region Get Moderator
        public async Task<List<VmUsers>> GetAllModerator()
        {
            List<VmUsers> user = await _context.User.Where(p => p.UserType == (int)Common.Electricity.Enum.Enum.UserType.Moderator).Select(c => new VmUsers()
            {

                Email = c.Email,
                MobileNo = c.MobileNumber,
                RoleName = c.UserRole.Where(p => p.Status == 1).FirstOrDefault().Role.RoleName,
                Status = c.Status,
                UserId = c.UserId,
                UserName = c.UserName

            }).ToListAsync();
            return user;
        }

        #endregion

        #region Get DeliveryMan

        public async Task<List<VmUsers>> GetDeliveryMan()
        {
            List<VmUsers> user = await _context.User.Where(p => p.UserType == (int)Common.Electricity.Enum.Enum.UserType.DeliveryMan).Select(c => new VmUsers()
            {

                Email = c.Email,
                MobileNo = c.MobileNumber,
                RoleName = c.UserRole.Where(p => p.Status == 1).FirstOrDefault().Role.RoleName,
                Status = c.Status,
                UserId = c.UserId,
                UserName = c.UserName

            }).ToListAsync();
            return user;
        }

        #endregion

        #region Get Customer
        public async Task<List<VmUsers>> GetCustomer()
        {
            List<VmUsers> user = await _context.User.Where(p => p.UserType == (int)Common.Electricity.Enum.Enum.UserType.Customer).Select(c => new VmUsers()
            {

                Email = c.Email,
                MobileNo = c.MobileNumber,
                RoleName = c.UserRole.Where(p => p.Status == 1).FirstOrDefault().Role.RoleName,
                Status = c.Status,
                UserId = c.UserId,
                UserName = c.UserName

            }).ToListAsync();
            return user;
        }
        #endregion

        #region Update User
        public async Task<bool>UpdateUser(User user)
        {
            try
            {
                var id =await _context.User.Where(p => p.UserId == user.UserId).AsNoTracking().FirstOrDefaultAsync();
                if (id != null)
                {
                    var checkmail =await _context.User.Where(p => p.Email == user.Email).AsNoTracking().FirstOrDefaultAsync();
                    if (checkmail != null)
                    {
                        throw new Exception("Email Already Exists");
                    }
                    else
                    {
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
        public async Task<User>GetById(int user)
        {
            try
            {
                var res = await _context.User.Where(p => p.UserId == user).FirstOrDefaultAsync();
                var roleid = await _context.UserRole.Where(p => p.UserId == user && p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).FirstOrDefaultAsync();
                if (roleid != null)
                {
                    res.Role = roleid.RoleId;
                }
                return res;
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


        public async Task<User> AddCustomer(User customer)
        {

            try
            {
                int result = 0;
                var uniqueemail = _context.User.Where(p => p.Email == customer.Email).FirstOrDefault();
                if (customer.UserName != null && customer.Email != null  && customer.MobileNumber != null)
                {
                    if (uniqueemail != null)
                    {
                        throw new Exception("");
                    }

                    else
                    {
                        customer.Status = (int)Common.Electricity.Enum.Enum.Status.Active;
                        customer.Image = customer.Image;
                        customer.CreatedBy = customer.UserName;
                        customer.UserType = (int)Common.Electricity.Enum.Enum.UserType.Customer;
                        customer.CreatedDate = DateTime.Now;
                        customer.Password = new EncryptionService().Encrypt(customer.Password);
                        await _context.User.AddAsync(customer);
                        var res = _context.SaveChanges();

                        if (res == 1)
                        {
                            result = customer.UserId;
                            UserRole userRole = new UserRole()
                            {
                                RoleId = 3,
                                UserId = customer.UserId,
                                CreatedBy = "CoOrdinator",
                                CreatedDate = DateTime.Now
                            };
                            _context.UserRole.Add(userRole);
                            _context.SaveChanges();
                        }

                    }

                    

                }
                return customer;
            }
            catch (Exception ex)
            {

                throw new Exception("Failed To Registration");
            }
        }
    }

}


