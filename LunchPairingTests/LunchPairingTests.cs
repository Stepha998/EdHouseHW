using System;
using System.Drawing;
using System.IO;
using EdHouseHW;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LunchPairingTests
{
    [TestClass]
    public class LunchPairingTests
    {
        private const string TestFilesPath = @"TestFiles\";

        private string GetTestFile(string file)
        {
            return TestFilesPath + file;
        }

        [TestMethod]
        public void ExampleFromAssignment()
        {
            var lunch = new LunchPairing(GetTestFile("ExampleFromAssignment.txt"));

            Assert.AreEqual(lunch.lunchSpot, new Point(1, 4));
        }

        [TestMethod]
        [ExpectedException(typeof(NoPlaceForLunchFoundException))]
        public void ExampleToTestFromAssignment()
        {
            new LunchPairing(GetTestFile("ExampleToTestFromAssignment.txt"));
        }

        [TestMethod]
        [ExpectedException(typeof(InputException))]
        public void NoLunchIntervalSpecified()
        {
            new LunchPairing(GetTestFile("NoLunchInterval.txt"));
        }

        [TestMethod]
        [ExpectedException(typeof(InputException))]
        public void OneDriverMissing()
        {
            new LunchPairing(GetTestFile("OneDriverMissing.txt"));
        }

        [TestMethod]
        [ExpectedException(typeof(InputException))]
        public void TypoInLunchInterval_firstPart()
        {
            new LunchPairing(GetTestFile("TypoInLunchInterval_firstPart.txt"));
        }
        [TestMethod]
        [ExpectedException(typeof(InputException))]
        public void TypoInLunchInterval_secondPart()
        {
            new LunchPairing(GetTestFile("TypoInLunchInterval_secondPart.txt"));
        }
        [TestMethod]
        [ExpectedException(typeof(InputException))]
        public void TypoInLunchInterval_missingDash()
        {
            new LunchPairing(GetTestFile("TypoInLunchInterval_missingDash.txt"));
        }

        [TestMethod]
        [ExpectedException(typeof(InputException))]
        public void ExtraSpaceInDirection()
        {
            new LunchPairing(GetTestFile("ExtraSpaceInDirection.txt"));
        }

        [TestMethod]
        [ExpectedException(typeof(InputException))]
        public void WrongCardDirectionChar()
        {
            new LunchPairing(GetTestFile("WrongCardDirectionChar.txt"));
        }

        [TestMethod]
        [ExpectedException(typeof(InputException))]
        public void ExtraEnter()
        {
            new LunchPairing(GetTestFile("ExtraEnter.txt"));
        }
    }
}