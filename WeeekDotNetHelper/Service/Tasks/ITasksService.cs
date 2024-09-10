using WeeekDotNetHelper.Models.Tasks;

namespace WeeekDotNetHelper.Service.Tasks
{
    public interface ITasksService
    {
        Task<List<TaskListItem>?> GetTasks(int? projectId = null, int? boardId = null, int? perPage = null, int? offset = null, bool? all = null);
        Task UpdateTask(int taskId, string? title = null, string? description = null, int? projectId = null, int? boardId = null, int? boardColumnId = null, int? priority = null, string? type = null, string? startDate = null, string? dueDate = null, string? startDateTime = null, string? dueDateTime = null, List<int>? tags = null, Dictionary<string, object>? customFields = null);
    }
}