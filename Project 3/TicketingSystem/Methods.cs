using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TicketingSystem
{
    //Definging the patient class with the apperiate propertise
    class q3_Patient
    {

        public string Name;

        public string Surname;

        public int PriorityLevel;

        public q3_Patient(string name, string surname, int priorityLevel)
        {
            Name = name;
            Surname = surname;
            PriorityLevel = priorityLevel;
        }
    }


    internal class Methods
    {

        //Establishing the Priorit Queue, the TElement will be assign the patient class while the TPriorty will be assign the data type int (0 = highest priority)
        public static PriorityQueue<q3_Patient, int> myQueue = new PriorityQueue<q3_Patient, int>();

       //Adding sample data to be stored into the prioority queue, based on the patient class propertise
        public static void AddPatientData()
        {

            //The mechanism for enqueueing patient has been used in 2 ways, first with the sample data
            myQueue.Enqueue(new q3_Patient("Jade", "Smith", 4), 4);
            myQueue.Enqueue(new q3_Patient("Ethan", "Jacoby", 4), 4);
            myQueue.Enqueue(new q3_Patient("Tiyana", "Allie", 4), 4);
            myQueue.Enqueue(new q3_Patient("Kyle", "Dawson", 2), 2);
            myQueue.Enqueue(new q3_Patient("Daniel", "Johnson", 0), 0);
            myQueue.Enqueue(new q3_Patient("Zoe", "Gade", 1), 1);
        }


        public static void AddPatient()
        {

            Console.WriteLine("\n------------Adding Patient------------");

            Console.Write("Enter patients name: ");
            string name = Console.ReadLine();

            Console.Write($"What is {name} surname: ");
            string surname = Console.ReadLine();

            Console.Write("What is the patient Priority Level(0-High, 1-Medium, 2-Moddest, 3-Low, 4-None): ");
            int priorityLevel;
            //Validating that user can only use numerical values
            while (!int.TryParse(Console.ReadLine(), out priorityLevel) || priorityLevel <0 || priorityLevel > 4)
            {
                Console.WriteLine("Invalide input (Enter 0-4)");
            }

            q3_Patient newPatient = new q3_Patient(name, surname, priorityLevel);

            //The 2nd mechanism for queueing patiner data when th enurse is manually adding patients
            myQueue.Enqueue(newPatient, priorityLevel);

            Console.WriteLine("\nPatient has been added successfully");

        }

        // 2) View next patient (peek, without removing)
        public static void ViewNextPatient()
        {

            Console.WriteLine("\n------------Viewing next Patient------------");

            if (myQueue.TryPeek(out var nextPatient, out var priorityLevel))
            {
                Console.WriteLine($"\nNext patient -> Name: {nextPatient.Name}, Name: {nextPatient.Surname},Priority Level: {nextPatient.PriorityLevel}");
            }
            else
            {
                Console.WriteLine("\nNo patients in queue.");
            }
        }

        // 3) Call (dequeue) next patient
        public static void CallNextPatient()
        {

            Console.WriteLine("\n------------Calling next Patient------------");

            //If there is a patient in the queue to be called, it with use the dequeuing mechanism to remove the currant patient
            if (myQueue.TryDequeue(out var nextPatient, out var priority))
            {
                Console.WriteLine($"\nCalling patient -> Name: {nextPatient.Name}, Surname: {nextPatient.Surname}, Priority Level: {nextPatient.PriorityLevel}");
            }
            else
            {
                Console.WriteLine("\nNo patients in queue.");
            }

            Console.WriteLine($"Number of patients left: {myQueue.Count}");

        }

        // 4) Display all patients in priority order WITHOUT removing them.
        // We clone the queue using UnorderedItems then dequeue from the clone to print in the priority order (patients with priority level 0 being the first patient and patients with priority level 4 being the last patinet).
        public static void DisplayAllPatients()
        {

            Console.WriteLine("\n------------Displaying all Patients------------");

            Console.WriteLine($"Total number of patients: {myQueue.Count}");

            if (myQueue.Count == 0)
            {
                Console.WriteLine("\nNo patients in queue.");
                return;
            }

            Console.WriteLine("\nPatients in priority order (highest severity first):");

            // Clone the queue from UnorderedItems (element + its stored priority)
            var clone = new PriorityQueue<q3_Patient, int>();
            foreach (var item in myQueue.UnorderedItems)
            {
                // item is (Element, Priority)
                clone.Enqueue(item.Element, item.Priority);
            }

            int i = 1;
            while (clone.Count > 0)
            {
                var patient = clone.Dequeue();
                Console.WriteLine($"{i++}. {patient.Name} {patient.Surname}, priority Level: {patient.PriorityLevel}");
            }
        }
    }
}
