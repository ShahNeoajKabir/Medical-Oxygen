using Microsoft.AspNetCore.Mvc;
using ModelClass.DTO;
using ModelClass.ViewModel;
using Newtonsoft.Json;
using SecurityBLLManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Oxygen.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductBLLManage _bLLManage;
        public ProductController(IProductBLLManage bLLManage)
        {
            _bLLManage = bLLManage;
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult> AddProduct([FromBody] TempMessage message)
        {
            try
            {
                Product product = JsonConvert.DeserializeObject<Product>(message.Content.ToString());
                return Ok(await _bLLManage.AddProduct(product));
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        [Route("ActiveProduct")]
        public List<Product> ActiveProduct()
        {
            try
            {
                List<Product> product = _bLLManage.ActiveProduct();
                return product;
            }
            catch (Exception)
            {

                throw;
            }
            
        }


        [HttpGet]
        [Route("DeactiveProduct")]
        public List<Product> DeactiveProduct()
        {
            try
            {
                List<Product> product = _bLLManage.DeactiveProduct();
                return product;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
