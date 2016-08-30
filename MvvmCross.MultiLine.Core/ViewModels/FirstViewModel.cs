using MvvmCross.Core.ViewModels;
using MvvmCross.MultiLine.Core.Model;
using System.Collections.Generic;
using System;
using MvvmCross.Platform;
using MvvmCross.MultiLine.Core.Service;

namespace MvvmCross.MultiLine.Core.ViewModels
{
    public class FirstViewModel 
        : MvxViewModel
    {
        private List<SampleData> _data;
        public List<SampleData> Data
        {
            get { return _data; }
            set { SetProperty(ref _data, value); }
        }

        public FirstViewModel()
        {
            SetupList();
        }

        private void SetupList()
        {
            LoadData();
        }
        
        private async void LoadData()
        {
            var dataService = Mvx.Resolve<IDataService>();
            Data = await dataService.GetSampleData(); 
        }

    }
}
