namespace RowiTechTask.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string RoleName { get; set; }
    }
}
