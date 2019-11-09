using BuisnessLayer;
using BuisnessLayer.Controllers;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH_TO_USERS = $"{AppDomain.CurrentDomain.BaseDirectory}//person.json";
        private readonly string PATH_TO_TASKS = $"{AppDomain.CurrentDomain.BaseDirectory}//todos.json";
        private readonly string PATH_TO_THE_CITYS = @"..\..\..\newCitys.list.json";

        private WeatherSettings Settings;
        private DataLayer.Models.Task Task;
        private UserController UserController;
        private TaskController TaskController;
        private List<City> Citys;
        private int? Index;

        public MainWindow()
        {
            InitializeComponent();
            
            UserController = new UserController(JsonSD.Desirialize<List<User>>(PATH_TO_USERS));
            TaskController = new TaskController(JsonSD.Desirialize<List<DataLayer.Models.Task>>(PATH_TO_TASKS));
            Citys = JsonSD.Desirialize<List<City>>(PATH_TO_THE_CITYS);
            SetBoxes();
        }

        private void SetBoxes()
        {
            var countrys = Citys.Select(c => c.Country).Distinct().ToList();
            CountryBox.ItemsSource = countrys;
            CountryBox.SelectedItem = countrys.First();
            var citys = Citys.Where(c => c.Country == CountryBox.SelectedItem.ToString()).Select(c => c.Name).Distinct().ToList();
            CityBox.ItemsSource = citys;
            MeasuribgBox.ItemsSource = new string[] { "metric", "imperial" };
            MeasuribgBox.SelectedIndex = 0;
        }

        private void UserBtn_Click(object sender, RoutedEventArgs e)
        {
            UserPop.IsOpen = true;
        }

        private void TaskBtn_Click(object sender, RoutedEventArgs e)
        {
            var add = new AddTask(UserController.GetCurrentUser(), settings: Settings, task: Task) ;
            if(add.ShowDialog() == true)
            {
                Task = add.Task;
                if (Index == null) TaskController.AddTask(Task);
                else TaskController.UpdateTask(Task, (int)Index);
                ShowTasks();
            }
        }

        private void WeatheBtn_Click(object sender, RoutedEventArgs e)
        {
            WeatherPopup.IsOpen = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveData();
            Application.Current.Shutdown();
        }

        private void SaveData()
        {
            if(TaskController.Tasks != null && UserController.Users != null)
            {
                JsonSD.Serialize<IEnumerable<DataLayer.Models.Task>>(TaskController.Tasks,PATH_TO_TASKS);
                JsonSD.Serialize<IEnumerable<User>>(UserController.Users,PATH_TO_USERS);
            }
        }

        private void ClosePopup_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in LogicalTreeHelper.GetChildren(MainMenu))
            {
                if(item is Popup)
                {
                    var pop = (Popup)item;
                    pop.IsOpen = false;
                }
            }
        }

        private void AuthorizeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                var user = new User(UserNameBox.Text, SHAConvert.Convert(PasswordBoxUser.Password));
                UserController.CheckUser(user);
                
                MessageBoxOvverideController.Show($"Hi {UserController.GetCurrentUser().UserName}","Hi");
                UserPop.IsOpen = false;
                ShowTasks();
                
                
            }
            catch(Exception ex)
            {
                MessageBoxOvverideController.Show(ex.Message);
            }
        }
        private void ShowTasks()
        {
            try
            {
                var tasks = TaskController.Tasks.Where(t => t.User.UserName == UserController.GetCurrentUser().UserName && t.User.Password == UserController.GetCurrentUser().Password);
                if (tasks != null)
                {
                    MainDataGrid.ItemsSource = tasks.ToList();
                    TaskBtn.IsEnabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBoxOvverideController.Show(ex.Message);
            }
        }

        private void SelectSetup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Settings = new WeatherSettings(CountryBox.SelectedItem.ToString(), CityBox.SelectedItem.ToString(), MeasuribgBox.SelectedItem.ToString());
                WeatherPopup.IsOpen = false;
            }
            catch(Exception ex)
            {
                MessageBoxOvverideController.Show(ex.Message);
            }
        }

        private void MainDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Index = MainDataGrid.SelectedIndex;
        }

        private void CountryBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var citys = Citys.Where(c => c.Country == CountryBox.SelectedItem.ToString()).Select(c => c.Name).Distinct().ToList();
            CityBox.ItemsSource = citys;
        }

        private void MainDataGrid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Index = null;
            MainDataGrid.SelectedItem = null;
        }
    }
}
