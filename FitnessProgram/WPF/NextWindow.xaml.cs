using System.Windows;

namespace FitnessProgram
{
    public partial class NextWindow : Window
    {
        private readonly Fitness _fitness;    // Reference to shared Fitness system
        private readonly Member? _member;     // Current logged-in member (nullable if needed)

        // Constructor for logged-in member
        public NextWindow(Member member, Fitness fitness)
        {
            InitializeComponent();
            _fitness = fitness;
            _member = member;

            WelcomeText.Text = $"Velkommen {member.name}!"; // Show welcome message
        }

        // Optional constructor when navigating without a member
        public NextWindow(Fitness fitness)
        {
            InitializeComponent();
            _fitness = fitness;
        }

        // --- Button: Open Member Window --- Philip
        private void GoToMembers_Click(object sender, RoutedEventArgs e)
        {
            MemberWindow memberWindow = new MemberWindow(_fitness);
            memberWindow.Show();
            this.Close();
        }

        // --- Fun button --- Sidney
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                MainWindow main = new MainWindow(_fitness);
                main.Show();
            }
        }

        // --- Button: Open ActivityOptionsWindow --- Philip
        private void GoToActivity_Click(object sender, RoutedEventArgs e)
        {
            // Example: pass fitness and an example activity name
            ActivityOptionsWindow activityOptions = new ActivityOptionsWindow(_fitness, "ExampleActivity");
            activityOptions.Show();
            this.Close();
        }

        // --- Button: Go back to Main Menu --- Philip
        private void GoToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(_fitness);
            main.Show();
            this.Close();
        }
    }
}
