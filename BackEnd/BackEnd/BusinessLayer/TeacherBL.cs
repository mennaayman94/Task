using AutoMapper;
using BackEnd.Models;
using BackEnd.Models.DTOS;
using BackEnd.RepositoryImp;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BackEnd.BusinessLayer
{
    public class TeacherBL
    {
        Repository<Teacher> repo = new Repository<Teacher>(new QualityStandardEntities());
        QualityStandardEntities db = new QualityStandardEntities();
        public IEnumerable<TeacherDTO> GetAllTeachers()
        {
            var teacher = repo.GetAll().Include(x=>x.Students);
            return Mapper.Map<List<TeacherDTO>>(teacher);
        }
        public TeacherDTO GetOne(int id)
        {
            var teacher = repo.GetById(id);
            return Mapper.Map<TeacherDTO>(teacher);
        }
        public Teacher Createteacher(AddTeacherDTO teachDTO)
        {
            
                var teacher = Mapper.Map<AddTeacherDTO, Teacher>(teachDTO);
                repo.Add(teacher);

                return teacher;

        }
        public Teacher Editteacher(TeacherDTO teachDTO)
        {

            var teacher = Mapper.Map<TeacherDTO, Teacher>(teachDTO);

            repo.Edit(teacher);

            return teacher;


        }
        public Teacher Deleteteacher(int id)
        {
            Teacher teacher = repo.GetById(id);
            repo.Remove(teacher);
            return teacher;
        }
    }
}