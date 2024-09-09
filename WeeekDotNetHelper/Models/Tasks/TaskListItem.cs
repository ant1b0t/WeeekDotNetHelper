namespace WeeekDotNetHelper.Models.Tasks
{
    public class TaskListItem
    {

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// In minutes
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TaskType type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TaskPriority priority { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsCompleted { get; set; }
        /// <summary>
        /// ID of the user who created the task
        /// </summary>
        public string AuthorId { get; set; }
        /// <summary>
        /// ID of the user who is executing the task
        /// </summary>
        public string? UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? BoardId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? BoardColumnId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? ProjectId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? Image { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsPrivate { get; set; }
        /// <summary>
        /// Start date of the task in Y-m-d format
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// Start date of the task in ISO 8601 format
        /// </summary>
        public DateTime? StartDateTime { get; set; }
        /// <summary>
        /// Due date of the task in Y-m-d format
        /// </summary>
        public DateTime? DueDate { get; set; }
        /// <summary>
        /// Due date of the task in ISO 8601 format
        /// </summary>
        public DateTime? DueDateTime { get; set; }
        /// <summary>
        /// Date the task was created in ISO 8601 format
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Date the task was last updated in ISO 8601 format
        /// </summary>
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<int> Tags { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> Subscribers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> SubTasks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<WorkloadsItem> workloads { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<TaskCustomField> CustomFields { get; set; }

        public List<TaskAttachment> Attachments { get; set; }
    }


}
