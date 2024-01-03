using dotnetQ.Abstractions.Attributes;
using dotnetQ.Abstractions.Models;
using dotnetQ.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnetQ.Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {

        private readonly ILogger<SampleController> _logger;
        private readonly IQManager iqManager;

        public SampleController(ILogger<SampleController> logger,
            IQManager iqManager)
        {
            _logger = logger;
            this.iqManager = iqManager;
        }


        /// <summary>
        /// هندلر آیتم ها
        /// </summary>
        /// <returns></returns>
        [QHandler(1)]
        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult ItemHandler()
        {
            return Ok();
        }

        /// <summary>
        /// اضافه نمودن آیتم به صف
        /// </summary>
        /// <returns></returns>
        public IActionResult AddNewItem()
        {
            iqManager.AddItem(new Item()
            {

            });

            return Ok();
        }
    }
}
