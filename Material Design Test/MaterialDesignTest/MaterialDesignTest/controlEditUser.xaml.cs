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

namespace MaterialDesignTest
{
    /// <summary>
    /// Interaction logic for controlEditUser.xaml
    /// </summary>
    public partial class controlEditUser : UserControl
    {
        public User user;
        public controlEditUser()
        {
            InitializeComponent();
            user = new User();
            setBind();
        }

        private void setBind()
        {
            //Binding bind = new Binding();
            //bind.Source = this.user;
            //bind.Path = new PropertyPath("RealName");
            //bind.Mode = BindingMode.TwoWay;
            //this.RealName.SetBinding(TextBlock.TextProperty, bind);
            this.RealName.SetBinding(TextBlock.TextProperty, new Binding { Path = new PropertyPath("RealName"), Source = this.user, Mode = BindingMode.TwoWay });
            this.UserName.SetBinding(TextBox.TextProperty, new Binding{Path = new PropertyPath("UserName"), Source = this.user, Mode = BindingMode.TwoWay });
            this.UserPassword.SetBinding(TextBox.TextProperty, new Binding {Path = new PropertyPath("UserPassword"), Source = this.user, Mode = BindingMode.TwoWay });
        }
    }
}
