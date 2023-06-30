namespace RowiTechTask.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string TagName { get; set; }
        [ValidateNever]
        public ICollection<Task> Tasks { get; set; }
    }
}
