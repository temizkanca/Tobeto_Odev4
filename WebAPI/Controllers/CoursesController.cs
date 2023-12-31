﻿using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // Attribute
    public class CoursesController : ControllerBase
    {
        //Loosely coupled / gevşek bağlılık
        //naming convention
        //IoC Container -- Inversion of Control / Değişimin kontrolü
        //Hiçbir katman diğer katmanların somut classlarına bağlı olmamalıdır. Diğer katmanların soyut sınıfları üzerinden işlem yapılmalıdır.
        ICourseService _courseService;       

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {             
            //Dependency chain --
            var result = _courseService.GetAll();
            if (result.Success)
            {
                return Ok(result);//200
            }
            return BadRequest(result);//400
        }
            
        [HttpGet("getbyid")] 
        public IActionResult GetById(int courseId)
        {
            var result = _courseService.GetById(courseId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Course course)
        {
            var result = _courseService.Add(course);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //Silme için Delete
        //Güncelleme için Update
        //Ama sektörde Delete ve Update için %99 oranla Post kullanılır.
    }
}
