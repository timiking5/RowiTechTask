namespace RowiTechTask.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string StateName { get; set; }
    }
}
