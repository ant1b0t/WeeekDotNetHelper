namespace WeeekDotNetHelper.Models.Tasks
{
    public class TaskAttachment
    {
        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        public TaskAttachmentService Service { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Attachment URL. If service is weeek, this URL will be available for an hour
        /// </summary>
        public Uri? Url { get; set; }
        /// <summary>
        /// The size of the attachment in bytes. Only present when service is weeek
        /// </summary>
        public int? Size { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
