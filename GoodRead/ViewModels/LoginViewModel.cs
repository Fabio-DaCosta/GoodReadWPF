using Caliburn.Micro;
using GoodRead.Helpers;
using GoodRead.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodRead.ViewModels
{
    public class LoginViewModel : Screen
    {
        //private ShellViewModel _parent;
        private string _username;
        private string _password;
        private User _user;
        private IEventAggregator _eventAggregator;

        public LoginViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public string Username
        {
            get { return _username; }
            set 
            {
                _username = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => CanLogin);
            }

        }


        public string Password
        {
            get { return _password; }
            set 
            { 
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                NotifyOfPropertyChange(() => User);
            }
        }

        public bool CanLogin
        {
            get
            {
                bool output = false;
                if (Username?.Length > 0 && Password?.Length > 0)
                {
                    output = true;
                }

                return output;
            }
        }

        public void Login()
        {
            bool check = false;
            using (GoodReadsDB db = new GoodReadsDB())
            {
                check = db.Users.Any(u => u.Username == Username && u.Password == Password);
            }
            if (check)
            {
                _eventAggregator.PublishOnUIThread(new OnLoginAttemptMessage
                {
                    Username = Username,
                    IsLoginSuccessful = check
                });
            }
        }
    }
}
