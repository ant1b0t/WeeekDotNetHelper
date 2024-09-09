namespace WeeekDotNetHelper.Models.Tasks
{
    public class TaskTimeEntry
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Type { get; set; }
        public bool IsOvertime { get; set; }
        public DateTime Date { get; set; }
        /// <summary>
        /// Time in minutes, cannot exceed 1440
        /// > 1
        /// < 1440
        /// </summary>
        public int Duration { get; set; }
    }
}
