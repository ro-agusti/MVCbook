using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using MVCBook.Models;

namespace MVCBook.Data
{
    public class DbBookMVCContext:DbContext
    {
        public DbBookMVCContext() : base("KeyDB") { }
        public DbSet<Book> Books { get; set; }
    }
}