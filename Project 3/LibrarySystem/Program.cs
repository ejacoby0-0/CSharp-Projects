using static LibrarySystem.Methods; // Makes use that you can call the methods from a different file

namespace LibrarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SampleBooks();

            int option;

            do 
            {

                Console.WriteLine("\nWelcome to the library system");

                Console.WriteLine("1. Print title of book in-order");
                Console.WriteLine("2. Search book by year");
                Console.WriteLine("3. Display the most recent book");
                Console.WriteLine("4. Display the number of books");
                Console.WriteLine("5. Exit");

                Console.Write("\nChoice the option (1-5): ");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        q2_InOrderDisplay();
                        break;
                    case 2:
                        q2_SearchByYear();
                        break;
                    case 3:
                        q2_MostRecentBookDisplay();
                        break;
                    case 4:
                        q2_NumberOfBooksDisplayed();
                        break;

                }

            } while (option != 5);

            Console.WriteLine("\nThank you for using the library system\n");

        }
    }
}
