using System.Diagnostics;

namespace RowiTechTask.Models.ViewModels
{
    public class TaskViewModel
    {

        public Task Task { get; set; }
        public List<PayType> PayTypes { get; set; }
        public List<State> States { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
