using PetPals.Exceptions;
using PetPals.Model;
using PetPals.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Service
{
    internal class PetShelterService : IPetShelterService
    {
        readonly IPetShelter _PetShelterRepo;
        public PetShelterService()
        {
            _PetShelterRepo = new PetShelter();
        }
        public void AddPet()
        {
            IPetShelter addPet = new PetShelter();
            Pet petDetails = new Pet();
            Console.WriteLine("\t\t\t\tNew Pet Regesitration\n\n");
            Console.WriteLine("To add details of a pet in our system, please provide following info:\n");
            Console.Write("Enter the Name of pet: ");
            petDetails.Name = Console.ReadLine();
            Console.Write("\nEnter the Age of pet: ");
            petDetails.Age = int.Parse(Console.ReadLine());
            try
            {
                if (petDetails.Age > 0)
                {
                    Console.Write("\nEnter the Type(E.g. Cat, Dog, etc.): ");
                    petDetails.Type = Console.ReadLine();
                    Console.Write("\nEnter the Breed: ");
                    petDetails.Breed = Console.ReadLine();

                    if (_PetShelterRepo.AddPet(petDetails))
                    {
                        Console.WriteLine("Pet Added Successfully");
                        Thread.Sleep(2000);
                    }
                }
                else
                {
                    throw new InvalidPetAgeException("Age must be greater than 0");
                }
            }
            catch (InvalidPetAgeException ipae)
            {
                Console.WriteLine(ipae.Message);
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Thread.Sleep(1000);
            }
        }

        public void RemovePet()
        {
            Console.WriteLine("\t\t\t\tPet Details Deletion\n");
            Console.Write("To remove data of a specific pet from our system, please enter the ID of the pet: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                if (_PetShelterRepo.RemovePet(id))
                {
                    Console.WriteLine("Removed the pet Successfully");
                    Thread.Sleep(2000);
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void showAvailablePets()
        {
            Console.WriteLine("\tHere are all the pets that are currently available for adoption: ");
            List<Pet> availablePets = _PetShelterRepo.GetAllPets();
            foreach (Pet pet in availablePets)
            {
                Console.WriteLine(pet);
            }
            Thread.Sleep(2000);
        }
    }
}
