﻿using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            if (lines == null || lines.Length == 0)
            {
                logger.LogError("File has no records");
                return;
            }

            if (lines.Length == 1)
            {
                logger.LogWarning("File has only 1 record");
                logger.LogInfo($"Lines: {lines[0]}");
            }


            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance
            var track1 = new TacoBell();
            var pnt1 = new Point();
            var track2 = new TacoBell();
            var pnt2 = new Point();
            double distance = 0;
            double tempDistance = 0;

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            var locA = new GeoCoordinate();
            var locB = new GeoCoordinate();
            logger.LogInfo("Begin searching for furthest distance between Taco Bell stores, starting with 0 miles");
            for (int i = 0; i < locations.Length - 1; i++)
            {
                if(locations[i] == null)
                {
                    logger.LogWarning("null record detected, skipping");
                    continue;
                }
                locA.Latitude = locations[i].Location.Latitude;
                locA.Longitude = locations[i].Location.Longitude;

                for (int j = i + 1; j < locations.Length; j++)
                {
                    locB.Latitude = locations[j].Location.Latitude;
                    locB.Longitude = locations[j].Location.Longitude;

                    tempDistance = locA.GetDistanceTo(locB);
//                    logger.LogInfo($"checking {locations[i].Name} to {locations[j].Name} miles apart: {Math.Round(tempDistance * 0.000621371, 0)}");

                    if(tempDistance > distance)
                    {
                        logger.LogInfo($"Found longer distance, updating {locations[i].Name} to {locations[j].Name} miles apart: {Math.Round(tempDistance * 0.000621371, 0)}");

                        distance = tempDistance;

                        track1.Name = locations[i].Name;
                        pnt1.Latitude = locations[i].Location.Latitude;
                        pnt1.Longitude = locations[i].Location.Longitude;
                        track1.Location = pnt1;

                        track2.Name = locations[j].Name;
                        pnt2.Latitude = locations[j].Location.Latitude;
                        pnt2.Longitude = locations[j].Location.Longitude;
                        track2.Location = pnt2;
                    }
                }
            }
            logger.LogInfo($"The two farthest Taco Bell stores are in {track1.Name} and {track2.Name} and are {Math.Round(distance * 0.000621371, 0)} miles apart");

            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.


            
        }
    }
}
