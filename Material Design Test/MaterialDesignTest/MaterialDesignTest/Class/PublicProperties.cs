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
        private bool isCurrentUserExist;
        private Visibility showChips= Visibility.Hidden;
        #endregion
        #region properties

        public User CurrentUser
        {
            get
            {
                if (currentUser==null)
                {
                    PromptInfo = "请选择登录用户";
                }
                return currentUser;
            }
            set
            {
                currentUser = value;
                if (currentUser != null)
                {
                    IsCurrentUserExist= true;
                    ShowChips = Visibility.Visible;
                }
                OnPropertyChanged("CurrentUser");
            }
        }


        public bool IsCurrentUserExist
        {
            get
            {
                return isCurrentUserExist;
            }
            set
            {
                isCurrentUserExist = value;
                OnPropertyChanged("IsCurrentUserExist");
            }
            
             
        }

        public string PromptInfo { get => promptInfo; set { promptInfo = value; OnPropertyChanged("PromptInfo"); } }

        public Visibility ShowChips
        {
            get
            {
                return showChips;
            }
            set
            {
                showChips = value;
                OnPropertyChanged("ShowChips");
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
