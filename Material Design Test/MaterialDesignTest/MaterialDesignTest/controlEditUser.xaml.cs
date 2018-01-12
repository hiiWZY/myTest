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
using MaterialDesignTest.Class;
using System.Windows.Controls.Primitives;


namespace MaterialDesignTest
{
    /// <summary>
    /// Interaction logic for controlEditUser.xaml
    /// </summary>
    public partial class controlEditUser : UserControl
    {
        public User user;
        MaterialDesignTest.LeakTestDataSetTableAdapters.UsersTableAdapter leakTestDataSetUsersTableAdapter= new MaterialDesignTest.LeakTestDataSetTableAdapters.UsersTableAdapter();
        public controlEditUser()
        {
            InitializeComponent();
            user = new User();
            setBind();
        }

        private void  setBind()
        {
            //Binding bind = new Binding();
            //bind.Source = this.user;
            //bind.Path = new PropertyPath("RealName");
            //bind.Mode = BindingMode.TwoWay;
            //this.RealName.SetBinding(TextBlock.TextProperty, bind);

            this.UserPassword.Password = user.UserPassword;
            this.RealName.SetBinding(TextBlock.TextProperty, new Binding { Path = new PropertyPath("RealName"), Source = this.user, Mode = BindingMode.TwoWay });
            this.UserName.SetBinding(TextBox.TextProperty, new Binding{Path = new PropertyPath("UserName"), Source = this.user, Mode = BindingMode.TwoWay });
            //this.UserPassword.SetBinding(PasswordBox.Password, new Binding {Path = new PropertyPath("UserPassword"), Source = this.user, Mode = BindingMode.TwoWay });
            this.RealNameEdit.SetBinding(TextBox.TextProperty, new Binding { Path = new PropertyPath("RealName"), Source = this.user, Mode = BindingMode.TwoWay });
            this.TopPower.SetBinding(ToggleButton.IsCheckedProperty, new Binding { Path = new PropertyPath("TopPower"), Source = this.user, Mode = BindingMode.TwoWay });
            this.SpotCheck.SetBinding(ToggleButton.IsCheckedProperty, new Binding { Path = new PropertyPath("SpotCheck"), Source = this.user, Mode = BindingMode.TwoWay });
            this.Production.SetBinding(ToggleButton.IsCheckedProperty, new Binding { Path = new PropertyPath("Production"), Source = this.user, Mode = BindingMode.TwoWay });
            this.SampleCheck.SetBinding(ToggleButton.IsCheckedProperty, new Binding { Path = new PropertyPath("SampleCheck"), Source = this.user, Mode = BindingMode.TwoWay });
            this.Repair.SetBinding(ToggleButton.IsCheckedProperty, new Binding { Path = new PropertyPath("Repair"), Source = this.user, Mode = BindingMode.TwoWay });
            this.Program.SetBinding(ToggleButton.IsCheckedProperty, new Binding { Path = new PropertyPath("Program"), Source = this.user, Mode = BindingMode.TwoWay });
            this.Browse.SetBinding(ToggleButton.IsCheckedProperty, new Binding { Path = new PropertyPath("Browse"), Source = this.user, Mode = BindingMode.TwoWay });
            this.DebugMode.SetBinding(ToggleButton.IsCheckedProperty, new Binding { Path = new PropertyPath("DebugMode"), Source = this.user, Mode = BindingMode.TwoWay });
            this.DeleteButton.SetBinding(Button.IsEnabledProperty, new Binding { Path = new PropertyPath("CannotDelete"), Source = this.user, Mode = BindingMode.OneWay });
            this.UserPhoto.SetBinding(Image.SourceProperty, new Binding { Path = new PropertyPath("ImagePath"), Source = this.user, Mode = BindingMode.OneWay });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            leakTestDataSetUsersTableAdapter.UpdateUser(user.UserName, user.UserPassword, user.RealName, user.TopPower, user.SpotCheck, user.Production, user.SampleCheck, user.Repair, user.Program, user.Browse, user.DebugMode, user.UserID);
        }

        private void UserPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            user.UserPassword = UserPassword.Password;
        }
    }

}
