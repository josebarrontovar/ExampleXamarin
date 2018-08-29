using App1.Model;
using App1.Service;
using App1.View;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModel
{
    public class PersonViewModel : PersonModel
    {
        #region Props
      
        public ObservableCollection<PersonModel> ObsPersons { get; set; }
        PersonService service = new PersonService();
        PersonModel model;

        private LoginPopupPage _loginPopup;
      
        public Command SaveCmd { get; set; }
        public Command UpdateCmd { get; set; }
        public Command DeleteCmd { get; set; }
        public Command ClearCmd { get; set; }
        public Command WeatherCmd { get; set; }

        #endregion

        public PersonViewModel()
        {
            ObsPersons = service.Consult();
            SaveCmd = new Command(async () => await Save(), ()=>!isLoading);
            UpdateCmd = new Command(async () => await Update(), () => !isLoading);
            DeleteCmd = new Command(async () => await Delete(), () => !isLoading);
            WeatherCmd = new Command(async () => await GoToPageForApi(), () => !isLoading );
            ClearCmd = new Command(Clear,()=>!isLoading);
            _loginPopup = new LoginPopupPage();

        }

        #region Metodos
        private async Task GoToPageForApi()
        {

 
     
        //await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new ApiPage());
        await PopupNavigation.Instance.PushAsync(_loginPopup);

        }

        private async Task Save()
        {
            isLoading = true;
            //El identificador único global, en inglés: 
            //globally unique identifier (GUID) es un número
            //pseudoaleatorio empleado en aplicaciones de software
            Guid IdPerson = Guid.NewGuid();
            model = new PersonModel()
            {
                Name = Name,
                LastName = LastName,
                Age = Age,
                Id = IdPerson.ToString()
            };
            service.Save(model);
            await Task.Delay(2000);
            isLoading = false;
        }

        private async Task Update()
        {
            isLoading = true;
            model = new PersonModel()
            {
                Name = Name,
                LastName = LastName,
                Age = Age,
                Id = Id
            };
            service.Update(model);
            await Task.Delay(2000);
            isLoading = false;
        }

        private async Task Delete()
        {
            isLoading = true;
            service.Delete(Id);
            await Task.Delay(2000);
            isLoading = false;
        }

        private void Clear()
        {
            Name = "";
            LastName = "";
            Age = 0;
            Id = "";
        }
        #endregion

    }
}
