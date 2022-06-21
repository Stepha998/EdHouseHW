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
        // expect directory with files for testing in the same directory as exe file of tests
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
        public void TypoInLunchInterval_start()
        {
            new LunchPairing(GetTestFile("TypoInLunchInterval_start.txt"));
        }
        [TestMethod]
        [ExpectedException(typeof(InputException))]
        public void TypoInLunchInterval_end()
        {
            new LunchPairing(GetTestFile("TypoInLunchInterval_end.txt"));
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

        [TestMethod]
        [ExpectedException(typeof(InputException))]
        public void NegativeLunchIntervalStart()
        {
            new LunchPairing(GetTestFile("NegativeLunchIntervalStart.txt"));
        }

        [TestMethod]
        public void ZeroLunchIntervalStart()
        {
            new LunchPairing(GetTestFile("ZeroLunchIntervalStart.txt"));
        }

        [TestMethod]
        public void LunchIntervalEndLongerThanDriversShift()
        {
            new LunchPairing(GetTestFile("LunchIntervalEndLongerThanDriversShift.txt"));
        }

        [TestMethod]
        [ExpectedException(typeof(NoPlaceForLunchFoundException))]
        public void LunchIntervalStartAfterDriversShiftEnd()
        {
            new LunchPairing(GetTestFile("LunchIntervalStartAfterDriversShiftEnd.txt"));
        }

        [TestMethod]
        [ExpectedException(typeof(InputException))]
        public void EmptyFile()
        {
            new LunchPairing(GetTestFile("EmptyFile.txt"));
        }

        [TestMethod]
        [ExpectedException(typeof(InputException))]
        public void OnlyNewLines()
        {
            new LunchPairing(GetTestFile("OnlyNewLines.txt"));
        }

        [TestMethod]
        public void LunchSpotOnLunchIntervalStart()
        {
            var lunch = new LunchPairing(GetTestFile("LunchSpotOnLunchIntervalStart.txt"));

            Assert.AreEqual(lunch.lunchSpot, new Point(1, 0));
        }

        [TestMethod]
        public void LunchSpotOnLunchIntervalEnd()
        {
            var lunch = new LunchPairing(GetTestFile("LunchSpotOnLunchIntervalEnd.txt"));

            Assert.AreEqual(lunch.lunchSpot, new Point(1, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(InputException))]
        public void AcceptCapitalLettersOnlyAsCardDirections()
        {
            new LunchPairing(GetTestFile("ExpectOnlyCapitalLettersAsCardDirections.txt"));
        }

        [TestMethod]
        [ExpectedException(typeof(InputException))]
        public void AcceptPositiveNumbersOnlyAsNumericalDirections()
        {
            new LunchPairing(GetTestFile("AcceptPositiveNumbersOnlyAsNumericalDirections.txt"));
        }
    }
}