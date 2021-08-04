using DataLayer.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace klas_mvc.Areas.Lecturer.Controllers
{
    public class HomeworkController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeworkController(ApplicationDbContext db)
        {
            _db = db;
        }


    }
}