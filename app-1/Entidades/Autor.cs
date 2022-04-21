using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app_1.Helpers;
namespace app_1.Entidades
{
    public class Autor
    {
        public int Id { get; set; }

        [PrimerLetraMayuscula]
        public string Name { get; set; }

        public List<Libro> Libros { get; set; }
    }
    /*
    public class Student
    {
        public int StudentID { get; set; }
        [Required(ErrorMessage = "Enter Student Name")]
        [StringLength(50, ErrorMessage = "Only 50 character are
        allowed")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Please enter Date of Birth")]
        public DateTime StudentDOB { get; set; }
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}",
        ErrorMessage = "Please enter Valid Email ID")]
        [Required(ErrorMessage = "Please enter Student EmailID")]
        public string StudentEmailID { get; set; }
        [Range(5000, 15000, ErrorMessage = "Please enter valid range")]
        [Required(ErrorMessage = "Please enter Student Fees")]
        public decimal StudentFees { get; set; }
       
        [Required(ErrorMessage = "Please enter Student Address")]
        [StringLength(50, ErrorMessage = "Only 50 character areallowed")]
        public string StudentAddress { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter ConfirmPassword")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not matching")]
        public string ConfirmPassword { get; set; }
    }
    */
}
