using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для Processing_applications.xaml
    /// </summary>
    public partial class Processing_applications : Window
    {
        ApplicationContext db;
        public Processing_applications()
        {
            InitializeComponent();
            ApplicationContext db = new ApplicationContext();
           List<Consetstant> contests = db.Consetstants.ToList();
           contests_list.ItemsSource = contests;

            //db = new ApplicationContext();

           //db.Consetstants.Load();

           //this.DataContext = db.Contests.Local.ToBindingList();
        }

        private void Agg_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (contests_list.SelectedItem == null) return;
            // получаем выделенный объект
            Consetstant consetst = contests_list.SelectedItem as Consetstant;
            Information cons = new Information(new Consetstant
            {
                ID = consetst.ID,
                ID_contests = consetst.ID_contests,
                ID_user = consetst.ID_user,
                Drawing = consetst.Drawing,
                Age = consetst.Age,
                Number_of_votes = consetst.Number_of_votes,
            });
            if (cons.ShowDialog() == true)
            {
                // получаем измененный объект
                consetst = db.Consetstants.Find(cons.Consetstant.ID);
                if (consetst != null)
                {
                    consetst.Drawing = cons.Consetstant.drawing;
                    consetst.Number_of_votes  = cons.Consetstant.number_of_votes;
                    consetst.ID_user = cons.Consetstant.id_user;
                    consetst.ID_contests = cons.Consetstant.id_contests;
                    consetst.Age = cons.Consetstant.age;
                    //db.Entry(contest).State = EntityState.Modified;
                }
            }
        }
       
        private void D_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (contests_list.SelectedItem == null) return;
            // получаем выделенный объект
            Consetstant consetstant = contests_list.SelectedItem as Consetstant;
            db.Consetstants.Remove(consetstant);
            db.SaveChanges();
            MessageBox.Show("Данные удалены!");
           
        }
        private void TextBlock_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Окно уже открыто!");
        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            MainWindow1 mainWindow = new MainWindow1();
            mainWindow.Show();
            this.Close();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Edit_of_contest en = new Edit_of_contest();
            en.Show();
            this.Close();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Add_contestant_admin add = new Add_contestant_admin();
            add.Show();
            contests_list.Items.Refresh();
        }
    }
    
}
