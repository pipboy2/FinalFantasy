using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FinalFantasy.Models
{
    public class AccountDBContext : DbContext
    {
        public DbSet<UserAccount> userAccount { get; set; }
    }
}