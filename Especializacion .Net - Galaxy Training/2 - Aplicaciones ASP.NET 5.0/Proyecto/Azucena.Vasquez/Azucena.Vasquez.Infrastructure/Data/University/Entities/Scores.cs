﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Azucena.Vasquez.Infrastructure.Data.University.Entities
{
    public partial class Scores
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CourseId { get; set; }
        public int Score { get; set; }

        public virtual Courses Course { get; set; }
        public virtual Users User { get; set; }
    }
}