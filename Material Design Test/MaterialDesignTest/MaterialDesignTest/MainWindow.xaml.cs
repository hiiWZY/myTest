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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignTest.LeakTestDataSetTableAdapters;

namespace MaterialDesignTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LeakTestDataSet leakTestDataSet = new LeakTestDataSet();
        UsersTableAdapter usersTableAdapter = new UsersTableAdapter();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            LoadUserCards();
        }

        private void LoadUserCards()
        {
            //usersTableAdapter.GetUsersScalar();
            MainCanvas.Children.Clear();
            for (int i = 0; i < usersTableAdapter.GetUsersScalar(); i++)
            {
                MainCanvas.Children.Add(new controlUserCards());
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadUserCards();
        }
    }
}
