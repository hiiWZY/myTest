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
using MaterialDesignTest.Class;
using System.Windows.Controls.Primitives;

namespace MaterialDesignTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MaterialDesignTest.LeakTestDataSet leakTestDataSet;
        public MaterialDesignTest.LeakTestDataSetTableAdapters.UsersTableAdapter leakTestDataSetUsersTableAdapter;
        public System.Windows.Data.CollectionViewSource usersViewSource ;
        public static PublicProperties publicProperties;
        public MainWindow()
        {
            InitializeComponent();
            publicProperties = new PublicProperties();
            this.DataContext = publicProperties;
        }
        #region fields

        #endregion

        #region Propertity

        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            leakTestDataSet = ((MaterialDesignTest.LeakTestDataSet)(this.FindResource("leakTestDataSet")));
            leakTestDataSetUsersTableAdapter = new MaterialDesignTest.LeakTestDataSetTableAdapters.UsersTableAdapter();
            leakTestDataSetUsersTableAdapter.Fill(leakTestDataSet.Users);
            usersViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("usersViewSource")));
            usersViewSource.View.MoveCurrentToFirst();
            //SetBind();
            LoadUserCards();
        }

        private void SetBind()
        {
            //this.CurrentUserIcon.SetBinding(MaterialDesignThemes.Wpf.Chip.VisibilityProperty, new Binding { Path = new PropertyPath("ShowChips"), Source=publicProperties, Mode = BindingMode.OneWay });
            //this.wPromptInfo.SetBinding(TextBlock.TextProperty, new Binding { Path = new PropertyPath("PromptInfo"), Source = this.publicProperties, Mode = BindingMode.OneWay });
        }

        private void LoadUserCards()
        {
            leakTestDataSetUsersTableAdapter.Fill(leakTestDataSet.Users);
            MainCanvas.Children.Clear();
            controlEditUser[] cEditUser = new controlEditUser[(int)leakTestDataSetUsersTableAdapter.GetUsersScalar()];
            for (int i = 0; i < cEditUser.Length; i++)
            {   
                cEditUser[i] = new controlEditUser();
                cEditUser[i].user.UserID= int.Parse(leakTestDataSet.Users.Rows[i][0].ToString());
                cEditUser[i].user.UserName = leakTestDataSet.Users.Rows[i][1].ToString().Trim();
                cEditUser[i].user.UserPassword = leakTestDataSet.Users.Rows[i][2].ToString().Trim();
                cEditUser[i].UserPassword.Password = cEditUser[i].user.UserPassword;
                cEditUser[i].user.RealName = leakTestDataSet.Users.Rows[i][3].ToString().Trim();
                cEditUser[i].user.TopPower = bool.Parse(leakTestDataSet.Users.Rows[i][4].ToString());
                cEditUser[i].user.SpotCheck = bool.Parse(leakTestDataSet.Users.Rows[i][5].ToString());
                cEditUser[i].user.Production = bool.Parse(leakTestDataSet.Users.Rows[i][6].ToString());
                cEditUser[i].user.SampleCheck = bool.Parse(leakTestDataSet.Users.Rows[i][7].ToString());
                cEditUser[i].user.Repair = bool.Parse(leakTestDataSet.Users.Rows[i][8].ToString());
                cEditUser[i].user.Program = bool.Parse(leakTestDataSet.Users.Rows[i][9].ToString());
                cEditUser[i].user.Browse = bool.Parse(leakTestDataSet.Users.Rows[i][10].ToString());
                cEditUser[i].user.DebugMode = bool.Parse(leakTestDataSet.Users.Rows[i][11].ToString());
                MainCanvas.Children.Add(cEditUser[i]);
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadUserCards();
        }
    }
}
