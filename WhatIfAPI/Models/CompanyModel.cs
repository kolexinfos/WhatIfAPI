using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VanHackAPI.Models
{
    public class CompanyModel
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }

        public ICollection<UserModel> Users { get; set; }
    }
}