using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace ModelsLayer.Models.ViewModels
{
    public class AssignedCoursesViewModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public bool isAssigned { get; set; }
    }
}