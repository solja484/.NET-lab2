﻿using System.Collections.Generic;

namespace KMAAndrusiv02.NavigationTools
{
    internal abstract class BaseNavigationModel : INavigationModel
    {
        protected BaseNavigationModel(IContentOwner contentOwner)
        {
            ContentOwner = contentOwner;
            ViewsDictionary = new Dictionary<ViewType, INavigatable>();
        }

        protected IContentOwner ContentOwner { get; }

        protected Dictionary<ViewType, INavigatable> ViewsDictionary { get; }

        public void Navigate(ViewType viewType)
        {
            if (!ViewsDictionary.ContainsKey(viewType))
                InitializeView(viewType);
            ContentOwner.ContentControl.Content = ViewsDictionary[viewType];

            if (viewType == ViewType.List)
                ViewsDictionary[viewType].TriggerPropertyChanged("Persons");
        }

        protected abstract void InitializeView(ViewType viewType);

    }
}
