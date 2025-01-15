namespace TaskApp
{
    public interface ITaskStorage
    {
        List<Task> LoadTasks();
        void SaveTasks(List<Task> tasks);
    }
}