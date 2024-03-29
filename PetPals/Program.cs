﻿namespace PetPals
{
    using PetPals.Model;
    using PetPals.Repository;
    using PetPals.Service;
    using System;
    using System.Security.Cryptography.X509Certificates;

    class Program
    {
        static IDonationService donationService = new DonationService();
        static IPetShelterService petShelterService = new PetShelterService();
        static IAdoptionService adoptionService = new AdoptionService();    
        static void Main()
        {

            
            
            while (true)
            {
                Console.WriteLine("\t\t\t--------Welcome to PetPals--------\n");
                Console.WriteLine("Select an option:\n");
                Console.WriteLine(" 1. Donate for a good cause");
                Console.WriteLine(" 2. Pets Management");
                Console.WriteLine(" 3. Adoption Event");
                Console.WriteLine(" 0. Exit");
                Console.Write("\nPlease enter your choice: ");
                string mainChoice = Console.ReadLine();
                switch (mainChoice)
                {
                    case "1":
                        DonationMenu();
                        break;
                    case "2":
                        PetManagementMenu();
                        break;
                    case "3":
                        AdoptionMenu();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Enter Valid choice");
                        Thread.Sleep(1000);
                        break;
                }
            }



            
        }

        static void DonationMenu()
        {
            while (true)
            {
                Console.WriteLine("\t\t\t\tDonation Page\n");
                Console.WriteLine("You can make a donation in the following ways:\n");
                Console.WriteLine(" 1. Cash donation");
                Console.WriteLine(" 2. Item donation");
                Console.WriteLine(" 3. Return to main menu");
                Console.Write("\nSelect the type of donation you would like to make: ");
                string donationChoice = Console.ReadLine();
                switch (donationChoice)
                {
                    case "1":
                        donationService.CashDonation();
                        break;
                    case "2":
                        donationService.ItemDonation();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice selected");
                        Thread.Sleep(1000);
                        break;

                }
                
            }
        }

        static void PetManagementMenu()
        {
            
            while (true)
            {
                Console.WriteLine("\t\t\tWelcome to Pet management portal");
                Console.WriteLine("\n 1. Available pets for adoption");
                Console.WriteLine(" 2. Add a pet data");
                Console.WriteLine(" 3. Remove a pet data");
                Console.WriteLine(" 4. Return to main menu");
                Console.Write("\nEnter your choice: ");
                string petChoice = Console.ReadLine();
                switch (petChoice)
                {
                    case "1":
                        petShelterService.showAvailablePets();
                        break;
                    case "2":
                        petShelterService.AddPet();
                        break;
                    case "3":
                        petShelterService.RemovePet();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        Thread.Sleep(1000);
                        break;
                }
                
            }
        }
        static void AdoptionMenu()
        {
            
            while (true)
            {
                Console.WriteLine("\t\t\tWelcome to Adoption event!");
                Console.WriteLine("\n 1. Host a new event");
                Console.WriteLine(" 2. view all Events");
                Console.WriteLine(" 3. Register Participant for an event");
                Console.WriteLine(" 4. view all participants");
                Console.WriteLine(" 5. Adopt a pet");
                Console.WriteLine(" 6. Return to main menu");
                Console.Write("\nEnter your choice: ");
                string eventChoice = Console.ReadLine();
                switch (eventChoice)
                {
                    case "1":
                        adoptionService.NewAdoptionEvent();
                        break;
                    case "2":
                        adoptionService.ViewAllEvents();
                        break;
                    case "3":
                        adoptionService.RegisterParticipantForEvent();
                        break;
                    case "4":
                        adoptionService.ViewAllParticipants();
                        break;
                    case "5":
                        adoptionService.AdoptPet();
                        break;
                    case "6":
                        return;
                    default :
                        Console.WriteLine("Invalid Choice");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }
    }

}
