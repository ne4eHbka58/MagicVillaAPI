using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> UpdateAsync(User entity);
    }
}
