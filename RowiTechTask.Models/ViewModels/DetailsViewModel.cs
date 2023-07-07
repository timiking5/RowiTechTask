namespace RowiTechTask.Models.ViewModels
{
    public class DetailsViewModel
    {
        [ValidateNever]
        public Task Task { get; set; }
        [ValidateNever]
        public List<Solution> Solutions { get; set; }
        public Solution? UserSolution { get; set; }
    }
}
