using BOL_Business_Object_Layer_.Models;
using DAL_Data_Access_Layer_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Business_Logic_Layer_
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public async Task<List<StudentsModel>> GetAllStudents()
        {
            return await studentRepository.GetStudent();
        }

        public async Task<StudentsModel> GetStudent(Guid studentId)
        {
            return await studentRepository.GetStudent(studentId);
        }

        public async Task<bool> Exists(Guid studentId)
        {
            return await studentRepository.Exists(studentId);
        }

        public async Task<StudentsModel> UpdateStudent(Guid studentId, StudentsModel student)
        {
            return await studentRepository.UpdateStudent(studentId, student);   
        }

        public async Task<StudentsModel> DeleteStudent(Guid studentId)
        {
            return await studentRepository.DeleteStudent(studentId);
        }

        public async Task<StudentsModel> AddStudent(StudentsModel request)
        { 
            return await studentRepository.AddStudent(request);
        }

    }
}
