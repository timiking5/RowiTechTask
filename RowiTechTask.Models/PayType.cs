namespace RowiTechTask.Models
{
    public class PayType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string PayTypeName { get; set; }
    }
}
