using BOL_Business_Object_Layer_.Models;

namespace BLL_Business_Logic_Layer_
{
    public interface IStudentService
    {

        Task<List<StudentsModel>> GetAllStudents();

        Task<StudentsModel> GetStudent(Guid studentId);

        Task<bool> Exists(Guid studentId);

        Task<StudentsModel> UpdateStudent(Guid studentId, StudentsModel student);

        Task<StudentsModel> DeleteStudent(Guid studentId);

        Task<StudentsModel> AddStudent(StudentsModel student);


    }
}