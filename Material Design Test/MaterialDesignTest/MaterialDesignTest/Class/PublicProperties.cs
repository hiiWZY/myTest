using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MaterialDesignTest.Class
{
    class PublicProperties : INotifyPropertyChanged
    {
        #region fileds
        private User currentUser;
        private string promptInfo;
        #endregion
        #region properties

        public User CurrentUser
        {
            get
            { return currentUser; }
            set
            { currentUser = value; OnPropertyChanged("CurrentUser"); }
        }


        public bool IsCurrentUserExist
        {
            get
            {
                return currentUser != null;
            }
        }

        public string PromptInfo { get => promptInfo; set { promptInfo = value; OnPropertyChanged("PromptInfo"); } }

        public Visibility ShowChips
        {
            get
            {
                if (IsCurrentUserExist)
                {
                    return Visibility.Visible;
                }
                else
                {
                    PromptInfo = "请选择登录用户";
                    return Visibility.Hidden;
                }
            }
        }


        #endregion


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
