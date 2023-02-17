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
    /// Логика взаимодействия для MainWindow1.xaml
    /// </summary>
    public partial class MainWindow1 : Window
    {
        ApplicationContext DB;
        private List<Consests> _listConsets;
        private Consests _selectedCon;
        private string _comboBoxSearch;
        public MainWindow1()
        {
            InitializeComponent();
            ApplicationContext db = new ApplicationContext();
            DB = new ApplicationContext();
            _listConsets = new List<Consests>();


            foreach (Contest contest in db.Contests)
            {
                id.Items.Add(contest.ID);
            }
        }
            private void Window_Loaded_1(object sender, RoutedEventArgs e)
            {


            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                using (var context = new ApplicationContext())
                {
                    //var user = context.Users.FirstOrDefault(x=> x.ID==Authorization_Window.Users.ID)
                }
            }
            private void Search_Click(object sender, RoutedEventArgs e)
            {
                _comboBoxSearch = id.Text;
                _refreshListView(_comboBoxSearch);
            }
            private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
            {
                MessageBox.Show("Вы находитесь в данном окне");
            }

            private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
            {

            Edit_of_contest edit = new Edit_of_contest();
            edit.Show();
            this.Close();
            }

            private void Exit_Click(object sender, RoutedEventArgs e)
            {
                Contests contest = new Contests();
                contest.Show();
                this.Close();
            }

            private void _refreshListView(string searchText)
            {
                try
                {
                    contests_list.ItemsSource = null;
                    contests_list.Items.Clear();
                    _listConsets.Clear();

                    using (var database = new ApplicationContext())
                    {
                        var currentId = Convert.ToInt32(searchText);

                        var constets = database.Consetstants
                            .Where(x => x.ID_contests == currentId)
                            .ToList();
                        if (constets.Count < 1)
                        {
                            MessageBox.Show("Пусто.");
                            return;
                        }
                        constets.ForEach(x => _listConsets.Add(
                            new Consests
                            {
                                Id = x.ID.ToString(),
                                Age = x.Age.ToString(),
                                Drawing = x.Drawing,
                                IdContests = x.ID_contests.ToString(),
                                IdUser = x.ID_user.ToString(),
                                NumberOfVotes = x.Number_of_votes.ToString()
                            }
                            ));
                        contests_list.ItemsSource = _listConsets;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка {ex}");
                    return;
                }
            }
           

            private void contests_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                _selectedCon = (Consests)contests_list.SelectedItem;
            }

        private void TextBlock_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            Processing_applications p = new Processing_applications();
            p.Show();
            this.Close();
        }
    }
    }

