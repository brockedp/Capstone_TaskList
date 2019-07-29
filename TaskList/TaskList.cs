using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    public class TaskList
    {
        #region Fields
        private string memberName;
        private string taskDescription;
        private DateTime dueDate;
        private bool isCompleted;


        #endregion

        #region Properties
        public string MemberName
        {
            get
            {
                return memberName;
            }
            set
            {
                memberName = value;
            }
        }
        public string TaskDescription
        {
            get
            {
                return taskDescription;
            }
            set
            {
                taskDescription = value;
            }
        }
        public DateTime DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                dueDate = value;
            }
        }
        public bool IsCompleted
        {
            get
            {
                return isCompleted;
            }
            set
            {
                isCompleted = value;
            }
        }

        #endregion

        #region Constructors

        public TaskList()
        {

        }
        public TaskList(string _memberName, string _taskDescription, DateTime _dueDate, bool _isCompleted)
        {
            memberName = _memberName;
            taskDescription = _taskDescription;
            dueDate = _dueDate;
            isCompleted = _isCompleted;
        }
        public void PrintItems()
        {
            
            Console.WriteLine($"Member name: {MemberName}");
            Console.WriteLine($"Task description: {TaskDescription}");
            Console.WriteLine($"Due date: {DueDate}");
            if (isCompleted)
            {
                Console.WriteLine($"Is completed: Yes");
            }
            else
            {
                Console.WriteLine($"Is completed: No");
            }

        }
        public static void UpdateTaskComplete(List<TaskList> inputTask)
        {
            // input 
            Console.WriteLine("Which task do you want to update?");
            PrintTasks(inputTask);
            int taskNumber = TryCatchInput("Please enter the task number: ");
            taskNumber--;

            Console.WriteLine();
            inputTask[taskNumber].PrintItems();

            string input = "";
            while (input != "Y" && input != "N")
            {
                Console.WriteLine("Are you sure that the task is complete? Enter(Y/N): ");
                input = Console.ReadLine().ToUpper();
            }
            if (input == "Y")
            {
                inputTask[taskNumber].IsCompleted = true;
                Console.WriteLine();
                Console.WriteLine("----Task Updated----");
                inputTask[taskNumber].PrintItems();
                Console.WriteLine("---------------");
            }
            else
            {
                inputTask[taskNumber].IsCompleted = false;
            }

            
        }
        public static string GetUserInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
        public static int TryCatchInput(string message)
        {
            string input = GetUserInput(message);
            try
            {
                int userInput = int.Parse(input);
                return userInput;
            }
            catch (FormatException)
            {
                return TryCatchInput("That was not a number. Please enter a number: ");
            }
            catch (OverflowException)
            {
                return TryCatchInput("That number is too large. Please enter another number: ");

            }
            catch (Exception e)
            {
                return TryCatchInput($"{e.GetType()}. Please enter a number: ");

            }
        }

        public static void PrintMemberNames(List<TaskList> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{input[i].MemberName}");
            }
        }
        public static void PrintTasks(List<TaskList> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{input[i].TaskDescription}");
            }
        }

        public static void PrintOptions(List<string> optionList)
        {
            for (int i = 0; i < optionList.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{optionList[i]}");
            }
        }


        public static void AddTask(List<TaskList> inputTask)
        {
            Console.Write("Please enter a name: ");
            string name = Console.ReadLine();

            Console.Write("Please put a description of the task: ");
            string taskDesc = Console.ReadLine();



            // try parse for dateTime
            Console.Write("Please enter a due date:(MM/DD/YYYY) ");
            string input = Console.ReadLine();
            DateTime date;
            while(!DateTime.TryParse(input, out date))
            {
                Console.Write("Please enter a due date:(MM/DD/YYYY) ");
                input = Console.ReadLine();
            }

            //DateTime date = TryCatchDateTime(input);
            

            Console.Write("Please enter if it is complete(y for complete, anything else for incomplete): ");
            string userComplete = Console.ReadLine();
            bool complete;
            if (userComplete == "y" || userComplete == "yes")
            {
                complete = true;
            }
            else
            {
                complete = false;
            }

            inputTask.Add(new TaskList(name, taskDesc, date, complete));

        }
        public static void DeleteMember(List<TaskList> inputTask)
        {
            PrintTasks(inputTask);
            //PrintMemberNames(inputTask);
            int userNumber = TryCatchInput("Enter the number of who you want to delete: ");
            userNumber--;
            Console.WriteLine("----Deleted----");
            inputTask[userNumber].PrintItems();
            Console.WriteLine("---------------");
            inputTask.Remove(inputTask[userNumber]);


        }
        public static DateTime TryCatchDateTime(string message)
        {
            string input = GetUserInput(message);
            try
            {
                DateTime userInput = DateTime.Parse(input);
                return userInput;
            }
            catch (FormatException)
            {
                return TryCatchDateTime("That was an incorrect input. Please enter a date (MM/DD/YYYY): ");
            }
            catch (OverflowException)
            {
                return TryCatchDateTime("That number is too large. Please enter a date (MM/DD/YYYY): ");

            }
            catch (Exception e)
            {
                return TryCatchDateTime($"{e.GetType()}. Please enter a date (MM/DD/YYYY): ");

            }
        }

        #endregion

    }
}
