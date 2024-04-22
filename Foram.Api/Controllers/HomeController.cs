//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free To Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 


using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Foram.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : RESTFulController
    {
        [HttpGet]

        public ActionResult<string> Get() =>
             Ok("Hello Mario the princess is in another Castle");
    }
}