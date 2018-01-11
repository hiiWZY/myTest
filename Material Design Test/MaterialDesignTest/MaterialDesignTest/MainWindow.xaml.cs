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

        MaterialDesignTest.LeakTestDataSet leakTestDataSet;
        // Load data into the table Users. You can modify this code as needed.
        MaterialDesignTest.LeakTestDataSetTableAdapters.UsersTableAdapter leakTestDataSetUsersTableAdapter;
        System.Windows.Data.CollectionViewSource usersViewSource ;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            leakTestDataSet = ((MaterialDesignTest.LeakTestDataSet)(this.FindResource("leakTestDataSet")));
            // Load data into the table Users. You can modify this code as needed.
            leakTestDataSetUsersTableAdapter = new MaterialDesignTest.LeakTestDataSetTableAdapters.UsersTableAdapter();
            leakTestDataSetUsersTableAdapter.Fill(leakTestDataSet.Users);
            usersViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("usersViewSource")));
            usersViewSource.View.MoveCurrentToFirst();
            LoadUserCards();
        }


        private void LoadUserCards()
        {


            usersViewSource.View.MoveCurrentToFirst();
            MainCanvas.Children.Clear();
            controlUserCards[] cUserCards = new controlUserCards[(int)leakTestDataSetUsersTableAdapter.GetUsersScalar()];
            controlEditUser[] cEditUser = new controlEditUser[(int)leakTestDataSetUsersTableAdapter.GetUsersScalar()];
            for (int i = 0; i < cUserCards.Length; i++)
            {
                //cUserCards[i] = new controlUserCards();
                //MainCanvas.Children.Add(cUserCards[i]);
                cEditUser[i] = new controlEditUser();
                MainCanvas.Children.Add(cEditUser[i]);
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadUserCards();
        }
    }
}
