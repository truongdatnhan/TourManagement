using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string HoNV { get; set; }
        public string TenNV { get; set; }
        public DateTime DoBNV { get; set; }
        public List<PhieuMuon> PhieuMuons { get; set; }
        public List<PhieuPhat> PhieuPhats { get; set; }
    }
}