using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace FitnessProgram
{
    public partial class ActivityOptionsWindow : Window
    {
        private readonly Fitness _fitness;       // shared system
        private readonly string? _activityName;  // selected activity name
        public ObservableCollection<string> Activities { get; set; } = new ObservableCollection<string>();

        // Constructor for selected activity
        public ActivityOptionsWindow(Fitness fitness, string activityName)
        {
            InitializeComponent();
            _fitness = fitness;
            _activityName = activityName;

            ActivityName.Content = _activityName; // display activity name
            DataContext = this;

            LoadActivities(); // Load all activities from file
        }

        // Optional constructor for general activity list
        public ActivityOptionsWindow(Fitness fitness)
        {
            InitializeComponent();
            _fitness = fitness;
            DataContext = this;

            LoadActivities();
        }

        private void LoadActivities()
        {
            string filePath = @"ActivityList.txt";
            if (!File.Exists(filePath)) return;

            foreach (var line in File.ReadAllLines(filePath))
            {
                Activities.Add(line);
            }
        }

        // --- Back button ---
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NextWindow next = new NextWindow(_fitness);
            next.Show();
            this.Close();
        }
    }
}
