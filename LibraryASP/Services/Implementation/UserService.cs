using Microsoft.EntityFrameworkCore;
using LibraryASP.Models;
using LibraryASP.Services.Contract;
using LibraryASP.Context;

namespace LibraryASP.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly BibliotecaDbContext _dbContext;
        public UserService(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetUsuario(string email, string passwd)
        {
            Usuario user_find = await _dbContext.Usuarios.Where(u => u.Email == email && u.Passwd == passwd)
                .FirstOrDefaultAsync();

            return user_find;
        }

        public async Task<Usuario> SaveUsuario(Usuario model)
        {
            _dbContext.Usuarios.Add(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }
    }
}
