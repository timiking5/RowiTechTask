using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
namespace RowiTechTask.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string EmailAddress { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        /// <summary>
        /// It is required here to be able to implement
        /// one-to-many relationship.
        /// User can have multiple tasks, but task has only
        /// one user working on it
        /// </summary>
        public ICollection<Task> Tasks { get; set; }
    }
}
