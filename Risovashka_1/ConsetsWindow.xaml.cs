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
    /// Логика взаимодействия для ConsetsWindow.xaml
    /// </summary>
    public partial class ConsetsWindow : Window
    {
        public Contest Contest { get; private set; }
        public ConsetsWindow(Contest contest)
        {
            InitializeComponent();
            Contest = contest;

            this.DataContext = Contest;
        }
        private void Accept_Click(object sender, RoutedEventArgs e)

        {

            this.DialogResult = true;

        }
    }
}
