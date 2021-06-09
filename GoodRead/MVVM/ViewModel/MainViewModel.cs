using GoodRead.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodRead.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand UserViewCommand { get; set; }


        public HomeViewModel HomeVM{ get; set; }
        public UserViewModel UserVM { get; set; }
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            UserVM = new UserViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            UserViewCommand = new RelayCommand(o =>
            {
                CurrentView = UserVM;
            });

        }
    }
}
