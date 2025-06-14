using System.Reflection;
using System.Text.Json;
using dummy_auth.idm.Models;

namespace dummy_auth.idm.Services;

public class UserManager : IUserManager {
    private readonly List<SystemUser> _users;

    public UserManager() {
        _users = new List<SystemUser>();

        var userStoreStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("dummy_auth.idm.Data.userStore.json");
        if (userStoreStream != null) { 
            JsonSerializer.Deserialize<SystemUser[]>(userStoreStream, new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true
            })?.ToList().ForEach(u => _users.Add(u));
        }
    }

    public void AddUser(SystemUser user) {
        _users.Add(user);
    }

    public SystemUser? GetUser(Guid id) {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    public IEnumerable<SystemUser> GetAllUsers() {
        return _users;
    }

    public void UpdateUser(SystemUser user) {
        var existingUser = GetUser(user.Id);
        if (existingUser != null) {
            _users.Remove(existingUser);
            _users.Add(user);
        }
    }

    public void DeleteUser(Guid id) {
        var user = GetUser(id);
        if (user != null) {
            _users.Remove(user);
        }
    }
}
