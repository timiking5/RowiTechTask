namespace RowiTechTask.Models
{
    public class Remark
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public int TaskId { get; set; }
        [ForeignKey("TaskId")]
        public Task Task { get; set; }
    }
}
