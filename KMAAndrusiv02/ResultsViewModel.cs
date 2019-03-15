using KMAAndrusiv02.NavigationTools;
using System;

namespace KMAAndrusiv02
{
    internal class ResultsViewModel : BaseViewModel
    {
        private RelayCommand<object> _returnCommand;

        public PersonManager PersonManagerInstance { get; } = PersonManager.Instance;

        public RelayCommand<object> ReturnCommand
        {
            get
            {
                return _returnCommand ?? (_returnCommand = new RelayCommand<object>(
                    o => { NavigationManager.Instance.Navigate(ViewType.Input); }));
            }
        }




    }
}
