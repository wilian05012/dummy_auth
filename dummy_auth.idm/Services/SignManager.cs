using System;

using dummy_auth.idm.Models;

namespace dummy_auth.idm.Services;

public class SignManager {
    public struct SignInResult {
        public bool Success { get; set; }
        public SystemUser? User { get; set; }
    }
    public IUserManager UserManager { get; }
    public SignManager(IUserManager userManager) {
        UserManager = userManager;
    }

    public SignInResult SignIn(SystemUser.UserCredentials credentials) {
        var user = UserManager.GetAllUsers().FirstOrDefault(u => 
            u.Credentials.Username == credentials.Username && 
            u.Credentials.Password == credentials.Password && 
            u.IsActive);

        return new SignInResult {
            Success = user != null,
            User = user
        };
    }
}
