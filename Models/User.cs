using BPPR_Demo.Helpers;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPPR_Demo.Models
{
    public class User : UserDetail
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }


    public class UserDetail
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }
        public bool Active { get; set; } = false;
    }
}
