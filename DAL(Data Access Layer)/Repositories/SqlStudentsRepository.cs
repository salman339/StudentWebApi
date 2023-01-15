using BOL_Business_Object_Layer_;
using BOL_Business_Object_Layer_.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Data_Access_Layer_.Repositories
{
    public class SqlStudentsRepository : IStudentRepository
    {
        private readonly StudentDbContext context;

        public SqlStudentsRepository(StudentDbContext context)
        {
            this.context = context;
        }
        public async Task<List<StudentsModel>> GetStudent()
        {
           return await context.StudentsModel.ToListAsync();
        }

        public async Task<StudentsModel> GetStudent(Guid studentId)
        {
            return await context.StudentsModel.FirstAsync(x => x.Id == studentId);

            
        }

        public async Task<bool> Exists(Guid studentId)
        {
           return await context.StudentsModel.AnyAsync(x => x.Id == studentId);
        }

        public async Task<StudentsModel> UpdateStudent(Guid studentId, StudentsModel student)
        {
            var existingStudent = await GetStudent(studentId);

            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Email = student.Email;
                existingStudent.DateOfBirth = student.DateOfBirth;

                await context.SaveChangesAsync();

                return existingStudent;
            }
            else
            {
                throw new ArgumentException("Student not found", nameof(studentId));
            }
        }

        public async Task<StudentsModel> DeleteStudent(Guid studentId)
        {

            var existingStudent = await GetStudent(studentId);

            if (existingStudent != null)
            {
                
                context.StudentsModel.Remove(existingStudent);

                await context.SaveChangesAsync();

                return existingStudent;
            }
            else
            {
                throw new ArgumentException("Student not found", nameof(studentId));
            }
        }

        public async Task<StudentsModel> AddStudent(StudentsModel request)
        {
           var student = await context.StudentsModel.AddAsync(request);
            await context.SaveChangesAsync();
            return student.Entity;
        }
    }
}
