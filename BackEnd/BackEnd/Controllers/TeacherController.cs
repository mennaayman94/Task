using BackEnd.BusinessLayer;
using BackEnd.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class TeacherController : ApiController
    {
        //Create an Instance of Teacher business Layer
        TeacherBL teacher = new TeacherBL();
        //Get All Teachers
        [HttpGet]
        public IHttpActionResult GetAllteachers()
        {
            try
            {

                var Getteacher = teacher.GetAllTeachers();
                if (Getteacher.Count() > 0)
                {
                    return Ok(Getteacher);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return NotFound();
            }


        }
        //Get One teacher By id
        public IHttpActionResult GetOneTeacher(int id)
        {
            try
            {
                var Getteacher = teacher.GetOne(id);
                if (Getteacher != null)
                {
                    return Ok(Getteacher);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return NotFound();
            }


        }
        //Add New Teacher instance
        [HttpPost]
        public IHttpActionResult AddTeacher(AddTeacherDTO teach)
        {

            if (ModelState.IsValid)
            {
                var Createdteacher = teacher.Createteacher(teach);
                return Ok(Createdteacher);
            }
            else
            {
                return BadRequest("Data is not valid");
            }

        }
        //Delete teacher
        [HttpDelete]
        public IHttpActionResult Deleteteacher(int id)
        {
            try
            {
                var Deletedteacher = teacher.Deleteteacher(id);
                return Ok(Deletedteacher);
            }
            catch
            {

                return BadRequest("ID is Not Found"); 
            }
   
        }
        //Edit existing Teacher
        [HttpPut]
        public IHttpActionResult Editteacher(int id, TeacherDTO teach)
        {
            try
            {
                if (teach.TeacherId == id &&ModelState.IsValid)
                {
                    var Editedteacher = teacher.Editteacher(teach);
                    return Ok(Editedteacher);
                }

                else
                {
                    return BadRequest("Data is not Valid or Id is not found");
                }
            }
            catch
            {

                return BadRequest("Data is not Valid or Id is not found");
            }
        }
    }
}
