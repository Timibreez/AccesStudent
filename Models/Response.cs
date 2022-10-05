using System.Collections.Generic;

namespace AccesStudent.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public Student Student { get; set; }
        public List<Student> ListStudents { get; set; }
    }
}
