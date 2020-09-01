using Petshop2020.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petshop2020.Core.Application_Service
{
    public interface IServiceImpl
    {
        //New pet
        public Pet NewPet(Pet pet);

        //C - Create pet
        public Pet CreatePet(Pet pet);

        //R - Read all pets
        public List<Pet> GetAllPets();

        //U - Update pet
        public Pet UpdatePet(Pet petToUpdate);

        //D - Delete pet
        public Pet DeletePet(int id);

        public Pet FindPetById(int id);

        public List<Pet> SortPetsByPrice();

        public List<Pet> SearchForType(string type);

        public List<Pet> GetFiveCheapestPets();







    }
}
