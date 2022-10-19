using AccesStudent.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Data.SqlClient;

namespace AccesStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        // Get information of all students
        public Response GetAllStudents()
        {
            Log.Information("Getallstudents: ");
            try
            {
                Log.Information("connect To Database");
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ASConnection").ToString());
                //Response response = new Response();
                DTO dto = new DTO();
                Response response = dto.GetAllStudents(connection);
                return response;
            }
            catch(Exception ex)
            {
                Log.Error($"{ex.Message}");
                return new Response{
                    StatusMessage = $"{ex.Message}",

                };
                throw;
            }
            
        }

        // Get student by ID
        [HttpGet]
        [Route("GetStudentById/{id}")]

        public Response GetStudentById(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ASConnection").ToString());
            //Response response = new Response();
            DTO dto = new DTO();
            Response response = dto.GetStudentById(connection, id);
            return response;
        }

        //Add a new student 
        [HttpPost]
        [Route("AddStudent")]

        public Response AddStudent(Student student)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ASConnection").ToString());
            //Response response = new Response();
            DTO dto = new DTO();
            Response response = dto.AddStudent(connection, student);
            return response;
        }

        //Update an existing student
        [HttpPut]
        [Route("EditStudent")]

        public Response EditStudent(Student student)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ASConnection").ToString());
            //Response response = new Response();
            DTO dto = new DTO();
            Response response = dto.EditStudent(connection, student);
            return response;
        }

        // Delete a student by ID
        [HttpDelete]
        [Route("DeleteStudent/{id}")]

        public Response DeleteStudent(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ASConnection").ToString());
            //Response response = new Response();
            DTO dto = new DTO();
            Response response = dto.DeleteStudent(connection, id);
            return response;
        }

    }
}
