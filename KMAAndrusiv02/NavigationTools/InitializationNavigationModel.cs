using System;

namespace KMAAndrusiv02.NavigationTools
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Input:
                    ViewsDictionary.Add(viewType, new PersonControl());
                    break;
                case ViewType.Results:
                    ViewsDictionary.Add(viewType, new ResultsControl());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}