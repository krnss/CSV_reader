using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CVS_data_reader.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext() : base("DbConnection")
        { }

        public DbSet<Person> Persons { get; set; }
    }
}