﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.ViewModel;
using Newtonsoft.Json;
using SecurityBLLManager.ImplementClasses;
using Service.Oxygen.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Oxygen.Controllers
{

    [Produces("application/json")]
    [Route("api/Security")]
        [ApiController]
        public class SecurityController : ControllerBase
        {
            private readonly ISecurityBLLmanager securityBLLManager;
            private readonly IAuthenticationManager authenticationManager;
            public SecurityController(ISecurityBLLmanager securityBLLManager, IAuthenticationManager authenticationManager)
            {
                this.securityBLLManager = securityBLLManager;
                this.authenticationManager = authenticationManager;
            }

            [HttpPost]
            [Route("Login")]
            public async Task<ActionResult> Login(TempMessage message)
            {
                VMLogin userLogin = JsonConvert.DeserializeObject<VMLogin>(message.Content);
                var result = await this.securityBLLManager.Login(userLogin);
                if (result != null)
                {
                    var token = this.authenticationManager.BuildToken(result);
                    return Ok(token);
                    //return  ok(new { Token = this.authenticationManager.BuildToken(Converter.ObjectConvert<User>(result)) });
                }
                else
                {
                    return NotFound("User not Authenticate");
                }


            }
            [HttpGet("Gets")]
            public string Gets()
            {
                return "Hello";
            }

        }
    }

