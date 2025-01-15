namespace TaskApp 
{
    public class Task
    {
        public string Id {get; set;}
        public string Description {get; set;}
        public Priority Priority {get; set;}
        public DateTime LimitDate {get; set;}

        public bool IsComplete {get; set;}

       public Task(string id, string description, Priority priority, DateTime limitDate)
       {
        Id = id;
        Description = description;
        Priority = priority;
        LimitDate = limitDate;
        IsComplete = false;
       }
        
    } 

   
}