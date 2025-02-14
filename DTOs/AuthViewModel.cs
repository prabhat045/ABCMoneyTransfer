namespace ABCMoneyTransfer.DTOs
{
    public class AuthViewModel
    {
        public UserDTO Register { get; set; } = new UserDTO();
        public LoginDTO Login { get; set; } = new LoginDTO();
    }
}
