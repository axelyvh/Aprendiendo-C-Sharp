using AutoMapper;
using Azucena.Vasquez.Client.Areas.Identity.Data;
using Azucena.Vasquez.Client.Models;
using Azucena.Vasquez.Infrastructure.Data.University.Entities;
using Azucena.Vasquez.Infrastructure.Data.University.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Azucena.Vasquez.Client.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly UniversityUnitOfWork _universityUnitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UniversityService(
           UniversityUnitOfWork universityUnitOfWork,
           IMapper mapper,
           UserManager<ApplicationUser> userManager,
           IHttpContextAccessor httpContextAccessor
           )
        {
            _universityUnitOfWork = universityUnitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        #region Course 

        public bool CourseExists(int Id)
        {
            Courses model = _universityUnitOfWork._courseRepository.GetById(Id);
            return (model != null);
        }

        public CoursesViewModel GetCourse(int Id)
        {
            return _mapper.Map<CoursesViewModel>(_universityUnitOfWork._courseRepository.GetById(Id));
        }

        public void InsertCourse(CoursesViewModel model)
        {
            Courses course = _mapper.Map<Courses>(model);
            _universityUnitOfWork._courseRepository.Insert(course);
            _universityUnitOfWork.Save();
        }

        public void UpdateCourse(CoursesViewModel model)
        {
            Courses course = _mapper.Map<Courses>(model);
            _universityUnitOfWork._courseRepository.Update(course);
            _universityUnitOfWork.Save();
        }

        public void DeleteCourse(int Id)
        {
            Courses course = _universityUnitOfWork._courseRepository.GetById(Id);
            _universityUnitOfWork._courseRepository.Delete(course);
            _universityUnitOfWork.Save();
        }

        public List<CoursesViewModel> GetCourses()
        {
            return _mapper.Map<List<CoursesViewModel>>(_universityUnitOfWork._courseRepository.GetAll());
        }

        #endregion

        #region Score

        public bool ScoreExists(int Id)
        {
            Scores model = _universityUnitOfWork._scoreRepository.GetById(Id);
            return (model != null);
        }

        public void InsertScore(ScoresViewModel model)
        {
            Scores score = _mapper.Map<Scores>(model);
            _universityUnitOfWork._scoreRepository.Insert(score);
            _universityUnitOfWork.Save();
        }

        public void UpdateScore(ScoresViewModel model)
        {
            Scores score = _mapper.Map<Scores>(model);
            _universityUnitOfWork._scoreRepository.Update(score);
            _universityUnitOfWork.Save();
        }

        public ScoresViewModel GetScore(int Id) {
            return _mapper.Map<ScoresViewModel>(_universityUnitOfWork._scoreRepository.GetById(Id));
        }

        public void DeleteScore(int Id)
        {
            Scores score = _universityUnitOfWork._scoreRepository.GetById(Id);
            _universityUnitOfWork._scoreRepository.Delete(score);
            _universityUnitOfWork.Save();
        }

        public List<ScoresViewModel> GetScores()
        {
            string UserId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            return _mapper.Map<List<ScoresViewModel>>(_universityUnitOfWork._scoreRepository.GetScoresBy_User(UserId));
        }

        #endregion

        #region User

        public List<UserViewModel> GetUsers()
        {
            return _mapper.Map<List<UserViewModel>>(_universityUnitOfWork._userRepository.GetUsers());
        }

        public List<UserViewModel> GetUsersBy_Role(string Role)
        {
            return _mapper.Map<List<UserViewModel>>(_universityUnitOfWork._userRepository.GetUsersBy_Role(Role));
        }

        public UserViewModel GetUser(string Id)
        {
            UserViewModel user = _mapper.Map<UserViewModel>(_universityUnitOfWork._userRepository.GetUser(Id));
            user.RoleId = user.UserRoles.SingleOrDefault()?.RoleId;
            return user;
        }

        public async Task UpdateUser(UserViewModel model)
        {

            ApplicationUser User = await _userManager.FindByIdAsync(model.Id);
            User.FirstName = model.FirstName;
            User.LastName = model.LastName;
            User.Email = model.Email;

            IList<string> RolesUsuario = await _userManager.GetRolesAsync(User);
            await _userManager.RemoveFromRolesAsync(User, RolesUsuario);

            Roles role = _universityUnitOfWork._roleRepository.GetById(model.RoleId);
            await _userManager.AddToRoleAsync(User, role.Name);

            await _userManager.UpdateAsync(User);

            _universityUnitOfWork.Save();

        }

        public bool UserExists(string Id)
        {
            Users model = _universityUnitOfWork._userRepository.GetById(Id);
            return (model != null);
        }

        public async Task DeleteUser(string Id)
        {
            ApplicationUser User = await _userManager.FindByIdAsync(Id);
            IList<UserLoginInfo> logins = await _userManager.GetLoginsAsync(User);

            foreach (var login in logins)
            {
                await _userManager.RemoveLoginAsync(User, login.LoginProvider, login.ProviderKey);
            }

            IList<string> RolesUsuario = await _userManager.GetRolesAsync(User);
            await _userManager.RemoveFromRolesAsync(User, RolesUsuario);

            await _userManager.DeleteAsync(User);

            _universityUnitOfWork.Save();

        }

        public async Task InsertUser(UserViewModel model)
        {
            ApplicationUser User = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            await _userManager.CreateAsync(User, model.Clave);
            string emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(User);
            await _userManager.ConfirmEmailAsync(User, emailConfirmationToken);

            Roles role = _universityUnitOfWork._roleRepository.GetById(model.RoleId);
            await _userManager.AddToRoleAsync(User, role.Name);

            _universityUnitOfWork.Save();
        }

        #endregion

        #region Roles

        public List<RolesViewModel> GetRoles()
        {
            return _mapper.Map<List<RolesViewModel>>(_universityUnitOfWork._roleRepository.GetAll());
        }

        #endregion

    }
}
