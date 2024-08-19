using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Chat_Win_App
{
    public interface IAuthService
    {
        Task<bool> AuthenticateAsync(string username, string password);
        Task<User> GetUserAsync(string username);
    }
    public class AuthService : IAuthService
    {
        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            return await Task.FromResult(username == "admin" && password == "password");
        }
        public async Task<User> GetUserAsync(string username)
        {
            return await Task.FromResult(new User { Username = username });
        }
    }
}