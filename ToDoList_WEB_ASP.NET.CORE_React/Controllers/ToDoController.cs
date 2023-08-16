using Microsoft.AspNetCore.Mvc;
using ToDoList_WEB_Services.Services;

namespace ToDoList_WEB_ASP.NET.CORE_React.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoService _toDoService;

        public ToDoController()
        {
            _toDoService = new ToDoService();
        }

        //[HttpGet, Route("get")]
        //public async Task<IActionResult> GetToDo()
        //{
        //    var todoCollection = await _toDoService.FillToDoListAsync();
        //    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, todoCollection));
        //}
    }
}
