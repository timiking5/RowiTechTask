global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RowiTechTask.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string ShortDescription { get; set; }
        [Required]
        public string LongDescription { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        public int PayTypeId { get; set; }
        [ForeignKey("PayTypeId")]
        public PayType PayType { get; set; }
        public int StateId { get; set; }
        [ForeignKey("StateId")]
        public State State { get; set; }
        /// <summary>
        /// Task has a single user working on it
        /// But User has multiple tasks he can work on
        /// </summary>
        [ValidateNever]
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public User User { get; set; }
        [ValidateNever]
        public ICollection<Tag> Tags { get; set; }
    }
}
