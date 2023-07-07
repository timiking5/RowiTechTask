global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
global using System.ComponentModel;

namespace RowiTechTask.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }
        [Required]
        [MinLength(136, ErrorMessage = "This description is too short to break the problem down")]
        [DisplayName("Long Description")]
        public string LongDescription { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required, DisplayName("Date of Creation")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required, DisplayName("Expiration Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}")]
        public DateTime ExpirationDate { get; set; }
        public int PayTypeId { get; set; }
        [ForeignKey("PayTypeId"), ValidateNever]
        public PayType PayType { get; set; }
        public int StateId { get; set; }
        [ForeignKey("StateId"), ValidateNever]
        public State State { get; set; }
        [ValidateNever]
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
