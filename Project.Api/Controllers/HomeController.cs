//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
// Free To use Comfort and peace
//=================================================
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Great.Api.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class HomeController : RESTFulController
    {
        [HttpGet]

        public ActionResult<string> Get() =>
            Ok("I worked finished");
    }
}