using BOL_Business_Object_Layer_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Data_Access_Layer_.Repositories
{
    public interface IStudentRepository
    {
        Task<List<StudentsModel>> GetStudent();

        Task<StudentsModel> GetStudent(Guid studentId);


        Task<bool> Exists(Guid studentId);

        Task<StudentsModel> UpdateStudent(Guid studentId, StudentsModel student);

        Task<StudentsModel> DeleteStudent(Guid studentId);

        Task<StudentsModel> AddStudent(StudentsModel student);
    }

   

}
