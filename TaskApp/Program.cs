using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskApp
{
    class Program
    {
        static  void Main(string[] args)
        {
            string filePath = "tasks.txt"; 
            var taskStorage = new FileTaskStorage(filePath);

            List<Task> tasks = taskStorage.LoadTasks();

            Console.WriteLine("Gestión de tareas");
            bool exit = false;
            
            while (!exit)
            {
                Console.WriteLine("\nSeleccione una opción:");
                Console.WriteLine("1. Ver tareas");
                Console.WriteLine("2. Agregar tarea");
                Console.WriteLine("3. Marcar tarea como completada");
                Console.WriteLine("4. Guardar y salir");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ShowTasks(tasks); // Asegúrate de que 'ShowTasks' esté correctamente definido
                        break;

                    case "2":
                         AddTask(tasks); // Asegúrate de que 'AddTask' esté correctamente definido
                        break;

                    case "3":
                         MarkTaskComplete(tasks); // Asegúrate de que 'MarkTaskComplete' esté correctamente definido
                        break;

                    case "4":
                        taskStorage.SaveTasks(tasks); // Asegúrate de que 'SaveTasks' esté correctamente definido
                        Console.WriteLine("Tareas guardadas. Saliendo...");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        static void ShowTasks(List<Task> tasks)
        {
            Console.WriteLine("\nLista de tareas:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.Id}: {task.Description} - {task.Priority} - {task.LimitDate.ToShortDateString()} - {(task.IsComplete ? "Completada" : "Pendiente")}");
            }
        }

        static void AddTask(List<Task> tasks)
        {
            Console.WriteLine("Ingrese descripción de la tarea:");
            string description = Console.ReadLine();

            Console.WriteLine("Ingrese prioridad (Low, Medium, High):");
            string priorityInput = Console.ReadLine();
            Priority priority = Enum.Parse<Priority>(priorityInput, true);

            Console.WriteLine("Ingrese fecha límite (YYYY-MM-DD):");
            DateTime limitDate = DateTime.Parse(Console.ReadLine());

            string id = Guid.NewGuid().ToString(); // Generación de un ID único para la tarea
            var newTask = new Task(id, description, priority, limitDate);

            tasks.Add(newTask);
            Console.WriteLine("Tarea agregada exitosamente.");
        }

        static void MarkTaskComplete(List<Task> tasks)
        {
            Console.WriteLine("Ingrese el ID de la tarea a marcar como completada:");
            string id = Console.ReadLine();

            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.IsComplete = true;
                Console.WriteLine("Tarea marcada como completada.");
            }
            else
            {
                Console.WriteLine("Tarea no encontrada.");
            }
        }
    }
}
