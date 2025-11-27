namespace Drone_Racing_Sim
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the drone racing simulation!");

            //Random distance that the drone travel
            Random random = new Random();

            int num1 = random.Next(1, 7); // 
            int num2 = random.Next(1, 7); //
            int num3 = random.Next(1, 7); //  Generates a random number between 1 and 6 
            int num4 = random.Next(1, 7); //
            int num5 = random.Next(1, 7); //

            // Drones
            var racers = new List<Drone>
            {
                new Drone("Drone 1", num1),
                new Drone("Drone 2", num2),
                new Drone("Drone 3", num3),
                new Drone("Drone 4", num4),
                new Drone("Drone 5", num5)
            };

            // Define the distance
            int distance = 25;

            // Create and run the race
            Race race = new Race(distance, racers);
            race.Run();

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();



        }
    }
}
