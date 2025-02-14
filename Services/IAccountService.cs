using ABCMoneyTransfer.DTOs;
using Microsoft.AspNetCore.Identity;

namespace ABCMoneyTransfer.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterAsync(UserDTO dto);
        Task<string> LoginAsync(LoginDTO dto);
    }
}
