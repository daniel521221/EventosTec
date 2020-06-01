using EventosTec.Web.Models;
using EventosTec.Web.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosTec.Web.Data.Helpers
{//Esta es la interfaz
    public interface UserHelper
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<IdentityResult> AddUserAssync(User user, string Password);
        Task CheckRoleAsync(string roleName);// si ya existe el rol lo revisa y no lo agrega
        Task AddUserToRoleAsync(User user, string roleName);//todos los usuarios tendran roles para accesar 
        Task<bool> IsUserInRoleAsync(User user, string roleName);
        Task<SignInResult> LoginAsync(LoginViewModel model);
        Task LogoutAsync();
        Task<SignInResult> ValidatePasswordAsync(User user, string password);

    }
}
