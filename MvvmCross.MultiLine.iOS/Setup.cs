using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.MultiLine.Core.Service;
using MvvmCross.MultiLine.Core.ViewModels;
using MvvmCross.MultiLine.iOS.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using System;
using System.Collections.Generic;
using UIKit;

namespace MvvmCross.MultiLine.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }
        
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.LazyConstructAndRegisterSingleton<IDataService, DataService>();
        }

        protected override void InitializeViewLookup()
        {
            var viewModels = new Dictionary<Type, Type>();
            viewModels.Add(typeof(FirstViewModel), typeof(FirstView));

            var container = Mvx.Resolve<IMvxViewsContainer>();
            container.AddAll(viewModels);
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
        
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}
