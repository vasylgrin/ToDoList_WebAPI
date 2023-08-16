using System.ComponentModel.DataAnnotations.Schema;
using ToDoList_WEB_Entity.Base;

namespace ToDoList_WEB_Entity.Models
{
    public class ToDo : ModelBase
    {
        public string Topic { get; set; }
        public bool IsModify { get; set; } = false;
        public bool IsDone { get; set; } = false;
        public bool IsArchived { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        public DateTime DateOfModification { get; set; } = DateTime.Now;
        public DateTime DateOfDone { get; set; }
        
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }


        public ToDo() { }

        public ToDo(int userId, string topic)
        {
            if (userId < 0)
            {
                throw new ArgumentNullException($"\"{nameof(userId)}\" cannot be less then null.", nameof(userId));
            }
            if (string.IsNullOrEmpty(topic))
            {
                throw new ArgumentNullException($"\"{nameof(topic)}\" cannot be null or whitespace.", nameof(topic));
            }

            UserId = userId;
            Topic = topic;
        }

        override public string ToString()
        {
            return $"{Id} {User} {Topic} {IsDone} {DateOfCreation} {DateOfModification} {DateOfDone}";
        }
    }
}
