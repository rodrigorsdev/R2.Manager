using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace R2.Core.Api
{
    public abstract class BaseController : Controller
    {
        protected ICollection<string> Errors = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (isValidOperation())
                return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                {"messages", Errors.ToArray() }
            }));
        }

        protected bool isValidOperation()
        {
            return !Errors.Any();
        }

        protected void AddError(string error)
        {
            Errors.Add(error);
        }

        protected void ClearErrors()
        {
            Errors.Clear();
        }
    }
}
