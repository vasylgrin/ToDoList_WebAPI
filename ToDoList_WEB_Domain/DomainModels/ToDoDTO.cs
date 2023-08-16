using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_WEB_Domain.DomainModels
{
    public sealed class ToDoDTO
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public bool isModify { get; set; } = false;
        public bool isDone { get; set; } = false;
        public bool isArchived { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        public DateTime DateOfModification { get; set; } = DateTime.Now;
        public DateTime DateOfDone { get; set; }
    }
}
