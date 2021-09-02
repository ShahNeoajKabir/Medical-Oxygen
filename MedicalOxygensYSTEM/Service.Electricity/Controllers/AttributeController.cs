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
    [Route("api/Attribute")]
    [ApiController]
    public class AttributeController : Controller
    {
        private readonly IAttributesBLLManager _bLLManager;
        public AttributeController(IAttributesBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }

        [HttpPost]
        [Route("AddAttribute")]
        public async Task<ActionResult> AddAttribute([FromBody] TempMessage message)
        {
            try
            {
                Attributesss Attributesss = JsonConvert.DeserializeObject<Attributesss>(message.Content.ToString());
                return Ok(await _bLLManager.AddAttribute(Attributesss));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("ActiveAttribute")]
        public List<Attributesss> ActiveAttribute()
        {
            try
            {
                List<Attributesss> Attributesss = _bLLManager.GetActiveAttribute();
                return Attributesss;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("DeactiveAttribute")]
        public List<Attributesss> DeactiveCategories()
        {
            try
            {
                List<Attributesss> Attributesss = _bLLManager.GetDeactiveAttribute();
                return Attributesss;
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
                Attributesss Attributesss = JsonConvert.DeserializeObject<Attributesss>(message.Content.ToString());
                return Ok(await _bLLManager.GetById(Attributesss));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("UpdateAttribute")]
        public async Task<ActionResult> UpdateAttribute([FromBody] TempMessage message)
        {
            try
            {
                Attributesss Attributesss = JsonConvert.DeserializeObject<Attributesss>(message.Content.ToString());
                return Ok(await _bLLManager.UpdateAttribute(Attributesss));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("DeleteAttribute")]
        public async Task<ActionResult> DeleteAttribute([FromBody] TempMessage message)
        {
            try
            {
                Attributesss Attributesss = JsonConvert.DeserializeObject<Attributesss>(message.Content.ToString());
                return Ok(await _bLLManager.DeleteAttribute(Attributesss));
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
