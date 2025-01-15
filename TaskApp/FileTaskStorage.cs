using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TaskApp
{
    public class FileTaskStorage : ITaskStorage
    {
        private readonly string _filePath;

        public FileTaskStorage(string filePath)
        {
            this._filePath= filePath;
        }

        public List<Task> LoadTasks()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Task>();
            }

            var lines = File.ReadAllLines(_filePath);
            return lines.Select(lines =>
            {
                var parts = lines.Split('|');
                return new Task(
                    parts[0],
                    parts[1],
                    Enum.Parse<Priority>(parts[2]),
                    DateTime.Parse(parts[3])
                )
                {
                    IsComplete = bool.Parse(parts[4])
                };
            }).ToList();
        }

        public void SaveTasks(List<Task> tasks)
        {
            var lines = tasks.Select(task =>
                $"{task.Id}|{task.Description}|{task.Priority}|{task.LimitDate}|{task.IsComplete}");
            File.WriteAllLines(_filePath, lines);
        }
    }
    
}