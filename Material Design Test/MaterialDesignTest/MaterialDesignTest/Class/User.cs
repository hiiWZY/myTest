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

        private int userID;
        public int UserID
        {
            get { return userID; }
            set
            {
                userID = value;
                OnPropertyChanged("UserID");
            }
        }

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

        private string realName;
        public string RealName
        {
            get { return realName; }
            set
            {
                realName = value;
                OnPropertyChanged("RealName");
            }
        }

        private bool topPower = false;
        public bool TopPower
        {
            get { return topPower; }
            set
            {
                topPower = value;
                CannotDelete = !topPower;

                if (topPower)
                {
                    ImagePath = "images/Administrator.png";
                }
                else
                {
                    ImagePath = "images/Operator.png";
                }

                OnPropertyChanged("TopPower");
            }
        }

        private bool spotCheck = false;
        public bool SpotCheck
        {
            get { return spotCheck; }
            set
            {
                spotCheck = value;
                OnPropertyChanged("SpotCheck");
            }
        }

        private bool production = false;
        public bool Production
        {
            get { return production; }
            set
            {
                production = value;
                OnPropertyChanged("Production");
            }
        }

        private bool sampleCheck = false;
        public bool SampleCheck
        {
            get { return sampleCheck; }
            set
            {
                sampleCheck = value;
                OnPropertyChanged("SampleCheck");
            }
        }

        private bool repair = false;
        public bool Repair
        {
            get { return repair; }
            set
            {
                repair = value;
                OnPropertyChanged("Repair");
            }
        }

        private bool program = false;
        public bool Program
        {
            get { return program; }
            set
            {
                program = value;
                OnPropertyChanged("Program");
            }
        }

        private bool browse = false;
        public bool Browse
        {
            get { return browse; }
            set
            {
                browse = value;
                OnPropertyChanged("Browse");
            }
        }

        private bool debugMode = false;
        public bool DebugMode
        {
            get { return debugMode; }
            set
            {
                debugMode = value;
                OnPropertyChanged("DebugMode");
            }
        }

        private bool cannotDelete = false;
        public bool CannotDelete
        {
            get { return cannotDelete; }
            set
            {
                cannotDelete = value;
                OnPropertyChanged("CannotDelete");
            }
        }

        private string imagePath;
        public string  ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath= value;
                OnPropertyChanged("ImagePath");
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
