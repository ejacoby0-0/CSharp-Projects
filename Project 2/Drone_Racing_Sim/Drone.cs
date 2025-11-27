using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Racing_Sim
{
    //Defining the class of the drone to be used in other functions
    public class Drone
    {
        public string Name { get; set; }
        public int DistanceTraveled { get; set; }
        public int Speed { get; set; } // Distance covered per iteration

        public Drone(string name, int speed)
        {
            Name = name;
            DistanceTraveled = 0;
            Speed = speed;
        }

        public void Advance()
        {
            DistanceTraveled += Speed;
        }
    }

    public class Race
    {
        private int _trackLength;
        private List<Drone> _racers;

        public Race(int trackLength, List<Drone> racers)
        {
            _trackLength = trackLength;
            _racers = racers;
        }

        

        //Win function
        private void FindWinner()
        {
            var winner = _racers.OrderByDescending(r => r.DistanceTraveled).First();
            Console.WriteLine($"\n{winner.Name} wins the race!");
        }

        //Run function
        public void Run()
        {
            Console.WriteLine("Race begin... Drones must travel 25km!");
            int iteration = 0;

            while (!_racers.All(r => r.DistanceTraveled >= _trackLength))
            {
                iteration++;
                Console.WriteLine($"\nIteration {iteration}:");

                foreach (var racer in _racers)
                {
                    // Only advance racers who haven't finished yet
                    if (racer.DistanceTraveled < _trackLength)
                    {
                        racer.Advance();
                    }
                    Console.WriteLine($"{racer.Name}: {racer.DistanceTraveled} km");
                }

                Console.WriteLine("Press any key to advance to the next iteration.");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("\nRace complete!");
            FindWinner();

        }
    }
}
