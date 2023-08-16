using System;
using ToDoList_WEB_Entity.Base;

namespace ToDoList_WEB_Entity.Models
{
    public class User : ModelBase
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<ToDo> ToDoes { get; set; } = new List<ToDo>();


        public User() { }
        public User(string name, string login, string email, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentNullException($"'{nameof(login)}' cannot be null or whitespace.", nameof(login));
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException($"'{nameof(email)}' cannot be null or whitespace.", nameof(email));
            }
            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                throw new ArgumentNullException($"'{nameof(passwordHash)}' cannot be null or whitespace.", nameof(passwordHash));
            }

            Name = name;
            Login = login;
            Email = email;
            PasswordHash = passwordHash;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as User);
        }
        public bool Equals(User user)
        {
            return user != null
                && user.Name == Name
                && user.Login == Login
                && user.Email == Email
                && user.PasswordHash == PasswordHash
                && user.ToDoes == ToDoes;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Login, Email, PasswordHash, ToDoes);
        }

    }
}
