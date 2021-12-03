using System.Collections.Generic;
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
        }

        [TestMethod]
        public void Exercice01_B()
        {
            IEnumerable<int> input = InputGetter.GetInputAsIntArray(Session, "2021/day/1/input");
            int nbr = SonarSweep.GetDepthIncreaseWindow(input, 3);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
        }

        [TestMethod]
        public void Exercice02_A()
        {
            IEnumerable<(Direction, int)> input = InputGetter.GetInputAsEnumTuples<Direction>(Session, "2021/day/2/input");
            int nbr = SubmarineGPS.ComputeDistance(input);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
        }


        [TestMethod]
        public void Exercice02_B()
        {
            IEnumerable<(Direction, int)> input = InputGetter.GetInputAsEnumTuples<Direction>(Session, "2021/day/2/input");
            int nbr = SubmarineGPS.ComputeDistanceAim(input);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
        }

        [TestMethod]
        public void Exercice03_A()
        {
            IEnumerable<char[]> input = InputGetter.GetInputAsCharArrayEnumerable(Session, "2021/day/3/input");
            long nbr = PowerConsumptionUnit.ComputeConsumption(input);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
        }


        [TestMethod]
        public void Exercice03_B()
        {
            IEnumerable<char[]> input = InputGetter.GetInputAsCharArrayEnumerable(Session, "2021/day/3/input");
            ulong nbr = PowerConsumptionUnit.ComputeAirValues(input);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
        }
    }
}
