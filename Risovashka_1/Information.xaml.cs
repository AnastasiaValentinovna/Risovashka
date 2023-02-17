﻿using System;
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
    /// Логика взаимодействия для Information.xaml
    /// </summary>
    public partial class Information : Window
    {
        public Consetstant Consetstant { get; private set; }
        public Information(Consetstant consetstant)
        {
            InitializeComponent();
            Consetstant = consetstant;

            this.DataContext = Consetstant;
        }
    }
}
