using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bfour.Core.ResultModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BfourProject.UI.Controllers
{
   
    public class BaseController : Controller
    {

        
        public IActionResult CreateActionResult<T>(Result<T> result)
        {
            if (result.StatusCode == 204)
            {
                return new ObjectResult(null) { StatusCode = result.StatusCode };
            }
            return new ObjectResult(result) { StatusCode = result.StatusCode };
        }
    }
}

