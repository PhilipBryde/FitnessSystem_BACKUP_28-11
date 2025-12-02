using System.Windows;
using FitnessProgram;

namespace FitnessProgram
{
    public partial class MainWindow : Window
    {
        // Fitness = system controller (holds members, activities, login logic) Philip
        private Fitness _fitness = new Fitness();

        public MainWindow()
        {
            InitializeComponent();
        }

        // --- LOGIN BUTTON --- Philip
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameInput.Text.Trim();
            string password = PasswordInput.Password.Trim();

            // Prevent empty login fields Philp
            if (username == "" || password == "")
            {
                MessageBox.Show("Udfyld både brugernavn og kodeord.");
                return;
            }

            // Call authentication in Fitness controller Philip
            Member loggedIn = _fitness.Authenticate(username, password);

            // Incorrect login Philip
            if (loggedIn == null)
            {
                MessageBox.Show("Forkert brugernavn eller kodeord.");
                return;
            }

            // LOGIN SUCCESS: Open NextWindow Philip
            NextWindow next = new NextWindow(loggedIn, _fitness);
            next.Show();

            this.Close();
        }

        // --- REGISTER BUTTON --- Philip
        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            // Pass same Fitness system so new members are stored correctly
            RegisterWindow reg = new RegisterWindow(_fitness);
            reg.ShowDialog();
        }
    }
}
