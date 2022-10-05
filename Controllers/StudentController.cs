using AccesStudent.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        [Route("GetAllStudents")]

        public Response GetAllStudents()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ASConnection").ToString());
            //Response response = new Response();
            DTO dto = new DTO();
            Response response = dto.GetAllStudents(connection);
            return response;
        }

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

    }
}
