using ERP_IT13.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace ERP_IT13.Infrastructure.Services
{
    public interface IAuthService
    {
        Task<User?> LoginAsync(string username, string password);
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
    }

    public class AuthService : IAuthService
    {
        private readonly ERPDbContext _db;

        public AuthService(ERPDbContext db)
        {
            _db = db;
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username && u.IsActive);
            if (user is null)
            {
                return null;
            }

            return VerifyPassword(password, user.PasswordHash) ? user : null;
        }

        public string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(bytes);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            return string.Equals(HashPassword(password), passwordHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
