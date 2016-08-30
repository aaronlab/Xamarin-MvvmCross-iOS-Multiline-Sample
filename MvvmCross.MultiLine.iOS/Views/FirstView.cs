using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.MultiLine.Core.ViewModels;
using System;
using UIKit;

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

            _source = new FirstViewTableSource(this.TableView);
            this.TableView.Source = _source;    

        } 

        private void CreateBindings()
        {
            this.CreateBinding<FirstViewTableSource>(_source).For(p => p.ItemsSource).To<FirstViewModel>(vm => vm.Data).Apply();
        }
    }
}
