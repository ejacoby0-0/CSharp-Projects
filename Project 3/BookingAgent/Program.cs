using System.Text.Json; //Inializes the JSON file
using System.Text.Json.Serialization;

namespace BookingAgent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Initalizing the array with the apperiate values
            q4_Hotel[] hotel =
            {
                new q4_Hotel(0, "Hotel Cape Town", 1500, 4, 15),
                new q4_Hotel(4, "Hotel America", 2000, 3, 1000),
                new q4_Hotel(5, "Hotel China", 500, 5, 5),
                new q4_Hotel(3, "Hotel Japan", 47, 2, 309),
                new q4_Hotel(9, "Hotel Erupe", 560, 4, 78),
                new q4_Hotel(2, "Hotel Russia", 192, 4, 15),
            };

            Console.WriteLine("Initial List:");
            DisplayHotel(hotel);

            QuickSortByViews(hotel, 0, hotel.Length -1);

            Console.WriteLine("\nPost Quick Sort:");
            DisplayHotel(hotel);

            //Declaring the file name where the data is going to be stored
            var fileName = "Hotel.json";

            //Initializinf the JSON to serialized the hotel class
            var jsonString = JsonSerializer.Serialize(hotel);

            //writing the data in the json string to the json file
            File.WriteAllText(fileName, jsonString);

            //Displaying the output in JSON formate
            Console.WriteLine(jsonString);

            Console.WriteLine("\nThe JSON file has been created successfully");
        }


        //Quick Sort algorithm method
        static void QuickSortByViews(q4_Hotel[] hotel, int low, int high)
        {
            if (low < high)
            {
                //Calling the partition method
                int pi = Partition(hotel, low, high);

                // Recursively sort elements before and after partition
                QuickSortByViews(hotel, low, pi - 1);
                QuickSortByViews(hotel, pi + 1, high);
            }
        }



        //Partion method, rearanges the array so that all elements with keys less than the pivot go to the left, and all elements with keys
        //greater than the pivot go to the right, then returns the final index of the pivot. QuickSort then recursively sorts the left and right segments around that pivot.
        static int Partition(q4_Hotel[] hotel, int low, int high)
        {
            //Sorts the array by nightley rates (Cheapest is sorted fist and increments to the most expensive nightly rates)
            double pivot = hotel[high].Nightly_Rate; // pivot
            int i = low - 1; // Index of smaller element

            for (int j = low; j <= high - 1; j++)
            {
                if (hotel[j].Nightly_Rate < pivot)
                {
                    i++;
                    // Swap hotel[i] and hotel[j]
                    q4_Hotel temp = hotel[i];
                    hotel[i] = hotel[j];
                    hotel[j] = temp;
                }
            }

            // Swap videos[i + 1] and hotel[high] (pivot)
            q4_Hotel temp2 = hotel[i + 1];
            hotel[i + 1] = hotel[high];
            hotel[high] = temp2;

            return i + 1;
        }


        //Displays the hotel details
        static void DisplayHotel(q4_Hotel[] hotel)
        {

            foreach (var hotels in hotel)
            {
                Console.WriteLine($"ID: {hotels.Id}, Name: {hotels.Name}, Nightly Rate: {hotels.Nightly_Rate}, Stars: {hotels.Stars}, Distance from airport: {hotels.Distance_From_Airport}");
            }


        }


        //Declaring the hotel class with the apperiate propertises
        public class q4_Hotel
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public double Nightly_Rate { get; set; }

            public int Stars { get; set; }

            public int Distance_From_Airport { get; set; }

            public q4_Hotel(int id, string name, double nightly_Rate, int stars, int distance_From_Airport)
            {
                Id = id;
                Name = name;
                Nightly_Rate = nightly_Rate;
                Stars = stars;
                Distance_From_Airport = distance_From_Airport;
            }

        }
    }
}
