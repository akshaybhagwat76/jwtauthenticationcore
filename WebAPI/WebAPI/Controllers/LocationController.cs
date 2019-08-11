using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        public LocationController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("save")]
        public ActionResult Save([FromBody]Location location)
        {
            if (ModelState.IsValid)
                return NotFound();
            if (location.LocationId > 0)
            {
                unitOfWork.LocationRepo.Modify(location);
            }
            else
            {
                unitOfWork.LocationRepo.Add(location);
            }
            unitOfWork.SaveChanges();

            return Ok(location);
        }

        [HttpPost]
        [Route("delete")]
        public ActionResult Delete([FromRoute]int id)
        {
            if (id <= 0)
                return NotFound();
            unitOfWork.LocationRepo.DeleteById(id);
            if (unitOfWork.SaveChanges() == 1)
                return Ok(true);
            else
                return Ok(false);
        }
        [HttpGet]
        [Route("Get/{id}")]
        public ActionResult GetById([FromRoute]int id)
        {
            if (id <= 0)
                return NotFound();
            return Ok(unitOfWork.LocationRepo.GetById(id));
        }
        [HttpGet]
        [Route("GetDataTable/{pageIndex}/{pageSize}/{search}")]
        public ActionResult GetTableData([FromRoute]int pageindex, [FromRoute]int pageSize, [FromRoute] string search)
        {
            return Ok(unitOfWork.LocationRepo.GetPaged(pageindex, pageSize, search));
        }
    }
}