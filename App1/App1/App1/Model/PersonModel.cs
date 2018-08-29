using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App1.Model
{
    public class PersonModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #region Props
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value;
                OnPropertyChanged();
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        private string lastname;

        public string LastName
        {
            get { return lastname; }
            set { lastname = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value;
                OnPropertyChanged();
            }
        }

        private string fullname;

        public string FullName
        {
            get
            {
                return $"{Name} {LastName}";
            }
            set {
                fullname = value;
                OnPropertyChanged();
                //OnPropertyChanged(Message);
            }
        }

        //private string message;
        //public string Message
        //{
        //    get { return $"Tu nombre es {FullName}"; }
           
        //}


        private bool _isLoading=false;

        public bool isLoading
        {
            get { return _isLoading=false; }
            set { _isLoading= value;
                OnPropertyChanged();
            }
        }


        #endregion

    }
}
