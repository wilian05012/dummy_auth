using dummy_auth.idm.Models;

namespace dummy_auth.idm.Services;

public interface IUserManager
{
    void AddUser(SystemUser user);
    SystemUser? GetUser(Guid id);
    IEnumerable<SystemUser> GetAllUsers();
    void UpdateUser(SystemUser user);
    void DeleteUser(Guid id);
}