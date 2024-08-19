namespace Chat_Win_App.Controllers
{
    public class AuthController
    {
        private readonly UserController _userController;
        private readonly IAuthService _authService;
        public AuthController(UserController userController, IAuthService authService)
        {
            _userController = userController;
            _authService = authService;
        }
        public async Task<bool> LoginAsync(string username, string password)
        {
            var isAuthenticated = await _authService.AuthenticateAsync(username, password);
            if (isAuthenticated)
            {
                var user = await _authService.GetUserAsync(username);
                _userController.CurrentUser = user;
            }
            return isAuthenticated;
        }
    }
}