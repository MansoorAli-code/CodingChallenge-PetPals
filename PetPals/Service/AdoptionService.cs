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
    internal class AdoptionService : IAdoptionService
    {
        readonly IAdoptionEventRepository _adoptionRep;
        public AdoptionService()
        {
            _adoptionRep = new AdoptionEventRepository();
        }
        public void AdoptPet()
        {
            Console.WriteLine("\nEnter the id of the pet you want to adopt: ");
            int petId = int.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter User id: ");
            int userId = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if(_adoptionRep.Adopt(petId, userId))
            {
                Console.WriteLine($"Congratulations! You have successfully adopted a pet {petId}!");
                Thread.Sleep(2000);
                return;
            }
            else
            {
                Console.WriteLine("incorrect ids");
                Thread.Sleep(2000);
            }

        }

        public void NewAdoptionEvent()
        {
            
            AdoptionEvent adoptionEvent = new AdoptionEvent();
            Console.WriteLine("\t\t\tEvent Registration");
            Console.WriteLine("\nEnter Event Name: ");
            adoptionEvent.EventName = Console.ReadLine();
            Console.WriteLine("\nEnter Event Location: ");
            adoptionEvent.Location = Console.ReadLine();
            Console.WriteLine("\nEnter the date of hosting the event (dd-MM-yyyy): ");
            try
            {
                if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                {
                    adoptionEvent.EventDate = parsedDate;
                }
                if (_adoptionRep.HostEvent(adoptionEvent))
                {
                    Console.WriteLine($"Event Registered Successfully.");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("Something went wrong");
                    Thread.Sleep(2000);
                }
            }
            catch
            {
                throw new AdoptionException("Event not registered");
            }
        }

        public void RegisterParticipantForEvent()
        {
            Console.WriteLine("\t\t\tParticipant Registration for an event\n");
            Participants participant = new Participants();
            Console.WriteLine("\nEnter Participant Name: ");
            participant.ParticipantName = Console.ReadLine();
            Console.WriteLine("\nEnter Participant Type: ");
            participant.ParticipantType = Console.ReadLine();
            Console.WriteLine("\nEnter the Event ID you want to participate in: ");
            participant.EventId = int.Parse(Console.ReadLine());
            try
            {
                if (_adoptionRep.RegisterParticipant(participant))
                {
                    Console.WriteLine("Thank you for registering to the event.");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("Registration Unsuccessful");
                    Thread.Sleep(2000);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ViewAllEvents()
        {
            Console.WriteLine("\t\tHere is a list of all pets that are currently available for adoption:\n");
            List<AdoptionEvent> events = _adoptionRep.ShowAllEvents();
            foreach (AdoptionEvent ae in events)
            {
                Console.WriteLine(ae);
            }
            Thread.Sleep(2000);
        }

        public void ViewAllParticipants()
        {
            Console.WriteLine("\t\tHere is a list of all participants:\n");
            List<Participants> participants = _adoptionRep.GetAllParticipants();
            foreach (Participants p in participants)
            {
                Console.WriteLine(p);
            }
            Thread.Sleep(2000);
        }
    }
}
