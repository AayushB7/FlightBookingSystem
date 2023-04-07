using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FlightBookingSystem.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "The password must be at least {2} characters long")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$", 
            ErrorMessage = "Password must contain at least 8 characters, 1 uppercase letter, 1 lowercase letter, 1 number, and 1 special character(such as @, #, $, etc.)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /*[Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }*/

        [Compare("Password", ErrorMessage = "The passwords do not match!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        public UserRole Role { get; set; } = UserRole.User;


        public virtual ICollection<Booking> Bookings { get; set; }

       

        
    }
}
