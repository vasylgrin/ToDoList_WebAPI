using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_WEB_Domain.DomainModels;
using ToDoList_WEB_Entity.Models;

namespace ToDoList_WEB_Domain.Mappers
{
    public static class ToDoMaper
    {

        public static ToDoDTO ToToDoDTO(this ToDo toDo)
        {
            return new ToDoDTO
            {
                Id = toDo.Id,
                Topic = toDo.Topic,
                DateOfCreation = toDo.DateOfCreation,
                DateOfDone = toDo.DateOfDone,
                DateOfModification = toDo.DateOfModification,
                isDone = toDo.IsDone,
                isArchived = toDo.IsArchived,
                isModify = toDo.IsModify,
                
            };
        }

        public static ToDo ToToDo(this ToDoDTO toDoDTO)
        {
            return new ToDo
            {
                Id = toDoDTO.Id,
                Topic = toDoDTO.Topic,
                DateOfCreation = toDoDTO.DateOfCreation,
                DateOfDone = toDoDTO.DateOfDone,
                DateOfModification = toDoDTO.DateOfModification,
                IsDone = toDoDTO.isDone,
                IsArchived = toDoDTO.isArchived,
                IsModify = toDoDTO.isModify,
            };
        }
    }
}
