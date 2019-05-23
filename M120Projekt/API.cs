using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120Projekt
{
    static class API
    {
        #region Task
        // Create
        public static void TaskCreate()
        {
            Debug.Print("--- Task Create ---");
            // KlasseA
            Data.Task task = new Data.Task();
            task.Title = "Finish Homework";
            task.Description = "test description";
            task.Due_Date = DateTime.Today;
            Int64 taskID = task.Create();
            Debug.Print("Task created with Id:" + taskID);
        }
        public static void TaskCreateShort()
        {
            Data.Task task = new Data.Task { Title = "Laundry", Checked = true, Due_Date = DateTime.Today };
            Int64 taskId = task.Create();
            Debug.Print("Task created with Id:" + taskId);
        }

        // Read
        public static void TaskRead()
        {
            Debug.Print("--- Task Read ---");
            // Demo liest alle
            foreach (Data.Task task in Data.Task.ReadAll())
            {
                Debug.Print("Task Id:" + task.TaskID + " Name:" + task.Title);
            }
        }
        // Update
        public static void TaskUpdate()
        {
         //   Debug.Print("--- Task Update ---");
         //   task changes the attribute
         //   Data.Task task = Data.Task.ReadID(1);
         //   task.Title = "Task 1 after Update";
         //   task.Update();
        }
        // Delete
        public static void TaskDelete()
        {
         // Debug.Print("--- Task Delete ---");
         // Data.Task.ReadID(2).Delete();
         // Debug.Print("Task with Id 1 gelöscht");
        }
        #endregion
    }
}
