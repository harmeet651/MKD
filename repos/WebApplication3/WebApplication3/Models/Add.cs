using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Add
    {
        [Required(ErrorMessage = "This field can not be empty.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public string message { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public string email { get; set; }

    }
}