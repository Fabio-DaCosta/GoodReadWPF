using Caliburn.Micro;
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
    }
}
