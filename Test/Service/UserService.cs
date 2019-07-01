using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.Models;

namespace Test.Service
{
    public class UserService
    {
        #region Global Declaration
        TestEntities dbContext = new TestEntities();
        #endregion

        #region Public Methods
        /// <summary>
        /// Check user exists or not by Email Id and Password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User CheckLogin(string email, string password)
        {
            User user = new User();
            var query = from u in dbContext.Users
                        where u.Email.ToLower().Equals(email.ToLower()) && u.Password.Equals(password)
                        select u;

            if (query != null)
            {
                user = query.FirstOrDefault();
            }
            return user;
        }
        /// <summary>
        /// Get all roles for an user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<UserRoleViewModel> GetAllUserRoles(int userId)
        {
            IList<UserRoleViewModel> userRoles = new List<UserRoleViewModel>();
            var query = from ur in dbContext.UserRoleMappings
                        join u in dbContext.Users on ur.UserId equals u.UserId
                        join r in dbContext.Roles on ur.RoleId equals r.RoleId
                        select new UserRoleViewModel
                        {
                            UserId = u.UserId,
                            RoleId = r.RoleId,
                            RoleName = r.Name,
                            Email = u.Email

                        };

            if (query != null)
                userRoles = query.ToList();

            return userRoles;

        }

       
        #endregion

    }
}