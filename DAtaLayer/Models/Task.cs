using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Task
    {
        /// <summary>
        /// Task started from
        /// </summary>
        public DateTime TaskStarted { get; private set; } = DateTime.Now;
        /// <summary>
        /// Task header
        /// </summary>
        public string TaskHeader { get; private set; }
        /// <summary>
        /// Task endet on
        /// </summary>
        public DateTime TaskEndet { get; private set; }
        /// <summary>
        /// Task
        /// </summary>
        public string TaskText { get; private set; }
        /// <summary>
        /// Is does task done
        /// </summary>
        public bool? IsDone { get; private set; }
        /// <summary>
        /// Current user
        /// </summary>
        public User User { get; private set; }

        /// <summary>
        /// Initialize new task
        /// </summary>
        /// <param name="taskHeader"></param>
        /// <param name="taskEndet"></param>
        /// <param name="taskText"></param>
        /// <param name="isDone"></param>
        /// <param name="user"></param>
        [JsonConstructor]
        public Task(string taskHeader, DateTime taskEndet, string taskText, bool? isDone, User user)
        {
            if (string.IsNullOrWhiteSpace(taskHeader)) throw new ArgumentNullException("Header can`t be empty");
            if (taskEndet == null) throw new ArgumentNullException("End date of task can`t be null");
            if (string.IsNullOrWhiteSpace(taskText)) throw new ArgumentNullException("Task can`t be empty");
            TaskHeader = taskHeader;
            TaskEndet = taskEndet;
            TaskText = taskText;
            IsDone = isDone;
            User = user;
        }

    }
}
