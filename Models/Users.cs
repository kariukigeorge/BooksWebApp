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

        [Required(ErrorMessage ="Please enter the user ID")]
        [Display(Name = "User Identification")]
        public int UsersID { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage ="Please Enter Your First Name")]
        public string first_name { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please Enter Your Last Name")]
        public string last_name { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please Enter Your Phone Number")]
        public string phone_number { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Enter Your Email")]
        public string email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter Your Password")]
        public string password { get; set; }

        [NotMapped] // Does not effect with your database
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string authorization { get; set; }

        public DateTime date_created { get; set; }
        
        public string created_by { get; set; }

        public DateTime date_deleted { get; set; }

        public string deleted_by { get; set; }

        public string status { get; set; }

        public List<Books> Book {get; set;}
    }

    public class Books
    {
        [Required(ErrorMessage = "Please Enter The Books ID")]
        public string BooksID { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please Enter The Books Name")]
        public string name { get; set; }
        [Display(Name = "Author")]
        [Required(ErrorMessage = "Please Enter The Author")]
        public string author { get; set; }
        [Required(ErrorMessage = "Please Enter The Isbn Number")]
        [Display(Name = "Isbn Number")]
        public string isbn_number { get; set; }
        [Display(Name = "URL")]
        [Required(ErrorMessage = "Please Enter The URL")]
        public string url { get; set; }
        [Required]
        public DateTime date_created { get; set; }
        [Required]
        public string created_by { get; set; }

        public DateTime date_updated { get; set; }
        [Display(Name = "Status")]
        [Required(ErrorMessage = "Please Enter The Status: Available or Deleted")]
        public string status { get; set; }
        [Required]
        public int UsersID { get; set; }
        public Users user { get; set; }
    }
}
