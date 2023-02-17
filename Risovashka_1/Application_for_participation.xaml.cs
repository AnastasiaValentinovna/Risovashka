using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Risovashka_1
{
    /// <summary>
    /// Логика взаимодействия для Application_for_participation.xaml
    /// </summary>
    public partial class Application_for_participation : Window
    {
        ApplicationContext DB;
        public Application_for_participation()
        {
            InitializeComponent();
            DB = new ApplicationContext();
            ApplicationContext db = new ApplicationContext();
            foreach (Contest contest in db.Contests)
            {
                id.Items.Add(contest.ID);
            }            
        }
        private void V_Click(object sender, RoutedEventArgs e)
        {

        }

        
        

        private void Loading_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();

            picture.Text = fd.FileName;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ID_contests = Convert.ToInt32(id.Text);
                int ID_user = Convert.ToInt32(id_users.Text);
                int Age = Convert.ToInt32(age.Text);
                string Drawing = picture.Text.Trim();
                int Number_of_votes = 0;
                Consetstant consetstant = new Consetstant(ID_contests, ID_user, Age, Drawing, Number_of_votes);
                DB.Consetstants.Add(consetstant);
                DB.SaveChanges();
                MessageBox.Show("Данные сохранены!");
                MainWindow1 mainWindow = new MainWindow1();
                mainWindow.Show();
                Contests contests = new Contests();
                contests.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Authorization_Window authorization_Window = new Authorization_Window();
            authorization_Window.Show();
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {}
    }
}
