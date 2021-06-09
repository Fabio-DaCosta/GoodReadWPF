using Caliburn.Micro;
using GoodRead.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodRead.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private readonly HomeViewModel _homeVM;

        public ShellViewModel(HomeViewModel homeVW)
        {
            _homeVM = homeVW;
            ActivateItem(_homeVM);
        }

        public void HomeView()
        {
            ActivateItem(_homeVM);
        }

        public void UserView()
        {
            ActivateItem(new UserViewModel());
        }
    }
}
