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
using System.Data.Entity;

namespace Risovashka_1
{
    /// <summary>
    /// Логика взаимодействия для Edit_of_contest.xaml
    /// </summary>
    public partial class Edit_of_contest : Window
    {
        ApplicationContext db;
        public Edit_of_contest()
        {
            InitializeComponent();
            db = new ApplicationContext();

            db.Contests.Load();

            this.DataContext = db.Contests.Local.ToBindingList();
        }
        // добавление
        private void Delete_Click_1(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим

            if (contests_list.SelectedItem == null) return;

            // получаем выделенный объект

            Contest contest = contests_list.SelectedItem as Contest;

            db.Contests.Remove(contest);

            db.SaveChanges();
            MessageBox.Show("Данные удалены!");
        }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (contests_list.SelectedItem == null) return;
            // получаем выделенный объект
            Contest contest = contests_list.SelectedItem as Contest;
            ConsetsWindow cons = new ConsetsWindow(new Contest
            {
                ID = contest.ID,
                Name = contest.Name,
                Dates_of_the_event = contest.Dates_of_the_event,
                Age = contest.Age,
                Description = contest.Description
        }) ;
            if (cons.ShowDialog() == true)
            {                
                // получаем измененный объект
                contest = db.Contests.Find(cons.Contest.ID);
                if (contest != null)
                {
                    contest.Name = cons.Contest.name;
                    contest.Dates_of_the_event = cons.Contest.dates_of_the_event;
                    contest.Age = cons.Contest.age;
                    contest.Description = cons.Contest.description;
                    //db.Entry(contest).State = EntityState.Modified;
                    db.SaveChanges();
                    contests_list.Items.Refresh();
                }
            }
        }
        private void Agg_Click(object sender, RoutedEventArgs e)
        {
            ConsetsWindow cons = new ConsetsWindow(new Contest());

            if (cons.ShowDialog() == true)
            {
                Contest contest = cons.Contest;
                db.Contests.Add(contest);
                db.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!");
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Authorization_Window authorization_Window = new Authorization_Window();
            authorization_Window.Show();
            this.Close();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Окно уже открыто!");
        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            MainWindow1 mainWindow = new MainWindow1();
            mainWindow.Show();
            this.Close();
        }

        private void TextBlock_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            Processing_applications contestants = new Processing_applications();
            contestants.Show();
            this.Close();
        }       
    }
}

