using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuisnessLayer.Controllers
{
    public class TaskController
    {
        /// <summary>
        /// Public collection for read data
        /// </summary>
        public IEnumerable<Task> Tasks { get; private set; }
        /// <summary>
        /// Private collection for manupulation in the data
        /// </summary>
        private List<Task> TasksList { get; set; }
        /// <summary>
        /// Information about weather
        /// </summary>
        private WeatherInfo Weather { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public TaskController()
        {

        }
        /// <summary>
        /// Initilize collections
        /// </summary>
        /// <param name="tasks"></param>
        public TaskController(List<Task> tasks)
        {
            TasksList = tasks ?? new List<Task>();
            Tasks = TasksList;
            
        }

        public void AddTask(Task task)
        {
            if(task != null)
            {
                TasksList.Add(task);
            }
        }

        public void UpdateTask(Task task, int index)
        {
            if(task != null && (index >=0 || index <= TasksList.Count))
            {
                TasksList.RemoveAt(index);
                TasksList.Insert(index, task);
            }
        }

       

    }
}
