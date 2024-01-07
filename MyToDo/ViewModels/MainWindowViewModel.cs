using BlankApp1.Models;
using BlankApp1.Services;
using BlankApp1.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;

namespace BlankApp1.ViewModels
{

    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public  IRegionManager regionManager { get; set; }
      public DelegateCommand<string> command { get; set; }
        public MainWindowViewModel(IRegionManager regionManager)
        {
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(IndexView));
            command = new DelegateCommand<string>(Navigate);
            this.regionManager = regionManager;

        }
        public void Navigate(string uri)
        {
            regionManager.RequestNavigate("ContentRegion", uri);
        }
    }
}
