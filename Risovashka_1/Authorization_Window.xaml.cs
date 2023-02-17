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
    /// Логика взаимодействия для Authorization_Window.xaml
    /// </summary>
    public partial class Authorization_Window : Window
    {
        public Authorization_Window()
        {
            InitializeComponent();
        }
        private void V_Click(object sender, RoutedEventArgs e)
        {
            {
                try
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        foreach (User user in db.Users)
                        {
                            if (login.Text == user.Login && password.Text == user.Password)
                            {
                                if (user.Role == "Конкурсант")
                                {
                                    MessageBox.Show("Вход успешен! Ваша роль - конкурсант");
                                    //Contests contests = new Contests();
                                    //contests.id_user.Content = user.ID;
                                    //contests.Show();
                                    Application_for_participation app = new Application_for_participation();
                                    app.id_users.Text = Convert.ToString(user.ID);
                                    app.Show();
                                    this.Close();
                                }
                                if (user.Role == "Голосующий")
                                {
                                    MessageBox.Show("Вход успешен! Ваша роль - голосующий");
                                    MainWindow main = new MainWindow();
                                    main.Show();
                                    this.Close();
                                }
                                else if (user.Role == "Администратор")
                                {
                                    MessageBox.Show("Вход успешен! Ваша роль - администратор");
                                    Edit_of_contest edit = new Edit_of_contest();
                                    edit.Show();
                                    this.Close();
                                    Contests contests = new Contests();
                                    contests.Close();
                                    return;
                                }
                            }
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
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
            Registration_Window registration_Window = new Registration_Window();
            registration_Window.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
