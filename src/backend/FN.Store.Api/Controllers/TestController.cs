using Microsoft.AspNetCore.Mvc;

namespace FN.Store.Api.Controllers
{
    public class TestController
    {

        [HttpGet("api/v1/test")]
        public string Ping() => "Pong";
    }
}
