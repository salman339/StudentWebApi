using BOL_Business_Object_Layer_.Models;
using Microsoft.EntityFrameworkCore;

namespace BOL_Business_Object_Layer_
{
    public class StudentDbContext: DbContext
    {
      

        public StudentDbContext(DbContextOptions<StudentDbContext> options): base(options)
        {

           
        }

        public DbSet<StudentsModel> StudentsModel { get; set; }
    }
}