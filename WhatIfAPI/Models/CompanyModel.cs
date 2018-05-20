using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VanHackAPI.Models
{
    public class CompanyModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }

        public ICollection<UserModel> Users { get; set; }
    }
}