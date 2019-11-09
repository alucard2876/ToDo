using BuisnessLayer.Controllers;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ToDo
{
    /// <summary>
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
      
        public Task Task { get; private set; }
        private User User;
        private WeatherController Weather;
        private WeatherSettings Settings;
        public AddTask()
        {
            InitializeComponent();
        }
        
        public AddTask(User user,Task task = null,WeatherSettings settings =null)
        {
            InitializeComponent();
            if(task != null)
            {
            
                ShowTasks(task);
            }
            if (settings == null) IncludeWeather.IsEnabled = false;
            Settings = settings;
            User = user;
            StartTask.Text = DateTime.Now.ToString();
        }

        private void ShowTasks(Task task)
        {
            StartTask.Text = task.TaskStarted.ToString();
            EndetTask.Text = task.TaskEndet.ToString();
            HeaderTask.Text = task.TaskHeader;
            TextTask.Document.Blocks.Clear();
            TextTask.Document.Blocks.Add(new Paragraph(new Run(task.TaskText)));
            Done.IsChecked = task.IsDone;


        }

        /// <summary>
        /// Ok Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var task = new TextRange(TextTask.Document.ContentStart, TextTask.Document.ContentEnd).Text;
                if (IncludeWeather.IsChecked == true)
                {
                    Weather = new WeatherController(Settings);
                    task += Weather.GetCurrentWeather();

                }
                Task = new Task(HeaderTask.Text, DateTime.Parse(EndetTask.Text), task, Done.IsChecked, User);
                this.DialogResult = true;
            }
            catch(Exception ex)
            {
                MessageBoxOvverideController.Show(ex.Message);
            }
        }

        /// <summary>
        /// Cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
