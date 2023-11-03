using Microsoft.EntityFrameworkCore;
using LibraryASP.Models;
using LibraryASP.Services.Contract;
using LibraryASP.Context;
using Microsoft.Data.SqlClient;

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
            try
            {
                _dbContext.Usuarios.Add(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && ex.InnerException is SqlException sqlEx && sqlEx.Number == 2627)
                {
                    throw new Exception("Usuario ya registrado");
                }
                throw;
            }
        }
    }
}
