using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models.DTOS
{
    public class AutoMapperProfile: Profile
    {
        //Auto Mapper
        public AutoMapperProfile()
        {
            Mapper.CreateMap<Student, StudentDTO>()
               .ForMember(dest => dest.teacher, opt => opt.MapFrom(src => src.Teacher));
            Mapper.CreateMap<StudentDTO, Student>();
            Mapper.CreateMap<AddStudentDTO, Student>();
            Mapper.CreateMap<Student, AddStudentDTO>();
            Mapper.CreateMap<AddTeacherDTO, Teacher>();
            Mapper.CreateMap<Teacher, AddTeacherDTO>();
            Mapper.CreateMap<Teacher, TeacherDTO>();
            Mapper.CreateMap<TeacherDTO, Teacher>();
            
        }
    }
}