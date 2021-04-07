using Azucena.Vasquez.Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azucena.Vasquez.Client.Services
{
    public interface IUniversityService
    {

        #region Score

        void InsertScore(ScoresViewModel model);
        void UpdateScore(ScoresViewModel model);
        void DeleteScore(int Id);
        ScoresViewModel GetScore(int Id);
        List<ScoresViewModel> GetScores();
        bool ScoreExists(int Id);

        #endregion

        #region Course

        void InsertCourse(CoursesViewModel model);
        void UpdateCourse(CoursesViewModel model);
        CoursesViewModel GetCourse(int Id);
        void DeleteCourse(int Id);
        List<CoursesViewModel> GetCourses();
        bool CourseExists(int Id);

        #endregion

        #region Users

        List<UserViewModel> GetUsersBy_Role(string Role);
        List<UserViewModel> GetUsers();
        UserViewModel GetUser(string Id);
        Task InsertUser(UserViewModel model);
        Task UpdateUser(UserViewModel model);
        bool UserExists(string Id);
        Task DeleteUser(string Id);

        #endregion

        #region

        List<RolesViewModel> GetRoles();

        #endregion

    }
}