using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Contests.xaml
    /// </summary>
    public partial class Contests : Window
    {
        public Contests()
        {
            InitializeComponent();
            ApplicationContext db = new ApplicationContext();
            List<Contest> contests = db.Contests.ToList();
            contests_list.ItemsSource = contests;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        public String id_users { get; set; }
        private void Take_part_Click(object sender, RoutedEventArgs e)
        {

                    
                    //Application_for_participation app = new Application_for_participation();
                    //app.id_users.Content = Convert.ToString(id_user);
                    //app.Show();

            Authorization_Window authorization_Window = new Authorization_Window();
            authorization_Window.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Authorization_Window authorization_Window = new Authorization_Window();
            authorization_Window.Show();
            this.Close();
        }
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Вы не вошли в аккаунт!");
        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Вы не вошли в аккаунт!");

        }

        private void TextBlock_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Вы не вошли в аккаунт!");

        }
    }
}
