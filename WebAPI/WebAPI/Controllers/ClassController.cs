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
    public class ClassController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        public ClassController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("save")]
        public ActionResult Save([FromBody]Class @class)
        {
            if (ModelState.IsValid)
                return NotFound();
            if (@class.ClassId > 0)
            {
                unitOfWork.ClassRepo.Modify(@class);
            }
            else
            {
                unitOfWork.ClassRepo.Add(@class);
            }
            unitOfWork.SaveChanges();

            return Ok(@class);
        }

        [HttpPost]
        [Route("delete")]
        public ActionResult Delete([FromRoute]int id)
        {
            if (id <= 0)
                return NotFound();
            unitOfWork.ClassRepo.DeleteById(id);
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
            return Ok(unitOfWork.ClassRepo.GetById(id));
        }
        [HttpGet]
        [Route("GetDataTable/{pageIndex}/{pageSize}/{search}")]
        public ActionResult GetTableData([FromRoute]int pageindex, [FromRoute]int pageSize, [FromRoute] string search)
        {
            return Ok(unitOfWork.ClassRepo.GetPaged(pageindex, pageSize, search));
        }
    }
}