using App1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace App1.Service
{
    public class PersonService
    {
        //Una ObservableCollection es una colección dinámica de objetos 
        //de un tipo dado. Los objetos se pueden agregar, eliminar o 
        //actualizar con una notificación automática de acciones.
        //Cuando un objeto se agrega o elimina de una colección
        //observable, la interfaz de usuario se actualiza automáticamente.
        public ObservableCollection<PersonModel> persons { get; set; }

        public PersonService()
        {
            if(persons is null)
            {
                persons = new ObservableCollection<PersonModel>();
            }
        }

        public ObservableCollection<PersonModel> Consult()
        {
            return persons;
        }

        public void Save(PersonModel model)
        {
            persons.Add(model);
        }
        public void Update(PersonModel model)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i].Id == model.Id)
                {
                    persons[i] = model;
                }
            }

        }
        public void Delete(string idPerson)
        {
            PersonModel model = persons.FirstOrDefault(p => p.Id == idPerson);
            persons.Remove(model);
        }
    }
}
