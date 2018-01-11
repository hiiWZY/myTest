using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignTest.Class
{
    public class User : INotifyPropertyChanged
    {
        private string userName;
        public string UserName
        {
            get {return userName; }
            set
            {
                userName =value;
                OnPropertyChanged("UserName");
            }
        }

        

        private string userPassword;
        public string UserPassword
        {
            get { return userPassword; }
            set
            {
                userPassword = value;
                OnPropertyChanged("UserPassword");
            }
        }

        private string realName="";
        public string RealName
        {
            get { return realName; }
            set
            {
                realName = value;
                OnPropertyChanged("RealName");
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
