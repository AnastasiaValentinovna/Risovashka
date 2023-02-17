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
    /// Логика взаимодействия для Registration_Window.xaml
    /// </summary>
    public partial class Registration_Window : Window
    {
        ApplicationContext DB;
        public Registration_Window()
        {
            InitializeComponent();
            DB = new ApplicationContext();
        }
        private void V_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FIO.Text == " " || login.Text == " " || password.Text == " " || role.Text == "")
                { MessageBox.Show("Вы ничего не ввели!"); }
                else
                {

                    string Full_name = FIO.Text.Trim();
                    string Login = login.Text.Trim();
                    string Password = password.Text.Trim();
                    string Role = role.Text.Trim();
                    User user = new User(Full_name, Login, Password, Role);
                    DB.Users.Add(user);
                    DB.SaveChanges();
                    MessageBox.Show("Регистрация пройдена успешно!");
                    Authorization_Window authorization_Window = new Authorization_Window();
                    authorization_Window.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
            MessageBox.Show(ex.Message.ToString());
            }

        }
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Authorization_Window authorization_Window = new Authorization_Window();
            authorization_Window.Show();
            this.Close();
        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Вы в этом окне!");
        }
    }
}
