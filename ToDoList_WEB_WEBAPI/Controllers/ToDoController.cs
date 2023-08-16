using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList_WEB_Domain.DomainModels;
using ToDoList_WEB_Services.Services;

namespace ToDoList_WEB_WEBAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoService _toDoService = new();


        [HttpPost, Route("AddToDo")]
        public async Task<IActionResult> AddToDo([FromBody] AddToDoDTO addToDoDM)
        {

            var toDo = await _toDoService.AddNewToDoAsync(addToDoDM);
            if (toDo is null)
            {
                return BadRequest("Something went wrong.");
            }

            return Ok();
        }


        [HttpPut, Route("archiveToDo/{id}")]
        public async Task<IActionResult> ArchivateToDo(int id)
        {
            var toDo = await _toDoService.ArchivateToDoAsync(id);
            if (toDo is null)
            {
                return BadRequest("Something went wrong.");
            }

            return Ok(toDo);
        }

        [HttpDelete, Route("deleteToDo/{id}")]
        public async Task<IActionResult> DeleteToDo(int id)
        {
            var isDel = await _toDoService.DeleteToDoAsync(id);
            if (!isDel)
            {
                return BadRequest("Something went wrong.");
            }

            return Ok("The todo was deleted.");
        }


        [HttpPut, Route("doneToDo/{id}")]
        public async Task<IActionResult> DoneToDo(int id)
        {
            var toDo = await _toDoService.DoneToDoAsync(id);
            if (toDo is null)
            {
                return BadRequest("Something went wrong.");
            }

            return Ok(toDo);
        }
    }
}
