using EventosTec.Web.Data.Helpers;
using EventosTec.Web.Models;
using EventosTec.Web.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosTec.Web.Data
{
    public class SeedDb
    {
        private readonly DatadbContext dc;
        private readonly UserHelper uh;
        public SeedDb(DatadbContext db, UserHelper iuh)
        {
            dc = db;
            uh = iuh;
        }
        public async Task SeedAsync()
        {
            await dc.Database.EnsureCreatedAsync();
            await CheckRoles();
            var manager = await CheckUserAsync("Daniel", "Camacho", "admin@adminmail.com", "664 123 45 67",
                 "Admin");
            var customer = await CheckUserAsync("Leonardo", "Sañudo", "cliente@clientemail.com", "664 987 65 43",
                 "Client");
            await CheckManagerAsync(manager);
            await CheckClientAsync(customer);

        }

        private async Task CheckRoles()
        {
            await uh.CheckRoleAsync("Admin");
            await uh.CheckRoleAsync("Client");
        }
        private async Task CheckClientAsync(User user)
        {
            if (!dc.Clients.Any())
            {
                dc.Clients.Add(new Client { User = user });
                await dc.SaveChangesAsync();
            }


        }
        private async Task CheckManagerAsync(User user)
        {
            if (!dc.Managers.Any())
            {
                dc.Managers.Add(new Manager { User = user });
                await dc.SaveChangesAsync();
            }
        }
        private async Task<User> CheckUserAsync(string firstName, string lastName, string email,
    string phone, string rol)
        {
            var user = await uh.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FullName = firstName + " " + lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                };

                await uh.AddUserAssync(user, "admin1234");
                await uh.AddUserToRoleAsync(user, rol);
            }
            return user;
        }
    }
}
