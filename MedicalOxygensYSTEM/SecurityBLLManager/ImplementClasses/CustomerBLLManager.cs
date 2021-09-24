using Common.Electricity.Utility;
using Context;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ImplementClasses
{
    public class CustomerBLLManager: ICustomerBLLManager
    {
        private readonly DatabaseContext _dbContext;
        public CustomerBLLManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddCustomer(User customer)
        {

            try
            {
                var uniqueemail = _dbContext.User.Where(p => p.Email == customer.Email).FirstOrDefault();
                if (customer.UserName != null && customer.Email != null && customer.UserId > 0 && customer.MobileNumber != null)
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
                        customer.CreatedDate = DateTime.Now;
                        customer.Password = new EncryptionService().Encrypt(customer.Password);
                        await _dbContext.User.AddAsync(customer);
                        await _dbContext.SaveChangesAsync();

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

    public interface ICustomerBLLManager
    {
        Task<User> AddCustomer(User customer);
    }
    }
