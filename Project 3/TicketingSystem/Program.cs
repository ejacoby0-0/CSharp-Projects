using System.Reflection.Emit;

namespace TicketingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Methods.AddPatientData();

            int option;

            Console.WriteLine("Welcome to the Ticketing System\n");

            do {

                Console.WriteLine("\n------------Main Menu------------");

                Console.WriteLine("1. Add patient to queue");
                Console.WriteLine("2. View Next patient in queue");
                Console.WriteLine("3. Call next patient in queue");
                Console.WriteLine("4. Display all the patients in the queue");
                Console.WriteLine("5. Exit");

                Console.Write("Choose the option (1-5): ");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Methods.AddPatient();
                        break;
                    case 2:
                        Methods.ViewNextPatient();
                        break;
                    case 3:
                        Methods.CallNextPatient();
                        break;
                    case 4:
                        Methods.DisplayAllPatients();
                        break;
                }

            } while (option != 5);

            Console.WriteLine("Thank you for using the Ticketing System");

        }
    }
}
