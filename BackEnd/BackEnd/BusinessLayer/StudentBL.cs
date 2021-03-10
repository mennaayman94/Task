using AutoMapper;
using BackEnd.Models;
using BackEnd.Models.DTOS;
using BackEnd.RepositoryImp;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace BackEnd.BusinessLayer
{
    public class StudentBL
    {
        Repository<Student> repo = new Repository<Student>(new QualityStandardEntities());
        QualityStandardEntities db = new QualityStandardEntities();

        public IEnumerable<StudentDTO> GetAllStds()
        {
            var std = repo.GetAll().Include(x => x.Teacher).ToList();
            return Mapper.Map<List<StudentDTO>>(std);
        }
        public StudentDTO GetOne(int id)
        {
            var std = repo.GetById(id);
             return Mapper.Map<StudentDTO>(std); 
        }

        public Student Createstd(AddStudentDTO stdDTO)
        {
            
                    var STD = Mapper.Map<AddStudentDTO, Student>(stdDTO);
                repo.Add(STD);

                    return STD;
        }
        public Student EditStd(StudentDTO StdDTO)
        {  
                var std = Mapper.Map<StudentDTO, Student>(StdDTO);

                repo.Edit(std);

                return std;

        }
        public Student Deletestd(int id)
        {
            Student std = repo.GetById(id);
            
            repo.Remove(std);
            return std;
        }
    }
    
}