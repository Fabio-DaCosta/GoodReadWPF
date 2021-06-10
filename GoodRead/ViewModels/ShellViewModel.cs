using Caliburn.Micro;
using GoodRead.Core;
using GoodRead.Helpers;
using GoodRead.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodRead.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<OnLoginAttemptMessage>
    {
        private readonly LoginViewModel _loginVM;
        private readonly HomeViewModel _homeVM = new HomeViewModel();
        private readonly UserViewModel _userVM = new UserViewModel();
        private bool authenticated;
        private readonly IEventAggregator _eventAggregator;

        public void Handle(OnLoginAttemptMessage message)
        {
            if (message.IsLoginSuccessful)
            {
                authenticated = message.IsLoginSuccessful;
                ChangeActiveItem(_homeVM, true);
            }
        }

        public ShellViewModel(LoginViewModel loginVM, IEventAggregator eventAggregator)
        {
            _loginVM = loginVM;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            ActivateItem(loginVM);
        }

        public void HomeView()
        {
            if (authenticated) ActivateItem(_homeVM);
        }

        public void UserView()
        {
            if (authenticated) ActivateItem(_userVM);
        }

        public void View()
        {
            if (authenticated) throw new NotImplementedException();
            //ActivateItem();
        }        
    }
}
