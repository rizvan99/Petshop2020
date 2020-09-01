using Petshop2020.Core.Domain_Service;
using Petshop2020.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Petshop2020.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {

        private static List<Pet> _pets = new List<Pet>();
        private static int id = 1;

        public PetRepository()
        {
            InitData();
        }

        public Pet CreatePet(Pet pet)
        {
            pet.id = id++;
            _pets.Add(pet);
            return pet;
        }

        public Pet DeletePet(int id)
        {
            var petToDelete = this.ReadById(id);
            if (petToDelete != null)
            {
                _pets.Remove(petToDelete);
                return petToDelete;
            }
            return null;
        }

        public IEnumerable<Pet> ReadAllPets()
        {
            return _pets;
        }

        public Pet ReadById(int id)
        {
            foreach (var pet in _pets)
            {   
                if (pet.id == id)
                {
                    return pet;
                }
            }
            return null;
        }

        public Pet UpdatePet(Pet petToUpdate)
        {
            var petFromDB = this.ReadById(petToUpdate.id);
            if (petFromDB != null)
            {
                petFromDB.name = petToUpdate.name;
                petFromDB.type = petToUpdate.type;
                petFromDB.birthDate = petToUpdate.birthDate;
                petFromDB.soldDate = petToUpdate.soldDate;
                petFromDB.color = petToUpdate.color;
                petFromDB.previousOwner = petToUpdate.previousOwner;
                petFromDB.price = petToUpdate.price;
                return petFromDB;
            }
            return null;
        }

        private void InitData()
        {
            var pet1 = new Pet()
            {
                name = "Billy",
                type = "Goat",
                birthDate = DateTime.Now.AddYears(-5),
                color = "White",
                previousOwner = "Joe",
                price = 500,
                soldDate = DateTime.Now.AddYears(-2)
            };
            CreatePet(pet1);

            var pet2 = new Pet()
            {
                name = "Bob",
                type = "Dog",
                birthDate = DateTime.Now.AddYears(-3),
                color = "Black",
                previousOwner = "Michael",
                price = 100,
                soldDate = DateTime.Now.AddYears(-1)
            };
            CreatePet(pet2);

            var pet3 = new Pet()
            {
                name = "Joe",
                type = "Tiger",
                birthDate = DateTime.Now.AddYears(-10),
                color = "Orange",
                previousOwner = "Tommy",
                price = 1500,
                soldDate = DateTime.Now.AddYears(-2)
            };
            CreatePet(pet3);

            var pet4 = new Pet()
            {
                name = "Timmy",
                type = "Monkey",
                birthDate = DateTime.Now.AddYears(-2),
                color = "Brown",
                previousOwner = "Dimitri",
                price = 1250,
                soldDate = DateTime.Now.AddYears(-1)
            };
            CreatePet(pet4);

            var pet5 = new Pet()
            {
                name = "Splinter",
                type = "Rat",
                birthDate = DateTime.Now.AddYears(-3),
                color = "Grey",
                previousOwner = "Michael",
                price = 50,
                soldDate = DateTime.Now.AddYears(-1)
            };
            CreatePet(pet5);

            var pet6 = new Pet()
            {
                name = "Mujo",
                type = "Bird",
                birthDate = DateTime.Now.AddYears(-2),
                color = "Yellow",
                previousOwner = "Betty",
                price = 145,
                soldDate = DateTime.Now.AddYears(-1)
            };
            CreatePet(pet6);

        }

    }
}
