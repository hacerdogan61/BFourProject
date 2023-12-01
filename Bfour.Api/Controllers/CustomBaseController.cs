using System.Text.Json;
using System.Text.Json.Serialization;
using Bfour.Core.ResultModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bfour.Api.Controllers
{
    public class CustomBaseController : Controller
    {
        [NonAction]// swagger end point olarak görmesin diye eklendi
        public IActionResult CreateActionResult<T>(Result<T> result)
        {
            if (result.StatusCode==204)
            {
                return new ObjectResult(null) { StatusCode = result.StatusCode };
            }
            return new ObjectResult(result) { StatusCode = result.StatusCode };
        }
        
    }
}

