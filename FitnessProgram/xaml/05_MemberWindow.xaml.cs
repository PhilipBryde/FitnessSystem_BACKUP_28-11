using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

//Sidney Kode 
namespace FitnessProgram
{
    public partial class MemberWindow : Window
    {
        //private readonly Fitness _fitness; // shared Fitness system
        private readonly Fitness fitness; // Shared fitness system
        private readonly Member member;   // Logged in user
        public List<string> _localList;
        public MemberWindow(Fitness fitness, Member member)
        {
            InitializeComponent();
            //_fitness = fitness;
            this.fitness = fitness;
            this.member = member;
            this._localList = fitness.MemberFromFile().ToList();
            ShowMembers(); // Kalder ShowMembers for at vise medlemmerne
        }

        private void ShowMembers() //Metode der viser alle medlemmerne fra textfilen i en string -- Sidney
        {
   
            // UDGAVE UDFRA TEXTFILEN
            StringBuilder allMembers = new StringBuilder(); //Opretter ny StringBuilder

            for (int i = 0; i < _localList.Count; i++) //En forløkke der kører så længe i er mindre end antallet af medlemmer i listen, inkrementerer i hvert loop
            {
                allMembers.AppendLine(_localList[i]);  //Hver medlem/index bliver sat i vores StringBuilder som ny linje
            }
            MemberBlock.Text = allMembers.ToString(); //Sætter dem sammen i en stor string i hukommelsen
        }

        private void RemoveMember() //Metode der fjerner medlem via dens index i listen, Gamle version fjernede via medlemmets ID -- Sidney
        {
            if (int.TryParse(EnterMember.Text, out int memberID))
            {
                int memberIndex = memberID - 1;
                if (memberIndex >= 0 && memberIndex < _localList.Count)
                {
                    _localList.RemoveAt(memberIndex);
                    //File.WriteAllLines(@"MemberList.txt", localList); Kan fjerne medlem permanent fra textfilen
                    ShowMembers();
                    MessageBox.Show($"{memberID} er blevet slettet!");
                }
                else
                {
                    MessageBox.Show($"{memberID} findes ikke, prøv igen");
                }
            }
            else
            {
                MessageBox.Show("Indtast venligst et tal");
            }
        }

        private void DeleteMemberButton_Click(object sender, RoutedEventArgs e) //Knap der kalder på RemoveMember() metoden -- Sidney
        {
            RemoveMember();
        }

        private void GoToNextWindow_Click(object sender, RoutedEventArgs e) //Knap der vender tilbage til menuen -- Sidney
        {
            NextWindow next = new NextWindow(member, fitness);
            next.Show();
            this.Close();
        }
    }
}
