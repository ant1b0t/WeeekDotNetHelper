namespace WeeekDotNetHelper.Models.Tasks
{
    public class TaskCustomField
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TaskFieldType type  { get; set; }
        public object? Config { get; set; }
        public List<TaskFieldOption> Options { get; set; }
        public object? Value { get; set; }
    }
}
