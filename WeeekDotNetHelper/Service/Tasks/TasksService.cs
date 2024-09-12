using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using WeeekDotNetHelper.Models.Tasks;

namespace WeeekDotNetHelper.Service.Tasks
{
    public class TasksService : ITasksService
    {
        private readonly IAppSettings _appSettings;
        private readonly IHttpClientFactory _clientFactory;

        public TasksService(IAppSettings appSettings, IHttpClientFactory clientFactory)
        {
            _appSettings = appSettings;
            _clientFactory = clientFactory;
        }

        private async Task<HttpClient> GetAuthenticatedClient()
        {
            HttpClient client = _clientFactory.CreateClient("apiWeeek");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _appSettings.WeeekApiToken);

            return client;
        }

        public async Task<List<TaskListItem>?> GetTasks(int? projectId = null, int? boardId = null, int? perPage = null, int? offset = null, bool? all = null)
        {
            string url = "tm/tasks";

            var queryParams = new List<string>();
            if (projectId.HasValue)
                queryParams.Add($"projectId={projectId.Value}");
            if (boardId.HasValue)
                queryParams.Add($"boardId={boardId.Value}");
            if (perPage.HasValue)
                queryParams.Add($"perPage={perPage.Value}");
            if (offset.HasValue)
                queryParams.Add($"offset={offset.Value}");
            if (all.HasValue)
                queryParams.Add($"all={all.Value}");

            if (queryParams.Count > 0)
                url += "?" + string.Join("&", queryParams);

            using (var client = await GetAuthenticatedClient())
            {
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception(errorMessage);
                }

                var responseData = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(responseData);

                bool isSuccess = jsonObject.Value<bool>("success");
                if (!isSuccess)
                    throw new Exception("API request was not successful.");

                bool hasMore = jsonObject.Value<bool>("hasMore");

                List<TaskListItem> tasks = jsonObject["tasks"]?.ToObject<List<TaskListItem>>();

                return tasks ?? new List<TaskListItem>();
            }
        }

        public async Task UpdateTask(int taskId,
            string? title = null,
            string? description = null,
            int? projectId = null,
            int? boardId = null,
            int? boardColumnId = null,
            int? priority = null,
            string? type = null,
            string? startDate = null,
            string? dueDate = null,
            string? startDateTime = null,
            string? dueDateTime = null,
            List<int>? tags = null,
            Dictionary<string, object>? customFields = null)
        {
            string url = $"tm/tasks/{taskId}";

            var taskData = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(title))
                taskData["title"] = title;
            if (!string.IsNullOrEmpty(description))
                taskData["description"] = description;
            if (projectId.HasValue)
                taskData["projectId"] = projectId.Value;
            if (boardId.HasValue)
                taskData["boardId"] = boardId.Value;
            if (boardColumnId.HasValue)
                taskData["boardColumnId"] = boardColumnId.Value;
            if (priority.HasValue)
                taskData["priority"] = priority.Value;
            if (!string.IsNullOrEmpty(type))
                taskData["type"] = type;

            // Date and DateTime validations
            // Cannot be provided with startDateTime or dueDateTime
            if (!string.IsNullOrEmpty(startDate) && string.IsNullOrEmpty(startDateTime) && string.IsNullOrEmpty(dueDateTime))
                taskData["startDate"] = startDate;
            // Cannot be provided with startDateTime or dueDateTime
            if (!string.IsNullOrEmpty(dueDate) && string.IsNullOrEmpty(startDateTime) && string.IsNullOrEmpty(dueDateTime))
                taskData["dueDate"] = dueDate;
            // Cannot be provided with startDate or dueDate
            if (!string.IsNullOrEmpty(startDateTime) && string.IsNullOrEmpty(startDate) && string.IsNullOrEmpty(dueDate))
                taskData["startDateTime"] = startDateTime;
            // Cannot be provided with startDate or dueDate
            if (!string.IsNullOrEmpty(dueDateTime) && string.IsNullOrEmpty(startDate) && string.IsNullOrEmpty(dueDate))
                taskData["dueDateTime"] = dueDateTime;

            if (tags != null && tags.Count > 0)
                taskData["tags"] = tags;

            if (customFields != null && customFields.Count > 0)
                taskData["customFields"] = customFields;

            using (var client = await GetAuthenticatedClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(taskData), Encoding.UTF8, "application/json");

                var response = await client.PutAsync(url, content);
                var responseData = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(responseData);

                bool isSuccess = jsonObject.Value<bool>("success");
                if (!isSuccess)
                    throw new Exception("API request was not successful.");

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception(errorMessage);
                }
            }
        }
    }
}
