using EY.Core.IOSLib.Helper;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.MultiLine.Core.Model;
using MvvmCross.MultiLine.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace MvvmCross.MultiLine.iOS.Views
{
    public class MultiLineCellPerson : MvxTableViewCell
    {
        public const string Key = "MultiLineCellPerson";

        private UILabel _name;
        private UILabel _address;
        private UILabel _city;
        private UILabel _postal;
        private UILabel _country;
        private UILabel _region;

        private bool _didSetupConstraints;
        public MultiLineCellPerson(IntPtr handle) : base(handle)
        {
            _didSetupConstraints = false;
            SetupUi();
            CreateBindings();
        }

        public MultiLineCellPerson()
        {
            _didSetupConstraints = false;
            SetupUi();
            CreateBindings();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (_name != null)
                {
                    _name.Dispose();
                    _name = null;
                }
                if (_address != null)
                {
                    _address.Dispose();
                    _address = null;
                }
                if (_city != null)
                {
                    _city.Dispose();
                    _city = null;
                }
                if (_postal != null)
                {
                    _postal.Dispose();
                    _postal = null;
                }
                if (_country != null)
                {
                    _country.Dispose();
                    _country = null;
                }
                if (_region != null)
                {
                    _region.Dispose();
                    _region = null;
                }
            }
        }

        public override void UpdateConstraints()
        {
            base.UpdateConstraints();
            if (_didSetupConstraints)
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

        private void CreateBindings()
        {
            this.DelayBind(() =>
            {
                this.CreateBinding<UILabel>(_name).To<SampleData>(vm => vm.Name).Apply();
                this.CreateBinding<UILabel>(_address).To<SampleData>(vm => vm.Address1).Apply();
                this.CreateBinding<UILabel>(_city).To<SampleData>(vm => vm.City).Apply();
                this.CreateBinding<UILabel>(_postal).To<SampleData>(vm => vm.Postal).Apply();
                this.CreateBinding<UILabel>(_country).To<SampleData>(vm => vm.Country).Apply();
                this.CreateBinding<UILabel>(_region).To<SampleData>(vm => vm.Region).Apply();
            });
        }


        private void SetupConstraints()
        {
            AutoLayoutHelper.AttachToParentTop(ContentView, _name, 5, "ContentView|_name|AttachToParentTop");
            AutoLayoutHelper.AttachToParentHorizontally(ContentView, _name, 5, "ContentView|_name|AttachToParentHortizontally");

            AutoLayoutHelper.FollowControlVertically(ContentView, _name, _address, 5, "ContentView|_name|_address|FollowControlVertically");
            AutoLayoutHelper.AttachToParentHorizontally(ContentView, _address, 5, "ContentView|_address|AttachToParentHorizontally");

            AutoLayoutHelper.FollowControlVertically(ContentView, _address, _city, 5, "ContentView|_address|_city|FollowControlVertically");
            AutoLayoutHelper.AttachToParentHorizontally(ContentView, _city, 5, "ContentView|_city|AttachToParentHorizontally");

            AutoLayoutHelper.FollowControlVertically(ContentView, _city, _postal, 5, "ContentView|_city|_postal|FollowControlVertically");
            AutoLayoutHelper.AttachToParentHorizontally(ContentView, _postal, 5, "ContentView|_postal|AttachToParentHorizontally");

            AutoLayoutHelper.FollowControlVertically(ContentView, _postal, _country, 5, "ContentView|_postal|_country|FollowControlVertically");
            AutoLayoutHelper.AttachToParentHorizontally(ContentView, _country, 5, "ContentView|_country|AttachToParentHorizontally");

            AutoLayoutHelper.FollowControlVertically(ContentView, _country, _region, 5, "ContentView|_country|_region|FollowControlVertically");
            AutoLayoutHelper.AttachToParentHorizontally(ContentView, _region, 5, "ContentView|_region|AttachToParentHorizontally");

            AutoLayoutHelper.AttachToParentBottom(ContentView, _region, 5, "ContentView|_region|AttachToParentTop");

            _didSetupConstraints = true;
        }

        private void SetupUi()
        {
            _name = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Lines = 1,
                LineBreakMode = UILineBreakMode.WordWrap,
                Font = UIFont.PreferredHeadline,
            };
            ContentView.Add(_name);

            _address = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Lines = 1,
                LineBreakMode = UILineBreakMode.TailTruncation,
                TextColor = UIColor.Gray,
                Font = UIFont.PreferredSubheadline,
            };
            ContentView.Add(_address);

            _city = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Lines = 1,
                LineBreakMode = UILineBreakMode.WordWrap,
                TextColor = UIColor.Gray,
                Font = UIFont.PreferredFootnote,
            };
            ContentView.Add(_city);

            _postal = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Lines = 1,
                LineBreakMode = UILineBreakMode.WordWrap,
                TextColor = UIColor.Gray,
                Font = UIFont.PreferredCaption1,
            };
            ContentView.Add(_postal);

            _country = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Lines = 1,
                LineBreakMode = UILineBreakMode.WordWrap,
                TextColor = UIColor.Gray,
                Font = UIFont.PreferredCaption2,
            };
            ContentView.Add(_country);
            _region = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Lines = 1,
                LineBreakMode = UILineBreakMode.WordWrap,
                TextColor = UIColor.Gray,
                Font = UIFont.PreferredBody
            };
            ContentView.Add(_region);
        }
    }
}
