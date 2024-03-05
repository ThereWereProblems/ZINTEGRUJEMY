using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZINTEGRUJEMY.Application.Features.Product.Queries;
using ZINTEGRUJEMY.Application.Features.Task.Commands;
using ZINTEGRUJEMY.Domain.ReadModel;

namespace ZINTEGRUJEMY.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZintegrujemyController : ApiControllerBase
    {
        /// <summary>
        /// First endpoint from task
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("processtask")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        public async Task<IActionResult> FirstEndpiont()
        {
            return HandleAppResult(await Mediator.Send(new FirstTaskCommand()));
        }

        /// <summary>
        /// Get product info
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        [ProducesResponseType(typeof(ProductSearchResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProduct([FromQuery] GetProductQuery query)
        {
            return HandleAppResult(await Mediator.Send(query));
        }
    }
}
