using Petshop2020.Core.Domain_Service;
using Petshop2020.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Petshop2020.Core.Application_Service.Service
{
    public class Impl: IServiceImpl
    {
        readonly IPetRepository _petRepo;

        public Impl(IPetRepository petRepository)
        {
            _petRepo = petRepository;
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepo.CreatePet(pet);
        }

        public Pet DeletePet(int id)
        {
            return _petRepo.DeletePet(id);
        }

        public Pet FindPetById(int id)
        {
            return _petRepo.ReadById(id);
        }

        public List<Pet> GetAllPets()
        {
            return _petRepo.ReadAllPets().ToList();
        }

        public Pet NewPet(Pet pet)
        {
            var newPet = new Pet()
            {
                name = pet.name,
                birthDate = pet.birthDate,
                color = pet.color,
                price = pet.price,
                previousOwner = pet.previousOwner,
                soldDate = pet.soldDate,
                type = pet.type
            };
            return newPet;
            
        }

        public List<Pet> SearchForType(string type)
        {
            var allPets = GetAllPets();
            var query = allPets.Where(searchPet => searchPet.type.ToLower().Equals(type));
            return query.ToList();
        }

        public List<Pet> SortPetsByPrice()
        {
            var allPets = GetAllPets();
            var query = allPets.OrderBy(pet => pet.price);
            return query.ToList();
        }

        public List<Pet> GetFiveCheapestPets()
        {
            var allPetsSorted = SortPetsByPrice();
            var query = allPetsSorted.Take(5);
            return query.ToList();
        }



        public Pet UpdatePet(Pet petToUpdate)
        {   
            var pet = FindPetById(petToUpdate.id);
            pet.name = petToUpdate.name;
            pet.birthDate = petToUpdate.birthDate;
            pet.color = petToUpdate.color;
            pet.price = petToUpdate.price;
            pet.previousOwner = petToUpdate.previousOwner;
            pet.soldDate = petToUpdate.soldDate;
            pet.type = petToUpdate.type;
            return pet;
            
        }
    }
}
