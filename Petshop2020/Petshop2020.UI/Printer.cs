using Petshop2020.Core.Application_Service;
using Petshop2020.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petshop2020.UI
{
    public class Printer : IPrinter
    {

        private readonly IServiceImpl _serviceImpl;
        public Printer(IServiceImpl serviceImpl)
        {
            _serviceImpl = serviceImpl; 
        }

        public void StartUI()
        {
            string[] menuItems =
            {
                "Show all pets",
                "Add a pet",
                "Delete a pet",
                "Edit a pet",
                "Order pets by price (Lowest to highest)",
                "Search for type of pet",
                "Get five cheapest pets",
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 8)
            {
                switch (selection)
                {
                    case 1:
                        ListAllPets();
                        break;
                    case 2:
                        AddPet();
                        break;
                    case 3:
                        DeletePet();
                        break;
                    case 4:
                        EditPet();
                        break;
                    case 5:
                        OrderPetsByPrice();
                        break;
                    case 6:
                        SearchForType();
                        break;
                    case 7:
                        GetFiveCheapestPets();
                        break;
                    default:
                        Console.WriteLine("Closing the program");
                        break;
                }

                selection = ShowMenu(menuItems);
            }
        }

        private int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("SELECT YOUR CHOICE");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {menuItems[i]}");
            }

            int selection;

            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 8)
            {
                Console.WriteLine("Please input a number between 1-5");
            }

            return selection;
        }

        private int PrintFindPetId()
        {
            Console.WriteLine("Insert Pet ID: ");
            int id;
            while(!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return id;
        }

        private void ListAllPets()
        {
            var pets = _serviceImpl.GetAllPets();
            Console.WriteLine("List of all pets:");
            foreach (var pet in pets)
            {
                Console.WriteLine($"ID: {pet.id}\n Name: {pet.name}\n Birthdate: {pet.birthDate}" +
                    $"\n Previous owner: {pet.previousOwner}\n Sold date: {pet.soldDate}\n" +
                    $" Type: {pet.type}\n Price: {pet.price}\n");
            }
        }

        private void SearchForType()
        {
            Console.WriteLine("Insert type of pet");
            var type = Console.ReadLine().ToLower();
            if (_serviceImpl.SearchForType(type) != null)   
            {
                foreach (var pet in _serviceImpl.SearchForType(type))
                {
                    Console.WriteLine($"ID: {pet.id} - Name: {pet.name} ({pet.type})");
                }
            }
            else
            {
                Console.WriteLine("No matches found");
            }
        }

        private void GetFiveCheapestPets()
        {
            var pets = _serviceImpl.GetFiveCheapestPets();
            Console.WriteLine("Top 5 cheapest pets");
            int i = 1;
            foreach (var pet in pets)
            {
                Console.WriteLine($"{i}. Name: {pet.name} ({pet.id}) - Type: {pet.type} - Price: {pet.price}");
                i++;
            }
        }

        private void AddPet()
        {
            var name = AskQuestion("Name:");
            var type = AskQuestion("Type: ");
            double price; Console.WriteLine("Price: ");
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Please select a valid input");
            }
            DateTime birthdate; Console.WriteLine("Birth date (yyyy-mm-dd): ");
            while (!DateTime.TryParse(Console.ReadLine(), out birthdate))
            {
                Console.WriteLine("Please select a valid input with the format yyyy-mm-dd");
            }
            DateTime solddate; Console.WriteLine("Sold date (yyyy-mm-dd): ");
            while (!DateTime.TryParse(Console.ReadLine(), out solddate))
            {
                Console.WriteLine("Please select a valid input with the format yyyy-mm-dd");
            }
            var previousOwner = AskQuestion("Previous owner: ");

            var newPet = new Pet()
            {
                name = name,
                type = type,
                price = price,
                birthDate = birthdate,
                soldDate = solddate,
                previousOwner = previousOwner
            };

            var pet = _serviceImpl.NewPet(newPet);
            _serviceImpl.CreatePet(pet);
        }

        private void DeletePet()
        {
            var idToDelete = PrintFindPetId();
            var deletedPet = _serviceImpl.DeletePet(idToDelete);
            Console.WriteLine("You have deleted " + deletedPet.name + " (" + deletedPet.type+ ")" + " with the id of " + deletedPet.id);
        }

        private void EditPet()
        {
            var idToEdit = PrintFindPetId();
            var petToEdit = _serviceImpl.FindPetById(idToEdit);

            Console.WriteLine($"Updating {petToEdit.name} ({petToEdit.type})");

            var newName = AskQuestion("Name:");
            var newType = AskQuestion("Type: ");
            double newPrice; Console.WriteLine("Price: ");
            while (!double.TryParse(Console.ReadLine(), out newPrice))
            {
                Console.WriteLine("Please select a valid input");
            }
            DateTime newBirthdate; Console.WriteLine("Birth date (yyyy-mm-dd): ");
            while (!DateTime.TryParse(Console.ReadLine(), out newBirthdate))
            {
                Console.WriteLine("Please select a valid input with the format yyyy-mm-dd");
            }
            DateTime newSolddate; Console.WriteLine("Sold date (yyyy-mm-dd): ");
            while (!DateTime.TryParse(Console.ReadLine(), out newSolddate))
            {
                Console.WriteLine("Please select a valid input with the format yyyy-mm-dd");
            }
            var newPreviousOwner = AskQuestion("Previous owner: ");
            _serviceImpl.UpdatePet(new Pet()
            {
                id = idToEdit,
                name = newName,
                type = newType,
                price = newPrice,
                birthDate = newBirthdate,
                soldDate = newSolddate,
                previousOwner = newPreviousOwner
            });
        }

        

        private string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        private void OrderPetsByPrice()
        {
            var pets = _serviceImpl.SortPetsByPrice();
            foreach (var pet in pets)
            {
                Console.WriteLine($"ID: {pet.id}\n Name: {pet.name} ({pet.type})\n Price: {pet.price}\n");
            }
        }



    }
}
