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
    public class StudentController : ApiController
    {
        //Create Instance of Student Buiness Layer
        StudentBL stdbl = new StudentBL();
        //Get All Students
        [HttpGet]
        public IHttpActionResult GetAllStudents()
        {
            try
            {
                
                var Getstd = stdbl.GetAllStds();
                if (Getstd.Count() > 0)
                {
                    return Ok(Getstd);
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
        //Get One student By id
        public IHttpActionResult GetStudent(int id)
        {
            try
            {
                var Getstd = stdbl.GetOne(id);
                if (Getstd != null)
                {
                    return Ok(Getstd);
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
        //Add New Student
        [HttpPost]
        public IHttpActionResult AddStudent(AddStudentDTO std)
        {
            
                if (ModelState.IsValid) {
                    var CreatedStd = stdbl.Createstd(std);
                    return Ok(CreatedStd);
                        } 
                else {
                    return BadRequest("Data is not valid");
                }
                    
            }
         
        //Delete Student
            [HttpDelete]
            public IHttpActionResult DeleteStd(int id)
            {
            try
            {
                var Deletedstd = stdbl.Deletestd(id);
                return Ok(Deletedstd);
            }
            catch 
            {

                return BadRequest("ID Is Not Found");

            }




        }
        //Edit existing Student
        [HttpPut]
        public IHttpActionResult Editstd(int id, StudentDTO std)
        {
            try
            {
                if (std.StdId == id && ModelState.IsValid)
                {
                    var Editedstd = stdbl.EditStd(std);
                    return Ok(Editedstd);
                }
                else
                {
                    return BadRequest("Data is not Valid or Id is not found");
                }
            }
            catch (Exception)
            {

                return BadRequest("Data is not Valid or Id is not found");
                
            }
            
        }



    }
}
