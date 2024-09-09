namespace WeeekDotNetHelper.Models.Tasks
{
    public class TaskFieldOption
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TaskFieldOptionColor Color { get; set; }
    }
}
