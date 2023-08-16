using ToDoList_WEB_Entity.Interfaces;

namespace ToDoList_WEB_Entity.Base
{
    public abstract class ModelBase : IModelBase
    {
        public int Id { get; set; }
    }
}
