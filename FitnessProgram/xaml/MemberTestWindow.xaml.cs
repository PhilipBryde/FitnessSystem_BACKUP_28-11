using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace FitnessProgram

    //Philip Kode
{
    public partial class ActivityWindow : Window
    {
        private readonly Fitness _fitness;  // Shared Fitness system
        public ObservableCollection<string> Activities { get; set; } = new ObservableCollection<string>();

        // Constructor requires Fitness object
        public ActivityWindow(Fitness fitness)
        {
            InitializeComponent();
            _fitness = fitness;
            DataContext = this; // Bind Activities collection to UI
            LoadActivities();
        }

        // Load activities from ActivityList.txt into ObservableCollection
        private void LoadActivities()
        {
            string filePath = @"ActivityList.txt";
            if (!File.Exists(filePath)) return;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                Activities.Add(line);
            }
        }

        // Called when user clicks an activity button
        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var activity = button?.DataContext as string;

            if (!string.IsNullOrEmpty(activity))
            {
                // Open ActivityOptionsWindow with selected activity
                ActivityOptionsWindow activityOptions = new ActivityOptionsWindow(_fitness, activity);
                activityOptions.Show();
            }
        }*/

        // Back button: return to NextWindow
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NextWindow next = new NextWindow(_fitness);
            next.Show();
            this.Close();
        }
    }
}
