global using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace RowiTechTask.Models.ViewModels
{
    public class TaskViewModel
    {
        public Task Task { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> PayTypes { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Tags { get; set; }
        [DisplayName("Tags")]
        public int[] tagIds { get; set; }
    }
}
