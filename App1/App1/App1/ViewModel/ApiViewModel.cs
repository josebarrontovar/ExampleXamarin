using App1.Model;
using App1.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace App1.ViewModel
{
   public  class ApiViewModel
    {
        public Command GetServiceCmd { get; set; }
        ApiService service = new ApiService();
        ObservableCollection<ApiModel> Items = new ObservableCollection<ApiModel>();

        public ApiViewModel()
        {
            this.Items = new ObservableCollection<ApiModel>();
            GetServiceCmd = new Command(GetServiceWeater);
        }

        private async void GetServiceWeater(object obj)
        {
          var ServiceData=  await service.GetVirtualCard(1);
            foreach (var item in ServiceData)
            {
                Items.Add(item);
            }


        }
    }
}
