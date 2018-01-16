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
        PublicProperties publicProperties;
        MaterialDesignTest.LeakTestDataSetTableAdapters.UsersTableAdapter leakTestDataSetUsersTableAdapter= new MaterialDesignTest.LeakTestDataSetTableAdapters.UsersTableAdapter();
        BoolReverseConverter boolReverseConverter = new BoolReverseConverter();

        public controlEditUser()
        {
            InitializeComponent();
            user = new User();
            publicProperties = new PublicProperties();
            setBind();
        }

        #region Properties
        public bool IsLoginButtonEnable
        {
            get
            {
                if (!publicProperties.IsCurrentUserExist)            //是否已经有用户登录，没有的话则可以选择登录用户
                {
                    return true;
                }
                else
                {
                    if (user == publicProperties.CurrentUser)       //不能重复登录
                    {
                        return false;
                    }
                    else
                    {
                        if (publicProperties.CurrentUser.TopPower)      //已登录用户有最高权限，可以切换至其他用户
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

            }
        }

        public bool IsEditButtonEnable
        {
            get
            {
                if (publicProperties.IsCurrentUserExist)            //是否已经有用户登录，没有的话则不能编辑任何用户
                {
                    if (publicProperties.CurrentUser.TopPower)      //已登录用户有最高权限，可编辑所有用户
                    {
                        return true;
                    }
                    else
                    {
                        if (user == publicProperties.CurrentUser)   //已登录用户没有最高权限，可编辑自己的信息
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }

            }
        }

        public bool IsDeleteButtonEnable
        {
            get
            {
                if (publicProperties.IsCurrentUserExist)
                {
                    if (user == publicProperties.CurrentUser)
                    {
                        return false;
                    }
                    else
                    {
                        if (user.TopPower)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }

            }
        }
        #endregion

        private void  setBind()
        {
            this.UserPassword.Password = user.UserPassword;
            this.RealName.SetBinding(TextBlock.TextProperty, new Binding { Path = new PropertyPath("RealName"), Source = this.user, Mode = BindingMode.TwoWay });
            this.UserName.SetBinding(TextBox.TextProperty, new Binding{Path = new PropertyPath("UserName"), Source = this.user, Mode = BindingMode.TwoWay });
            this.RealNameEdit.SetBinding(TextBox.TextProperty, new Binding { Path = new PropertyPath("RealName"), Source = this.user, Mode = BindingMode.TwoWay });
            this.TopPower.SetBinding(ToggleButton.IsCheckedProperty, new Binding { Path = new PropertyPath("TopPower"), Source = this.user, Mode = BindingMode.TwoWay });
            this.SpotCheck.SetBinding(ToggleButton.IsCheckedProperty, new Binding { Path = new PropertyPath("SpotCheck"), Source = this.user, Mode = BindingMode.TwoWay });
            this.Production.SetBinding(ToggleButton.IsCheckedProperty, new Binding { Path = new PropertyPath("Production"), Source = this.user, Mode = BindingMode.TwoWay });
            this.SampleCheck.SetBinding(ToggleButton.IsCheckedProperty, new Binding { Path = new PropertyPath("SampleCheck"), Source = this.user, Mode = BindingMode.TwoWay });
            this.Repair.SetBinding(ToggleButton.IsCheckedProperty, new Binding { Path = new PropertyPath("Repair"), Source = this.user, Mode = BindingMode.TwoWay });
            this.Program.SetBinding(ToggleButton.IsCheckedProperty, new Binding { Path = new PropertyPath("Program"), Source = this.user, Mode = BindingMode.TwoWay });
            this.Browse.SetBinding(ToggleButton.IsCheckedProperty, new Binding { Path = new PropertyPath("Browse"), Source = this.user, Mode = BindingMode.TwoWay });
            this.DebugMode.SetBinding(ToggleButton.IsCheckedProperty, new Binding { Path = new PropertyPath("DebugMode"), Source = this.user, Mode = BindingMode.TwoWay });
            this.DeleteButton.SetBinding(Button.IsEnabledProperty, new Binding { Path = new PropertyPath("IsDeleteButtonEnable"), Source = this, Mode = BindingMode.OneWay });
            this.LoginButton.SetBinding(Button.IsEnabledProperty, new Binding { Path = new PropertyPath("IsLoginButtonEnable"), Source = this, Mode = BindingMode.OneWay });
            this.EditButton.SetBinding(Button.IsEnabledProperty, new Binding { Path = new PropertyPath("IsEditButtonEnable"), Source = this, Mode = BindingMode.OneWay });
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

        private void DialogHost_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            string loginPassword = LoginPasswordBox.Password;
            LoginPasswordBox.Clear();
            if (!Equals(eventArgs.Parameter, true)) return;

            if (!string.IsNullOrWhiteSpace(loginPassword))
            {
                if (leakTestDataSetUsersTableAdapter.IsPasswordRight(user.UserName, loginPassword) >0)
                {
                    publicProperties.CurrentUser = user;
                }
            }
        }
    }

}
