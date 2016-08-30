using MvvmCross.Binding.iOS.Views;
using Foundation;
using UIKit;
using MvvmCross.Platform.Core;
using System;
using MvvmCross.MultiLine.Core.ViewModels;
using MvvmCross.MultiLine.Core.Model;
using System.Collections.Generic;

namespace MvvmCross.MultiLine.iOS.Views
{
    public class FirstViewTableSource : MvxTableViewSource
    {
        public List<SampleData> Items { get { return this.ItemsSource as List<SampleData>; } }

        public FirstViewTableSource(UITableView tableView):base(tableView)
        {
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return Items.Count; 
        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return 2; 
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            return GetOrCreateCellFor(tableView, indexPath, Items[indexPath.Section]);
        }
        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            UITableViewCell cell = null;

            if ((indexPath.Row % 2) != 0)
            {
                cell = tableView.DequeueReusableCell(MultiLineCellQuote.Key) as MultiLineCellQuote;
            }
            else
            {
                cell = tableView.DequeueReusableCell(MultiLineCellPerson.Key) as MultiLineCellPerson; 
            }

            if(cell != null)
            {
                var bindable = cell as IMvxDataConsumer;
                if (bindable != null)
                {

                    bindable.DataContext = item;
                }
                cell.SetNeedsUpdateConstraints();
                cell.UpdateConstraintsIfNeeded();
            }
            return cell;
        }
    }
}
