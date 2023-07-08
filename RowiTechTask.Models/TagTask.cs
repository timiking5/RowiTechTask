namespace RowiTechTask.Models
{
    public class TagTask
    {
        [Key]
        public int TaskId { get; set; }
        [Key]
        public int TagId { get; set; }
        [ForeignKey("TagId"), ValidateNever]
        public Tag Tag { get; set; }
        [ForeignKey("TaskId"), ValidateNever]
        public Task Task { get; set; }
    }
}
