using MvvmCross.Core.IOSLib.Helper;
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
    public class MultiLineCellQuote : ExtendedCell
    {
        public const string Key = "MultiLineCell";

        private UILabel _phrase;
        private UILabel _key;
        private UILabel _date;

        private bool _didSetupConstraints;
        public MultiLineCellQuote(IntPtr handle) : base(handle)
        {
            _didSetupConstraints = false;
            SetupUi();
            CreateBindings();
        }

        public MultiLineCellQuote()
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
                if (_phrase != null)
                {
                    _phrase.Dispose();
                    _phrase = null;
                }
                if (_key != null)
                {
                    _key.Dispose();
                    _key = null;
                }
                if (_date != null)
                {
                    _date.Dispose();
                    _date = null;
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

        protected override void CreateBindings()
        {
            this.DelayBind(() =>
            {
                this.CreateBinding<UILabel>(_key).To<SampleData>(vm => vm.Key).Apply();
                this.CreateBinding<UILabel>(_phrase).To<SampleData>(vm => vm.Phrases).Apply();
                this.CreateBinding<UILabel>(_date).To<SampleData>(vm => vm.DateHired).Apply();
            });
        }


        protected override void SetupConstraints()
        {
            AutoLayoutHelper.AttachToParentTop(ContentView, _key, 5, "ContentView|_artist|AttachToParentTop");
            AutoLayoutHelper.AttachToParentHorizontally(ContentView, _key, 5, "ContentView|_artist|AttachToParentHortizontally");

            AutoLayoutHelper.FollowControlVertically(ContentView, _key, _phrase, 5, "ContentView|_artist|FollowControlVertically");
            AutoLayoutHelper.AttachToParentHorizontally(ContentView, _phrase, 5, "ContentView|_title|AttachToParentHorizontally");

            AutoLayoutHelper.FollowControlVertically(ContentView, _phrase, _date, 5, "ContentView|_artist|_lyrics|FollowControlVertically");
            AutoLayoutHelper.AttachToParentHorizontally(ContentView, _date, 5, "ContentView|_artist|AttachToParentTop");

            AutoLayoutHelper.AttachToParentBottom(ContentView, _date, 5, "ContentView|_artist|AttachToParentTop");

            _didSetupConstraints = true;
        }

        private void SetupUi()
        {
            _phrase = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false, 
                Lines = 0,
                LineBreakMode = UILineBreakMode.WordWrap,
                Font = UIFont.PreferredSubheadline,
            };
            ContentView.Add(_phrase);

            _key = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Lines = 1,
                LineBreakMode = UILineBreakMode.TailTruncation,
                TextColor = UIColor.Blue,
                Font = UIFont.PreferredTitle1,
            };
            ContentView.Add(_key);

            _date = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Lines = 0,
                LineBreakMode = UILineBreakMode.WordWrap,
                TextColor = UIColor.Gray,
                Font = UIFont.PreferredSubheadline,
            };
            ContentView.Add(_date);
        }
    }
}
