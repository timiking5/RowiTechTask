namespace RowiTechTask.Utility
{
    public class ProcessTaskStates
    {
        public void ProcessTasks(List<Models.Task> tasks)
        {
            foreach (var task in tasks)
            {
                if (task.ExpirationDate <= DateTime.Now)
                {
                    
                }
            }
        }
    }
}
