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

        [HttpGet("refactorMyTasks")]
        public async Task<ActionResult<List<TaskListItem>>> RefactorMyTasks(int? projectId = null, int? boardId = null, int? perPage = null, int? offset = null)
        {
            Guid customDateId = new Guid("9cfe0cb0-3ce4-4418-a72a-acda6d9d5aab");
            Guid customStateId = new Guid("9cfe0cb0-5b5d-47c2-826a-b63d2bb0daff");
            int targetBoardId = 19;

            var tasks = await _tasksService.GetTasks(projectId: projectId, boardId: boardId, perPage: perPage, offset: offset);

            if (tasks == null)
                return NotFound();

            foreach(var task in tasks)
            {
                TaskCustomField taskDateCustomField = task.CustomFields.First(cf => cf.Id == customDateId);
                TaskCustomField taskStateCustomField = task.CustomFields.First(cf => cf.Id == customStateId);

                DateTime? dueDate = null;

                if (taskDateCustomField.Value != null)
                {
                    dueDate = taskDateCustomField.Value != null ? DateTime.Parse(taskDateCustomField.Value.ToString()) : null;
                }

                int boardColumnId = 70;

                if (taskStateCustomField.Value != null)
                {
                    switch (taskStateCustomField.Value)
                    {
                        // backlog
                        case "9cfdb888-cb5b-44e5-9d68-55bc028561ee":
                            boardColumnId = 70;
                            break;
                        // Not Started
                        case "9cfe0cb0-5dc2-4aac-8192-90b830256e2d":
                            boardColumnId = 67;
                            break;
                        // In Progress
                        case "9cfe0cb0-60d7-481f-803f-0d8b856b5d5b":
                            boardColumnId = 68;
                            break;
                        // Testing
                        case "9cfe0cb0-66db-435b-a4fe-99d740f0834c":
                            boardColumnId = 71;
                            break;
                        // Completed 🙌
                        case "9cfe0cb0-6426-444f-bbda-c6302eeb432d":
                            boardColumnId = 69;
                            break;
                        // Published
                        case "9cfe0cb0-6cd1-4335-ad46-be2f73d678f9":
                            boardColumnId = 72;
                            break;
                        // Paid
                        case "9cfe0cb0-6a13-4122-9f2b-bf588e1c8640":
                            boardColumnId = 73;
                            break;
                    }
                }

                await _tasksService.UpdateTask(task.Id,
                    boardId: targetBoardId,
                    boardColumnId: boardColumnId,
                    dueDate: dueDate.HasValue ? dueDate.Value.ToString("yyyy-MM-dd") : null
                    );
                await Task.Delay(1000);
            }

            return Ok();
        }
    }
}
