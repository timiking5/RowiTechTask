using System.Security.Policy;

namespace RowiTechTask.Models
{
    public class Solution
    {
        [Key]
        public int Id { get; set; }
        [Required, DisplayName("Your Solution"), MinLength(10)]
        public string Content { get; set; }
        [Required, DisplayName("Post Date")]
        public DateTime CreatedDate { get; set; }
        [Required, ValidateNever]
        public string UserId { get; set; }
        [ForeignKey("UserId"), ValidateNever]
        public ApplicationUser User { get; set; }
        [Required]
        public int TaskId { get; set; }
        [ForeignKey("TaskId"), ValidateNever]
        public Task Task { get; set; }
        public int? RemarkId { get; set; }
        [ForeignKey("RemarkId"), ValidateNever]
        public Remark? Remark { get; set; }
    }
}
