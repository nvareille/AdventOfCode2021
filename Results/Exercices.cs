using System.Collections.Generic;
using AdventOfCode2021;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Results
{
    [TestClass]
    public class Exercices
    {
        public static string Session = "S3cr3t";

        [TestMethod]
        public void Exercice1_A()
        {
            IEnumerable<int> input = InputGetter.GetInputAsIntArray(Session, "2021/day/1/input");
            int nbr = SonarSweep.GetDepthIncrease(input);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
        }

        [TestMethod]
        public void Exercice1_B()
        {
            IEnumerable<int> input = InputGetter.GetInputAsIntArray(Session, "2021/day/1/input");
            int nbr = SonarSweep.GetDepthIncreaseWindow(input, 3);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
        }
    }
}
