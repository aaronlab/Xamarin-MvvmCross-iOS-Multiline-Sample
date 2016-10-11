using System;
using System.Collections.Generic;

using UIKit;
using Foundation;

using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Bindings;


namespace MvvmCross.MultiLine.iOS.Views
{
	public class ExtendedCell : MvxTableViewCell
	{

		protected bool DidSetupConstraints { get; set; }

		public List<NSLayoutConstraint> CellConstraints { get; set; }

		public ExtendedCell()
			: this(string.Empty)
		{
			DidSetupConstraints = false;
			CellConstraints = new List<NSLayoutConstraint>();
		}

		public ExtendedCell(string bindingText)
		{
			DidSetupConstraints = false;
			CellConstraints = new List<NSLayoutConstraint>();
			this.CreateBindingContext(bindingText);
		}

		public ExtendedCell(IEnumerable<MvxBindingDescription> bindingDescriptions)
		{
			DidSetupConstraints = false;
			CellConstraints = new List<NSLayoutConstraint>();
			this.CreateBindingContext(bindingDescriptions);
		}

		public ExtendedCell(IntPtr handle)
			: this(string.Empty, handle)
		{
			DidSetupConstraints = false;
			CellConstraints = new List<NSLayoutConstraint>();
		}

		public ExtendedCell(string bindingText, IntPtr handle)
			: base(handle)
		{
			DidSetupConstraints = false;
			CellConstraints = new List<NSLayoutConstraint>();
			this.CreateBindingContext(bindingText);
		}

		public ExtendedCell(IEnumerable<MvxBindingDescription> bindingDescriptions, IntPtr handle)
			: base(handle)
		{
			DidSetupConstraints = false;
			CellConstraints = new List<NSLayoutConstraint>();
			this.CreateBindingContext(bindingDescriptions);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="bindingText"></param>
		/// <param name="cellStyle"></param>
		/// <param name="cellIdentifier"></param>
		/// <param name="tableViewCellAccessory"></param>
		/// STATCODE_CA1026
		public ExtendedCell(string bindingText, UITableViewCellStyle cellStyle, NSString cellIdentifier,
			UITableViewCellAccessory tableViewCellAccessory)
		{
			//STATCODE_CA2214 - Suppressed here cause of following note
			// note that we allow the virtual Accessory property to be set here - but do not seal
			// it. Previous `sealed` code caused odd, unexplained behaviour in MonoTouch
			// - see https://github.com/MvvmCross/MvvmCross/issues/524
			Accessory = tableViewCellAccessory;
			this.CreateBindingContext(bindingText);

			DidSetupConstraints = false;
			CellConstraints = new List<NSLayoutConstraint>();
		}
		public ExtendedCell(string bindingText, UITableViewCellStyle cellStyle, NSString cellIdentifier)
			
		{
			//STATCODE_CA2214 - Suppressed here cause of following note
			// note that we allow the virtual Accessory property to be set here - but do not seal
			// it. Previous `sealed` code caused odd, unexplained behaviour in MonoTouch
			// - see https://github.com/MvvmCross/MvvmCross/issues/524
			Accessory = UITableViewCellAccessory.None;
			this.CreateBindingContext(bindingText);

			DidSetupConstraints = false;
			CellConstraints = new List<NSLayoutConstraint>();
		}
		/// STATCODE_CA1026
		public ExtendedCell(IEnumerable<MvxBindingDescription> bindingDescriptions,
			UITableViewCellStyle cellStyle, NSString cellIdentifier,
			UITableViewCellAccessory tableViewCellAccessory)
		{
			//STATCODE_CA2214 - Suppressed here cause of following note
			// note that we allow the virtual Accessory property to be set here - but do not seal
			// it. Previous `sealed` code caused odd, unexplained behaviour in MonoTouch
			// - see https://github.com/MvvmCross/MvvmCross/issues/524
			Accessory = tableViewCellAccessory;
			this.CreateBindingContext(bindingDescriptions);

			DidSetupConstraints = false;
			CellConstraints = new List<NSLayoutConstraint>();
		}

		public ExtendedCell(IEnumerable<MvxBindingDescription> bindingDescriptions,
		UITableViewCellStyle cellStyle, NSString cellIdentifier)
		{
			//STATCODE_CA2214 - Suppressed here cause of following note
			// note that we allow the virtual Accessory property to be set here - but do not seal
			// it. Previous `sealed` code caused odd, unexplained behaviour in MonoTouch
			// - see https://github.com/MvvmCross/MvvmCross/issues/524
			Accessory = UITableViewCellAccessory.None;
			this.CreateBindingContext(bindingDescriptions);

			DidSetupConstraints = false;
			CellConstraints = new List<NSLayoutConstraint>();
		}


		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				BindingContext.ClearAllBindings();

				if (CellConstraints != null && CellConstraints.Count > 0)
				{
					for (var counter = CellConstraints.Count - 1; counter <= 0; counter--)
					{
						CellConstraints[counter].Dispose();
						CellConstraints.RemoveAt(counter);
					}
				}
			}
			base.Dispose(disposing);
		}

		public object DataContext
		{
			get { return BindingContext.DataContext; }
			set { BindingContext.DataContext = value; }
		}

		protected virtual void CreateBindings()
		{

		}

		protected virtual void SetupConstraints()
		{

		}

		public void ResetBindings()
		{
			this.BindingContext.ClearAllBindings();
			this.CreateBindings();
		}

		public override void UpdateConstraints()
		{
			base.UpdateConstraints();
			if (DidSetupConstraints)
			{
				return;
			}
			SetupConstraints();
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			this.ContentView.SetNeedsLayout();
			this.ContentView.LayoutIfNeeded();
		}
	}
}
