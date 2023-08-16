using ToDoList_WEB_Domain.DomainModels;
using ToDoList_WEB_Entity.Models;

namespace ToDoList_WEB_Domain.Mappers
{
    public static class UserMapper
    {
        public static User ToUser(this UserDTO userDM)
        {
            return new User
            {
                Email = userDM.Email,
                Name = userDM.Name,
                Login = userDM.Login,
                PasswordHash = userDM.Password,
            };
        }

        public static UserDTO ToUserDTO(this User user)
        {
            return new UserDTO
            {
                Email = user.Email,
                Name = user.Name,
                Login = user.Login,
                Password = user.PasswordHash,
            };
        }
    }
}
