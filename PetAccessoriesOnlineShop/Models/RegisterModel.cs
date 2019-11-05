using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetAccessoriesOnlineShop.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { get; set; }

        [Required(ErrorMessage ="Enter UserName!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter Password!")]
        [StringLength(30,MinimumLength =6, ErrorMessage = "StringLength 5 < x < 30")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter ConfirmPassword!")]
        [Compare("Password",ErrorMessage ="Compare with password fail!")]
        public string ConfirmpPassword { get; set; }

        [Required(ErrorMessage = "Enter Name!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Address!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter Email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Phone!")]
        public string Phone { get; set; }

        //public DateTime Birthday { get; set; }


    }
}