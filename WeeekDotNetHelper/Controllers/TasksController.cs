using Microsoft.AspNetCore.Mvc;
using WeeekDotNetHelper.Models.Tasks;
using WeeekDotNetHelper.Service.Tasks;

namespace WeeekDotNetHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet("getTasks")]
        public async Task<ActionResult<List<TaskListItem>>> GetTasks(int? projectId = null, int? boardId = null, int? perPage = null, int? offset = null, bool? all = null)
        {
            var tasks = await _tasksService.GetTasks(projectId: projectId, boardId: boardId, perPage: perPage, offset: offset, all: all);

            if (tasks == null)
                return NotFound();

            return Ok(tasks.AsQueryable());
        }
    }
}
