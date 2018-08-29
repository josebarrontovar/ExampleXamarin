using App1.Model;
using App1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PersonPage : ContentPage
	{
        PersonViewModel context = new PersonViewModel();
		public PersonPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            //agregamos el contexto de datos del ViewModel
            BindingContext =context;
            //accion de la lista
            LvPersons.ItemSelected += LvPersons_ItemSelected;

        }

       // Metodo de la accion(Lista)
        private void LvPersons_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                PersonModel model = (PersonModel)e.SelectedItem;
                context.Name = model.Name;
                context.LastName = model.LastName;
                context.Age = model.Age;
                context.Id = model.Id;

              //  Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Selcted Item", context.Name, "Accept");
            }

        }
    }
    }