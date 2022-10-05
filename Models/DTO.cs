using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesStudent.Models
{
    public class DTO
    {
        public Response GetAllStudents(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM aStudent", connection);
            DataTable dt = new DataTable(); 
            List<Student> lstStudents = new List<Student>();
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Student student = new Student
                    {
                        Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                        Name = Convert.ToString(dt.Rows[i]["Name"]),
                        Course = Convert.ToString(dt.Rows[i]["Course"]),
                        IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"])
                    };

                    lstStudents.Add(student);
                }
            }

            if (lstStudents.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Student Details available";
                response.ListStudents = lstStudents;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data found";
                response.ListStudents = null;
            }

            return response;
        }

        public Response GetStudentById(SqlConnection connection, int id)
        {
            Response response = new Response();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM aStudent WHERE ID = '" + id + "' AND IsActive = 1", connection);
            DataTable dt = new DataTable();
            _ = new Student();
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Student student = new Student
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    Name = Convert.ToString(dt.Rows[0]["Name"]),
                    Course = Convert.ToString(dt.Rows[0]["Course"]),
                    IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"])
                };

                response.StatusCode = 200;
                response.StatusMessage = "Student Detail available";
                response.Student = student;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data found";
                response.Student = null;
            }

            return response;
        }

        public Response AddStudent(SqlConnection connection, Student student)
        {
            Response response = new Response();
            SqlDataAdapter adapter = new SqlDataAdapter("INSERT into aStudent(Name, Course, IsActive, CreatedOn) VALUES('"+ student.Name + "', '"+ student.Course +"', '"+ student.IsActive +"', GETDATE)", connection);
            DataTable dt = new DataTable();
            _ = new Student();
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Student student = new Student
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    Name = Convert.ToString(dt.Rows[0]["Name"]),
                    Course = Convert.ToString(dt.Rows[0]["Course"]),
                    IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"])
                };

                response.StatusCode = 200;
                response.StatusMessage = "Student Detail available";
                response.Student = student;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data found";
                response.Student = null;
            }

            return response;
        }
    }
}
