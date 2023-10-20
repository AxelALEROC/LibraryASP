using Microsoft.EntityFrameworkCore;
using LibraryASP.Models;
namespace LibraryASP.Services.Contract
{
    public interface IUserService
    {
        Task<Usuario> GetUsuario(string email, string passwd);
        Task<Usuario> SaveUsuario(Usuario model);
    }
}
