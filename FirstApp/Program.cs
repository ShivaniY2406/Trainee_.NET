using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskList
{
    internal class SimpleTaskList
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();
            char ch;
            do
            {
                Console.WriteLine("Simple Task List Application");
                Console.WriteLine("1. Create a task");
                Console.WriteLine("2. Read task");
                Console.WriteLine("3. Update task");
                Console.WriteLine("4.Delete task");
                Console.WriteLine("5.Exit");
                Console.Write("Enter your choice:");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: CreateTask(tasks);
                        break;
                    case 2: ReadTask(tasks);
                        break;
                    case 3: UpdateTask(tasks);
                        break;
                    case 4: DeleteTask(tasks);
                        break;
                    case 5: System.Environment.Exit(1);
                        break;
                    default: Console.WriteLine("Invalid Input");
                        break;
                }
                Console.WriteLine("Do you want to continue: y or n");
                ch = Console.ReadKey().KeyChar;
            } while(ch == 'y' || ch=='Y');
        }
         static void CreateTask(List<Task> tasks)
        {
            Console.WriteLine("Enter the title of your task");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the description");
            string description = Console.ReadLine();
            tasks.Add(new Task(title, description));
            Console.WriteLine("Task Created Successfully..");
        }

        static void ReadTask(List<Task> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No task is added");
            }
            else {
                foreach(var eachtask in tasks)
                {
                    Console.WriteLine($"Title : {eachtask.title} , Description : {eachtask.description}");
                }
            }
        }

        static void UpdateTask(List<Task> tasks)
        {
            Console.WriteLine("Enter the title of the task you want to update:");
            string title = Console.ReadLine();
            int index=-1;
                for(int i = 0; i < tasks.Count; i++)
                {
                    if (tasks[i].title == title)
                    {
                        index = i; 
                        break;
                    }
                }
    
            if (index != -1)
            {
                Console.WriteLine("Enter the new title :");
                string newtitle = Console.ReadLine();
                Console.WriteLine("Enter new description:");
                string newdesc = Console.ReadLine();
                tasks[index].title = newtitle;
                tasks[index].description = newdesc;
                Console.WriteLine("Updated Successfully");
            }
            else
            {
                Console.WriteLine("No such task to update");
            }
        }

        static void DeleteTask(List<Task> tasks)
        {
            Console.WriteLine("Enter the title of the task to be deleted:");
            string giventitle = Console.ReadLine();
            int index = -1;
            for(int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].title == giventitle)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.Write("No such task to be deleted");
            }
            else
            {
                tasks.RemoveAt(index);
                Console.WriteLine("Task deleted successfully");
            }
        }
    }


    internal class Task
    {
        public String title;
        public String description;

        public Task(string newtitle, string newdesc)
        {
            title = newtitle;
            description = newdesc;
        }
    }
}
