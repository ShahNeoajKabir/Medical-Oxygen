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
    [Route("api/Brand")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly IBrandBLLManager _bLLManager;
        public BrandController(IBrandBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }

        [HttpPost]
        [Route("AddBrand")]
        public async Task<ActionResult> AddBrand([FromBody] TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                Brand Brand = JsonConvert.DeserializeObject<Brand>(message.Content.ToString());
                Brand.CreatedBy = "Tanbin";
                return Ok(await _bLLManager.AddBrand(Brand));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("ActiveBrand")]
        public List<Brand> ActiveBrand()
        {
            try
            {
                List<Brand> Brand = _bLLManager.GetActiveBrand();
                return Brand;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("DeactiveBrand")]
        public List<Brand> DeactiveCategories()
        {
            try
            {
                List<Brand> Brand = _bLLManager.GetDeactiveBrand();
                return Brand;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<ActionResult> GetById([FromBody] TempMessage message)
        {
            try
            {
                Brand Brand = JsonConvert.DeserializeObject<Brand>(message.Content.ToString());
                return Ok(await _bLLManager.GetById(Brand));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("UpdateBrand")]
        public async Task<ActionResult> UpdateBrand([FromBody] TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                Brand Brand = JsonConvert.DeserializeObject<Brand>(message.Content.ToString());
                Brand.UpdatedBy = "Tanbin";
                return Ok(await _bLLManager.UpdateBrand(Brand));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("DeleteBrand")]
        public async Task<ActionResult> DeleteBrand([FromBody] TempMessage message)
        {
            try
            {
                Brand Brand = JsonConvert.DeserializeObject<Brand>(message.Content.ToString());
                return Ok(await _bLLManager.DeleteBrand(Brand));
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
