using System;
using System.Collections.Generic;
using Xunit;
using LoggingKata;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        // We have a non-null value for parsing Long, Latt; which can be used when the parser returns 'null'
        const double INVALID = 360.0;   // Allowable values: -180 < Longitude < 180; 0 < Lattitude < 180

        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData(", -84.677017, Taco Bell Acwort...", INVALID)]
        [InlineData("34.073638,, Taco Bell Acwort...", INVALID)]
        [InlineData("34.073638, -84.677017,", INVALID)]
        [InlineData("34.073638, -84.677017", INVALID)]
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
            var tb = new TacoParser();

            //Act
            var actual = tb.Parse(line);
            if (actual == null)
            {
                actual = new TacoBell();
                Point pnt = new Point();
                pnt.Longitude = INVALID;
                actual.Location = pnt;
            }

            //Assert
            Assert.Equal(actual.Location.Longitude, expected);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData(", -84.677017, Taco Bell Acwort...", INVALID)]
        [InlineData("34.073638,, Taco Bell Acwort...", INVALID)]
        [InlineData("34.073638, -84.677017,", INVALID)]
        [InlineData("34.073638, -84.677017", INVALID)]
        public void ShouldParseLatitude(string line, double expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
            var tb = new TacoParser();

            //Act
            var actual = tb.Parse(line);
            if (actual == null)
            {
                actual = new TacoBell();
                Point pnt = new Point();
                pnt.Latitude = INVALID;
                actual.Location = pnt;
            }

            //Assert
            Assert.Equal(actual.Location.Latitude, expected);
        }
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", " Taco Bell Acwort...")]
        [InlineData(", -84.677017, Taco Bell Acwort...", "INVALID")]
        [InlineData("34.073638,, Taco Bell Acwort...", "INVALID")]
        [InlineData("34.073638, -84.677017,", "INVALID")]
        [InlineData("34.073638, -84.677017", "INVALID")]
        public void ShouldParseName(string line, string expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
            var tb = new TacoParser();

            //Act
            var actual = tb.Parse(line);
            if(actual == null)
            {
                actual = new TacoBell();
                actual.Name = "INVALID";
            }

            //Assert
            Assert.Equal(actual.Name, expected);
        }



    }
}
