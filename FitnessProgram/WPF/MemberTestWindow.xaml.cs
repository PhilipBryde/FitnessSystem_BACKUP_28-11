using System.IO;
using System.Windows;

namespace FitnessProgram
{
    public partial class MemberTestWindow : Window
    {
        private Fitness _fitness = new Fitness();

        public MemberTestWindow()
        {
            InitializeComponent(); // REQUIRED
            ShowActivity();
        }

        private void ShowActivity()
        {
            string filePath = "ActivityList.txt";

            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                ActivityBlock.Text = content;
            }
            else
            {
                ActivityBlock.Text = "ActivityList.txt ikke fundet.";
            }
        }

        private void BackButton_nextWindow_Click(object sender, RoutedEventArgs e)
        {
            NextWindow next = new NextWindow();
            next.Show();
            this.Close();
        }
    }
}
