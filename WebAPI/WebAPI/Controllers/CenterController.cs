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
    public class CenterController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        public CenterController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("save")]
        public ActionResult Save([FromBody]Center center)
        {
            if (ModelState.IsValid)
                return NotFound();
            if (center.CenterId > 0)
            {
                unitOfWork.CenterRepo.Modify(center);
            }
            else
            {
                unitOfWork.CenterRepo.Add(center);
            }
            unitOfWork.SaveChanges();

            return Ok(center);
        }

        [HttpPost]
        [Route("delete")]
        public ActionResult Delete([FromRoute]int id)
        {
            if (id <= 0)
                return NotFound();
            unitOfWork.CenterRepo.DeleteById(id);
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
            return Ok(unitOfWork.CenterRepo.GetById(id));
        }
        [HttpGet]
        [Route("GetDataTable/{pageIndex}/{pageSize}/{search}")]
        public ActionResult GetTableData([FromRoute]int pageindex, [FromRoute]int pageSize, [FromRoute] string search)
        {
            return Ok(unitOfWork.CenterRepo.GetPaged(pageindex, pageSize, search));
        }
    }
}