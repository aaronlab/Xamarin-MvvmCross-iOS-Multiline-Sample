using MvvmCross.Core.ViewModels;
using System.Linq;
using UIKit;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.iOS.Views;

namespace MvvmCross.MultiLine.iOS.Presenter
{
	public class CustomViewPresenter : MvxIosViewPresenter
	{
		public CustomViewPresenter(UIApplicationDelegate applicationDelegate, UIWindow window) :
			base(applicationDelegate, window)
		{

		}

		/// <summary>
		/// Provides custom Navigation Controller for the Root
		/// </summary>
		/// <param name="viewController"></param>
		/// <returns></returns>
		protected override UINavigationController CreateNavigationController(UIViewController viewController)
		{
			//var navController = base.CreateNavigationController(viewController);
			var navController = new UINavigationController();
			navController.NavigationBarHidden = false;
			navController.ToolbarHidden = false;

	

			navController.PushViewController(viewController, false);
			return navController;
		}
	}
}
