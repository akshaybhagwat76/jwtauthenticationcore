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
    public class StudentController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("save")]
        public ActionResult Save([FromBody]Student student)
        {
            if (ModelState.IsValid)
                return NotFound();
            if (student.StudentId > 0)
            {
                unitOfWork.StudentRepo.Modify(student);
            }
            else
            {
                unitOfWork.StudentRepo.Add(student);
            }
            unitOfWork.SaveChanges();

            return Ok(student);
        }

        [HttpPost]
        [Route("delete")]
        public ActionResult Delete([FromRoute]int id)
        {
            if (id <= 0)
                return NotFound();
            unitOfWork.StudentRepo.DeleteById(id);
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
            return Ok(unitOfWork.StudentRepo.GetById(id));
        }
        [HttpGet]
        [Route("GetDataTable/{pageIndex}/{pageSize}/{search}")]
        public ActionResult GetTableData([FromRoute]int pageindex, [FromRoute]int pageSize, [FromRoute] string search)
        {
            return Ok(unitOfWork.StudentRepo.GetPaged(pageindex, pageSize, search));
        }
    }
}