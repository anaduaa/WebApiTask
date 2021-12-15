﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User
    {


        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = ("This feild is required"))]
        public string nname { get; set; }
        [Required(ErrorMessage = ("This feild is required"))]
      
        [DataType(DataType.Password)]
        public string pass { get; set; }

        [Compare("pass", ErrorMessage = "Passwords are different")]
        [DataType(DataType.Password)]
        public String CoPassword { get; set; }


        [Required(ErrorMessage = ("This feild is required"))]
        [MaxLength(13, ErrorMessage = ("you should enter a valid phone number"))]
        public string phone { get; set; }
        
        public string token { get; set; }
       
        public string country { get; set; }
        [Required(ErrorMessage = ("This feild is required"))]
        public string NameFirst { get; set; }
        [Required(ErrorMessage = ("This feild is required"))]
        public string NameLast { get; set; }
        [Required(ErrorMessage = ("This feild is required"))]
        public  static string Role { get; set; }


    }

}
