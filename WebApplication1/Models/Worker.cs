using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Worker :User
    {

       



        [Required(ErrorMessage = ("This feild is required"))]
        public string Work { get; set; }




        [Required(ErrorMessage = ("This feild is required"))]
        public string Experience { get; set; }




        [Required(ErrorMessage = ("This feild is required"))]
        public string Information { get; set; }

       [Required(ErrorMessage = ("This feild is required"))]
        public string Available { get; set; }

       

    }
}
