using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebPusherAPI.Helper;

namespace WebPusherAPI.Controllers
{



    [Route("[controller]")]
    [ApiController]
    public class PusherController : ControllerBase
    {
        public PusherCommand cmd { get; set; }

        public PusherController()
        {
            cmd = new PusherCommand();
        }

        [HttpGet("TestHelloWorld")]
        public async Task<IActionResult> TestHelloWorld()
        {

            var result = await cmd.TriggerAsync("my-event", new { message = "hello world" });

            return Ok();
        }

        [HttpGet("TestRandomNumber")]
        public async Task<IActionResult> TestRandomNumber()
        {

            Random rnd = new Random();
            int luckNum = rnd.Next(1, 100);

            object obj = new { number = luckNum };

            var result = await cmd.TriggerAsync("my-random-number", obj);


            return Ok(obj);
        }

        [HttpPost("Auth")]
        public async Task<IActionResult> Auth()
        {
            var bodyJson = await Request.Body.ToBodyJson();
            string channel_name = bodyJson.ToValue("channel_name");
            string socket_id = bodyJson.ToValue("socket_id");

            var json = await cmd.Authenticate(channel_name, socket_id);


            return new ContentResult { Content = json, ContentType = "application/json" };
        }



    }
}
