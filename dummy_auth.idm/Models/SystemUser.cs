using System;

namespace dummy_auth.idm.Models;


public class SystemUser {
    public class UserCredentials {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserCredentials(string username, string password) {
            Username = username;
            Password = password;
        }
    }

    public class UserProfile {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public UserProfile(string firstName, string lastName, string email) {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
    public Guid Id { get; set; }

    public bool IsActive { get; set; }

    public UserCredentials Credentials { get; set; }
    public UserProfile Profile { get; set; }

    public SystemUser(Guid id, bool isActive, UserCredentials credentials, UserProfile profile) {
        Id = id;
        IsActive = isActive;
        Credentials = credentials;
        Profile = profile;
    }
}
