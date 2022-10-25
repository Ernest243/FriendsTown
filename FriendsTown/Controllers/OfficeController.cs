using FriendsTown.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FriendsTown.Controllers
{
    [Route("api")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        [Route("Offices")]
        [HttpGet]
        public List<Office> GetAll()
        {
            return new Office().GetAll();
        }


        [Route("Offices/{code}")]
        [HttpGet]
        public IActionResult FindById(string code)
        {
            var service = new Office().GetAll().FirstOrDefault(options => options.Code == code);

            return (service != null) ? Ok(service) : NotFound();
        }

        [Route("Offices")]
        [HttpPost]
        public IActionResult Add(Office office) 
        {
            var officeService = new Office();
            var officeList = officeService.GetAll();

            officeList.Add(office);

            string url = $"/api/offices/{office.Code}";

            return Created(url, officeList);
        }

        [Route("Offices")]
        [HttpPut]
        public IActionResult Update(Office office)
        {
            if (string.IsNullOrEmpty(office.Code) || string.IsNullOrEmpty(office.Name)) 
            {
                return BadRequest();
            }
            var officeService = new Office();
            var officeToUpdate = officeService.GetAll().FirstOrDefault(o => o.Code == office.Code);

            if (officeToUpdate == null) 
            {
                return NotFound();
            }

            officeToUpdate.Name = office.Name;

            return Ok(officeToUpdate);
        }

        [Route("Offices")]
        [HttpDelete]
        public IActionResult Delete(string code) 
        {
            var officeService = new Office();
            var officeList = officeService.GetAll();
            var deleteCount = officeList.RemoveAll(o => o.Code == code);

            return (deleteCount > 0) ? Ok(officeList) : NotFound();
        }
    }
}
