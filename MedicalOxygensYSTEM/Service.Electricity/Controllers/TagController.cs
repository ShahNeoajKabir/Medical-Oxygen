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
    [Route("api/Tag")]
    [ApiController]
    public class TagController : Controller
    {
        private readonly ITagBLLManager _bLLManager;
        public TagController(ITagBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }

        [HttpPost]
        [Route("AddTag")]
        public async Task<ActionResult> AddTag([FromBody] TempMessage message)
        {
            try
            {
                Tag Tag = JsonConvert.DeserializeObject<Tag>(message.Content.ToString());
                return Ok(await _bLLManager.AddTag(Tag));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("ActiveTag")]
        public List<Tag> ActiveTag()
        {
            try
            {
                List<Tag> Tag = _bLLManager.GetActiveTag();
                return Tag;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("DeactiveTag")]
        public List<Tag> DeactiveTag()
        {
            try
            {
                List<Tag> Tag = _bLLManager.GetDeactiveTag();
                return Tag;
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
                Tag Tag = JsonConvert.DeserializeObject<Tag>(message.Content.ToString());
                return Ok(await _bLLManager.GetById(Tag));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("UpdateTag")]
        public async Task<ActionResult> UpdateTag([FromBody] TempMessage message)
        {
            try
            {
                Tag Tag = JsonConvert.DeserializeObject<Tag>(message.Content.ToString());
                return Ok(await _bLLManager.UpdateTag(Tag));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("DeleteTag")]
        public async Task<ActionResult> DeleteTag([FromBody] TempMessage message)
        {
            try
            {
                Tag Tag = JsonConvert.DeserializeObject<Tag>(message.Content.ToString());
                return Ok(await _bLLManager.DeleteTag(Tag));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
