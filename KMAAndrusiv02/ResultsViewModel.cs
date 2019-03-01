using KMAAndrusiv02.NavigationTools;
using System;

namespace KMAAndrusiv02
{
    class ResultsViewModel : BaseViewModel
    {
        private PersonManager _personManagerInstance = PersonManager.Instance;

        RelayCommand<object> _returnCommand;

        public PersonManager PersonManagerInstance
        {
            get
            {
                return _personManagerInstance;
            }
        }

        public RelayCommand<Object> ReturnCommand
        {
            get
            {
                return _returnCommand ?? (_returnCommand = new RelayCommand<Object>(
                    o => { NavigationManager.Instance.Navigate(ViewType.Input); }));
            }
        }




    }
}
