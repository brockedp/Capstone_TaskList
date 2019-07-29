using System;
using System.Collections.Generic;

namespace TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> options = new List<string>
            {
                "List tasks","Add task","Delete task","Mark task complete","Quit"
            };
            List<TaskList> userTaskList = new List<TaskList>
            {
                new TaskList("Bob","Clean the bathrooms",new DateTime(2019,10,12), false),
                new TaskList("Jeff","Take out garbage",new DateTime(2019,10,10), false),
                new TaskList("Elizabeth","Wash windows",new DateTime(2019,10,15), false),
                new TaskList("Henry","Throw out expired food in fridge",new DateTime(2019,10,9), false),
                new TaskList("Greta","Mail out coupons",new DateTime(2019,10,13), false)
            };
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to the Grand Circus Task List!");
            bool again = true;
            while (again)
            {
                TaskList.PrintOptions(options);
                int userInput = TaskList.TryCatchInput("Enter the number: ");
                Console.Clear();
                switch (userInput)
                {
                    case 1:
                        //List task
                        foreach(TaskList item in userTaskList)
                        {
                            if (item.DueDate < DateTime.Now && item.IsCompleted == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                item.PrintItems();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                item.PrintItems();
                                Console.WriteLine();
                            }
                            
                        }
                        Console.WriteLine("Please choose again");
                        break;
                    case 2:
                        // Add task
                        TaskList.AddTask(userTaskList);
                        Console.WriteLine("Please choose again");
                        break;
                    case 3:
                        // Delete task
                        TaskList.DeleteMember(userTaskList);
                        Console.WriteLine("Please choose again");
                        break;
                    case 4:
                        //Mark task complete
                        TaskList.UpdateTaskComplete(userTaskList);
                        Console.WriteLine("Please choose again");

                        break;
                    case 5:
                        // Quit
                        again = false;
                        Console.WriteLine("Good Bye");
                        break;
                }
            }



        }





    }
}
