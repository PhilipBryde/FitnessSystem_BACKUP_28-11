using System.Windows;
using FitnessProgram;


namespace FitnessProgram
{
    /// <summary>
    /// Interaction logic for NextWindow.xaml
    /// </summary>
    public partial class NextWindow : Window
    {
        // Required WPF Constructor 
        public NextWindow()
        {
            InitializeComponent();
        }

        // Store logged-in member + fitness system reference philip
        private Member _member;
        private Fitness _fitness;

        // This constructor is used when navigating from MainWindow philip
        public NextWindow(Member member, Fitness fitness)
        {
            InitializeComponent();

            _member = member;     // save reference to logged-in user
            _fitness = fitness;   // save reference to system controller

            // Show welcome message
            WelcomeText.Text = $"Velkommen {member.name}!";
        }

        // --- Button: Open Member Window --- Philip
        private void GoToMembers_Click(object sender, RoutedEventArgs e)
        {
            MemberWindow member = new MemberWindow();
            member.Show();
            this.Close();
        }

        // --- Fun botton --- Sidney
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                MainWindow main = new MainWindow();
                main.Show();
            }
        }

        // --- Button: Open Activity Window --- philip
        private void GoToActivity_Click(object sender, RoutedEventArgs e)
        {
            MemberTestWindow activity = new MemberTestWindow();
            activity.Show();
            this.Close();
        }

        // --- Button: Go back to Main Menu --- philip
        private void GoToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
