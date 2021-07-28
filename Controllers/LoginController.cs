using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce_Frutas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce_Frutas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {        
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public string Authenticate()
        {   
            return TokenService.GenerateToken();        
        }
    }
}
