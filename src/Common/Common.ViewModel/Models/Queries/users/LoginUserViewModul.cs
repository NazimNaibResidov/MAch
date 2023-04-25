namespace Common.ViewModel.Models.Quiers.users
{
    public class LoginUserViewModul
    {
        public LoginUserViewModul()
        {

        }
        public LoginUserViewModul(string email, string password, string token, bool isSuccess)
        {
            Email = email;
            Password = password;
            Token = token;
            IsSuccess = isSuccess;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public bool IsSuccess { get; set; }
    }
}