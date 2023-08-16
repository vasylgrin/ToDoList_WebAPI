using ToDoList_WEB_Domain.DomainModels;
using ToDoList_WEB_Domain.Mappers;
using ToDoList_WEB_Entity.Models;
using ToDoList_WEB_Repositories.Interfaces;
using ToDoList_WEB_Repositories.Repositories;

namespace ToDoList_WEB_Services.Services
{
    public sealed class ToDoService
    {
        private readonly IRepositoryBase<ToDo> _toDoRepositoryBase;
        private readonly IRepositoryBase<User> _userRepositoryBase;

        public ToDoService()
        {
            _toDoRepositoryBase = new SQLiteRepositroy<ToDo>();
            _userRepositoryBase = new SQLiteRepositroy<User>();
        }

        public async Task<ToDoDTO> AddNewToDoAsync(AddToDoDTO addToDoDM)
        {
            if (addToDoDM is null)
            {
                throw new ArgumentNullException($"'{nameof(addToDoDM)}' cannot be null.", nameof(addToDoDM));
            }

            var user = await _userRepositoryBase.IncludeAsync(u=>u.Login == addToDoDM.login, u=>u.ToDoes);

            if(user is null)
            {
                throw new ArgumentNullException($"User with this login and password wasn't found.", nameof(user));
            }

            var toDo = new ToDo(user.Id, addToDoDM.topic);
            await _toDoRepositoryBase.AddAsync(toDo);
            return toDo.ToToDoDTO();
        }

        public async Task<ToDoDTO> ArchivateToDoAsync(int id)
        {
            var toDo = await _toDoRepositoryBase.FindAsync(id);

            toDo.IsArchived = !toDo.IsArchived;
            
            await _toDoRepositoryBase.UpdateAsync(toDo);
            return toDo.ToToDoDTO();
        }

        public async Task<ToDoDTO> DoneToDoAsync(int id)
        {
            var toDo = await _toDoRepositoryBase.FindAsync(id);

            if (toDo.IsDone)
            {
                toDo.IsDone = false;
                toDo.DateOfModification = DateTime.Now;
                toDo.IsModify = true;
            }
            else
            {
                toDo.IsDone = true;
                toDo.DateOfDone = DateTime.Now;
            }

            await _toDoRepositoryBase.UpdateAsync(toDo);
            return toDo.ToToDoDTO();
        }

        public async Task<bool> DeleteToDoAsync(int id)
        {
            var toDo = await _toDoRepositoryBase.FindAsync(id);
            await _toDoRepositoryBase.RemoveAsync(toDo);
            return true;
        }
    }
}
