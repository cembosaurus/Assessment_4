using CheckApp.Models;
using CheckApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Check.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckController : ControllerBase
    {

        private ICheckService _checkService;


        public CheckController(ICheckService checkService)
        {
            _checkService = checkService;
        }




        // POST: api/Check
        [HttpPost]
        public IActionResult Post([FromBody] CheckDTO checkDTO)
        {

            checkDTO.Date = DateTime.Now;
            checkDTO.AmountInWords = _checkService.MoneyToWords(checkDTO.Amount);

            return Ok(checkDTO);
        }


    }
}
