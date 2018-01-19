using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MaterialDesignTest.Class
{
    public class PublicProperties : INotifyPropertyChanged
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
                if (value!= currentUser)
                {
                    currentUser = value;
                    OnPropertyChanged();
                }
                if (currentUser != null)
                {
                    IsCurrentUserExist= true;
                    ShowChips = Visibility.Visible;
                }

            }
        }


        public bool IsCurrentUserExist
        {
            get
            {
                return isCurrentUserExist;
            }
            private set
            {
                if (value!= isCurrentUserExist)
                {
                    isCurrentUserExist = value;
                    OnPropertyChanged();
                }
            }
            
             
        }

        public string PromptInfo { get => promptInfo; set { promptInfo = value; OnPropertyChanged(); } }

        public Visibility ShowChips
        {
            get
            {
                return showChips;
            }
            private set
            {
                if (value!= showChips)
                {
                    showChips = value;
                    OnPropertyChanged();
                }
            }
        }


        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
