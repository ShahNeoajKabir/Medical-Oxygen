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
    [Route("api/Role")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleBLLManager _bLLManager;
        public RoleController(IRoleBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }

        [HttpPost]
        [Route("AddRole")]
        public async Task<ActionResult>AddRole([FromBody]TempMessage message)
        {
            try
            {
                Role role = JsonConvert.DeserializeObject<Role>(message.Content.ToString());
                return Ok(await _bLLManager.AddRole(role));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("DeactivateRole")]
        public List<Role> DeactivateRole()
        {
            List<Role> role = _bLLManager.GetAllRole();
            return role;
        }

        [HttpGet]
        [Route("ActivateRole")]
        public List<Role> ActivateRole()
        {
            List<Role> role = _bLLManager.GetActiveRole();
            return role;
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<ActionResult>GetById([FromBody] TempMessage message)
        {
            try
            {
                Role role = JsonConvert.DeserializeObject<Role>(message.Content.ToString());
                return Ok(await _bLLManager.GetById(role));
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        [Route("UpdateRole")]
        public async Task<ActionResult>UpdateRole([FromBody] TempMessage message)
        {
            try
            {
                Role role = JsonConvert.DeserializeObject<Role>(message.Content.ToString());
                return Ok(await _bLLManager.UpdateRole(role));
            }
            catch (Exception )
            {

                throw;
            }
        }


        [HttpPost]
        [Route("DeleteRole")]
        public async Task<ActionResult> DeleteRole([FromBody] TempMessage message)
        {
            try
            {
                Role role = JsonConvert.DeserializeObject<Role>(message.Content.ToString());
                return Ok(await _bLLManager.DeleteRole(role));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
