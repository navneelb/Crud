using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Models
{
    public class DataContext :  DbContext
    {
       
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Country>Countries { get; set; }
        public DbSet<State>States { get; set; }
        public DbSet<City>Cities { get; set; }
        public object Contries { get; internal set; }
       
    }
}
