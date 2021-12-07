using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2021;
using AdventOfCode2021.Enums;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Results
{
    [TestClass]
    public class Exercices
    {
        public static string Session = "S3cr3t";

        [TestMethod]
        public void Exercice01_A()
        {
            IEnumerable<int> input = InputGetter.GetInputAsIntArray(Session, "2021/day/1/input");
            int nbr = SonarSweep.GetDepthIncrease(input);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(1446, nbr);
        }

        [TestMethod]
        public void Exercice01_B()
        {
            IEnumerable<int> input = InputGetter.GetInputAsIntArray(Session, "2021/day/1/input");
            int nbr = SonarSweep.GetDepthIncreaseWindow(input, 3);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(1486, nbr);
        }

        [TestMethod]
        public void Exercice02_A()
        {
            IEnumerable<(Direction, int)> input = InputGetter.GetInputAsEnumTuples<Direction>(Session, "2021/day/2/input");
            int nbr = SubmarineGPS.ComputeDistance(input);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(1698735, nbr);
        }
        
        [TestMethod]
        public void Exercice02_B()
        {
            IEnumerable<(Direction, int)> input = InputGetter.GetInputAsEnumTuples<Direction>(Session, "2021/day/2/input");
            int nbr = SubmarineGPS.ComputeDistanceAim(input);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(1594785890, nbr);
        }

        [TestMethod]
        public void Exercice03_A()
        {
            IEnumerable<char[]> input = InputGetter.GetInputAsCharArrayEnumerable(Session, "2021/day/3/input");
            long nbr = PowerConsumptionUnit.ComputeConsumption(input);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(3813416, nbr);
        }


        [TestMethod]
        public void Exercice03_B()
        {
            IEnumerable<char[]> input = InputGetter.GetInputAsCharArrayEnumerable(Session, "2021/day/3/input");
            int nbr = PowerConsumptionUnit.ComputeAirValues(input);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(2990784, nbr);
        }

        [TestMethod]
        public void Exercice04_A()
        {
            IEnumerable<string> inputs = InputGetter.Multiparse(Session, "2021/day/4/input", "\n\n");
            IEnumerable<int> numbers = InputGetter.ParseNumberList(inputs.ElementAt(0));
            IEnumerable<string> grids = InputGetter.ParseToken(inputs.ElementAt(1).TrimEnd(), "\n\n");
            int nbr = BingoGrid.PlayBingo(grids, numbers);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(38594, nbr);
        }


        [TestMethod]
        public void Exercice04_B()
        {
            IEnumerable<string> inputs = InputGetter.Multiparse(Session, "2021/day/4/input", "\n\n");
            IEnumerable<int> numbers = InputGetter.ParseNumberList(inputs.ElementAt(0));
            IEnumerable<string> grids = InputGetter.ParseToken(inputs.ElementAt(1).TrimEnd(), "\n\n");
            int nbr = BingoGrid.PlayBingoLonger(grids, numbers);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(21184, nbr);
        }

        [TestMethod]
        public void Exercice05_A()
        {
            IEnumerable<(Coordinates a, Coordinates b)> inputs = InputGetter.GetCoordinateRanges(Session, "2021/day/5/input");
            HydroThermalVentsAnalyzer analyzer = new HydroThermalVentsAnalyzer(inputs);

            int nbr = analyzer.GetOverlapingPoints();

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(4873, nbr);
        }


        [TestMethod]
        public void Exercice05_B()
        {
            IEnumerable<(Coordinates a, Coordinates b)> inputs = InputGetter.GetCoordinateRanges(Session, "2021/day/5/input");
            HydroThermalVentsAnalyzer analyzer = new HydroThermalVentsAnalyzer(inputs);

            int nbr = analyzer.GetOverlapingPoints(diagonal: true);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(19472, nbr);
        }

        [TestMethod]
        public void Exercice06_A()
        {
            IEnumerable<int> inputs = InputGetter.GetInputAndTreat(Session, "2021/day/6/input", InputGetter.ParseNumberList);
            long nbr = LanternFishComputer.ComputeStateAfterOptimized(inputs, 80);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(352195, nbr);
        }


        [TestMethod]
        public void Exercice06_B()
        {
            IEnumerable<int> inputs = InputGetter.GetInputAndTreat(Session, "2021/day/6/input", InputGetter.ParseNumberList);
            long nbr = LanternFishComputer.ComputeStateAfterOptimized(inputs, 256);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(1600306001288, nbr);
        }

        [TestMethod]
        public void Exercice07_A()
        {
            IEnumerable<int> inputs = InputGetter.GetInputAndTreat(Session, "2021/day/7/input", InputGetter.ParseNumberList);
            (int position, int fuel) nbr = CrabComputing.ComputeClosestPosition(inputs, CrabComputing.GetDistance);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr.position} {nbr.fuel}", OutputLevel.Information);
            Assert.AreEqual(342, nbr.position);
            Assert.AreEqual(325528, nbr.fuel);
        }


        [TestMethod]
        public void Exercice07_B()
        {
            IEnumerable<int> inputs = InputGetter.GetInputAndTreat(Session, "2021/day/7/input", InputGetter.ParseNumberList);
            (int position, int fuel) nbr = CrabComputing.ComputeClosestPosition(inputs, CrabComputing.GetDistanceInc);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr.position} {nbr.fuel}", OutputLevel.Information);
            Assert.AreEqual(460, nbr.position);
            Assert.AreEqual(85015836, nbr.fuel);
        }
    }
}
