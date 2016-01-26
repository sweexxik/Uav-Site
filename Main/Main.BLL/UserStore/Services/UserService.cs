using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Main.BLL.UserStore.DTO;
using Main.BLL.UserStore.Infrastructure;
using Main.BLL.UserStore.Interface;
using Microsoft.AspNet.Identity;
using UAV.Domain.UserStore.Entities;
using UAV.Domain.UserStore.Interfaces;

namespace Main.BLL.UserStore.Services
{
    /// <summary>
    /// Сервис по созданию и аутентификации пользователей
    /// </summary>
    public class UserService : IUserService
    {
        private IUnitOfWork Database { get; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            var user = await Database.UserManager.FindByEmailAsync(userDto.Email);

            if (user != null)
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");

            user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
            await Database.UserManager.CreateAsync(user, userDto.Password);
            // добавляем роль
            await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
            // создаем профиль клиента
            var clientProfile = new ClientProfile { Id = user.Id, Address = userDto.Address, Name = userDto.Name };
            Database.ClientManager.Create(clientProfile);
            await Database.SaveAsync();
            return new OperationDetails(true, "Регистрация успешно пройдена", "");
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            var user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        // начальная инициализация бд
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (var roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

