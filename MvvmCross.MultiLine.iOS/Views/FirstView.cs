using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.MultiLine.Core.ViewModels;
using System;
using UIKit;
using Foundation;

namespace MvvmCross.MultiLine.iOS.Views
{
    public class FirstView : MvxTableViewController 
    {
        private FirstViewTableSource _source; 

        public FirstView() : base()
        {
        }

        public FirstView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetupUi();
            CreateBindings();

        }
        
        private void SetupUi()
        {
            this.Title = "MvvmCross Sample";
            this.TableView.BackgroundColor = UIColor.White;
            this.TableView.EstimatedRowHeight = 60.0f;
            this.TableView.RowHeight = UITableView.AutomaticDimension; 
            this.TableView.RegisterClassForCellReuse(typeof(MultiLineCellQuote), MultiLineCellQuote.Key);
            this.TableView.RegisterClassForCellReuse(typeof(MultiLineCellPerson), MultiLineCellPerson.Key);
			this.SetupToolbarEvents();

            _source = new FirstViewTableSource(this.TableView);
            this.TableView.Source = _source;

        }

		private void SetupToolbarEvents()
		{
			var brokenButton = new UIBarButtonItem("Broken", UIBarButtonItemStyle.Plain, BrokenTapped); 
			var fixedButton = new UIBarButtonItem("Work Around", UIBarButtonItemStyle.Plain, WorkAroundTapped);
			UIBarButtonItem[] items = new UIBarButtonItem[]
			{
				brokenButton,
				new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace) { Width = 50 },
				fixedButton
			};

			this.SetToolbarItems(items, false);
		}

		private void BrokenTapped(object sender, EventArgs e)
		{
			_source.IsBroken = true;	
			TableView.ReloadData();
			this.TableView.ScrollToRow(NSIndexPath.FromRowSection(0, 0), UITableViewScrollPosition.Top, true);
		}

		private void WorkAroundTapped(object sender, EventArgs e)
		{
			_source.IsBroken = false;
			TableView.ReloadData();
			this.TableView.ScrollToRow(NSIndexPath.FromRowSection(0, 0), UITableViewScrollPosition.Top, true);
		}

		private void CreateBindings()
        {
            this.CreateBinding<FirstViewTableSource>(_source).For(p => p.ItemsSource).To<FirstViewModel>(vm => vm.Data).Apply();
        }
    }
}
