using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PetAccessoriesOnlineShop.Models
{
    public class LoginModel
    {
        [Key]
        public long ID { get; set; }

        [Required(ErrorMessage ="Enter UserName!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter Password!")]
        public string Password { get; set; }
    }
}