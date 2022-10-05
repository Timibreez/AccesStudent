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
                    Student student = new Student();
                    student.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    student.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    student.Course = Convert.ToString(dt.Rows[i]["Course"]);
                    student.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);

                    lstStudents.Add(student);
                }
            }

            if (lstStudents.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Student Details available";
                response.listStudents = lstStudents;
            }

            return response;
        }
    }
}
