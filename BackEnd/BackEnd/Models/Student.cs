//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEnd.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public int StdId { get; set; }
        public string StdName { get; set; }
        public string Mail { get; set; }
        public Nullable<int> TeacherId { get; set; }
    
        public virtual Teacher Teacher { get; set; }
    }
}
