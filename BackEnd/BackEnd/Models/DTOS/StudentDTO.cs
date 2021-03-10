using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models.DTOS
{
    public class StudentDTO
    {
        public int StdId { get; set; }
        public string StdName { get; set; }
        public string Mail { get; set; }
        public Nullable<int> TeacherId { get; set; }
        public virtual TeacherDTO teacher { get; set; }

    }
}