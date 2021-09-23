using Microsoft.AspNetCore.Http;
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
    [Route("api/Categories")]
    [ApiController]
    public class CategoriesController : Controller
    {
       
        private readonly ICategoriesBLLManager _bLLManager;
        public CategoriesController(ICategoriesBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }

        [HttpPost]
        [Route("AddCategories")]
        public async Task<ActionResult>AddCategories([FromBody]TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                Categories categories = JsonConvert.DeserializeObject<Categories>(message.Content.ToString());
                categories.CreatedBy = "Tanbin";
                return Ok(await _bLLManager.AddCategories(categories));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("ActiveCategories")]
        public List<Categories> ActiveCategories()
        {
            try
            {
                List<Categories> categories = _bLLManager.GetActiveCategories();
                return categories;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("DeactiveCategories")]
        public List<Categories> DeactiveCategories()
        {
            try
            {
                List<Categories> categories = _bLLManager.GetDeactiveCategories();
                return categories;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<ActionResult>GetById([FromBody]TempMessage message)
        {
            try
            {
                Categories categories = JsonConvert.DeserializeObject<Categories>(message.Content.ToString());
                return Ok(await _bLLManager.GetById(categories));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("UpdateCategories")]
        public async Task<ActionResult>UpdateCategories([FromBody]TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                Categories categories = JsonConvert.DeserializeObject<Categories>(message.Content.ToString());
                categories.UpdatedBy = "Tanbin";
                return Ok(await _bLLManager.UpdateCategories(categories));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("DeleteCategories")]
        public async Task<ActionResult>DeleteCategories([FromBody]TempMessage message)
        {
            try
            {
                Categories categories = JsonConvert.DeserializeObject<Categories>(message.Content.ToString());
                return Ok(await _bLLManager.DeleteCategories(categories));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
