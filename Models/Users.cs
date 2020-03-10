using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaterMS.Models
{
    public class Users
    {
        [Required]
        public int UsersID { get; set; }
      
        [Required(ErrorMessage ="Please Enter Your First Name"), Display(Name ="Your First Name:")]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }
        [Required]
        public string phone_number { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }

        [NotMapped] // Does not effect with your database
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public DateTime date_created { get; set; }
        [Required]
        public string created_by { get; set; }

        public DateTime date_deleted { get; set; }

        public string deleted_by { get; set; }

        public string status { get; set; }

        public List<Books> Book {get; set;}
    }

    public class Books
    { 
        [Required]
        public string BooksID { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string author { get; set; }
        [Required]
        public string isbn_number { get; set; }

        public string url { get; set; }
        [Required]
        public DateTime date_created { get; set; }
        [Required]
        public string created_by { get; set; }

        public DateTime date_deactivated { get; set; }

        public string deactivated_by { get; set; }

        public string status { get; set; }
        [Required]
        public int UsersID { get; set; }
        public Users user { get; set; }
    }
}
