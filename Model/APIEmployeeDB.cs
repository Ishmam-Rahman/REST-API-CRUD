using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_CRUDE.Model
{
    public class APIEmployeeDB: DbContext
    {
        public APIEmployeeDB(DbContextOptions<APIEmployeeDB>options): base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
    }
}
