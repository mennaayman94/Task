using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models.DTOS
{
    public class TeacherDTO
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string Specification { get; set; }
        public string Mail { get; set; }
    }
}