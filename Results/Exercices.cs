using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2021;
using AdventOfCode2021.Containers;
using AdventOfCode2021.Enums;
using AdventOfCode2021.Extensions;
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

        [TestMethod]
        public void Exercice08_A()
        {
            IEnumerable<(string[], string[])> inputs = InputGetter.GetDelimitedStringArray(Session, "2021/day/8/input");
            int nbr = WireSegments.FindMatchingSimpleWires(inputs);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(237, nbr);
        }


        [TestMethod]
        public void Exercice08_B()
        {
            IEnumerable<(string[], string[])> inputs = InputGetter.GetDelimitedStringArray(Session, "2021/day/8/input");
            int nbr = WireSegments.FindComplexMatchingWires(inputs);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(1009098, nbr);
        }

        [TestMethod]
        public void Exercice09_A()
        {
            int[][] input = InputGetter.GetAsIntArraySingleDigit(Session, "2021/day/9/input");
            int nbr = SmokeBasin.ComputeRiskLevel(input);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(539, nbr);
        }


        [TestMethod]
        public void Exercice09_B()
        {
            int[][] input = InputGetter.GetAsIntArraySingleDigit(Session, "2021/day/9/input");
            IEnumerable<int> value = SmokeBasin.FindBasins(input);
            int nbr = value.OrderByDescending(i => i)
                .Take(3)
                .Aggregate((a, b) => a * b);


            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(736920, nbr);
        }

        [TestMethod]
        public void Exercice10_A()
        {
            string[] input = InputGetter.GetAsStringArray(Session, "2021/day/10/input");
            long nbr = SyntaxChecker.ComputeScoreErrors(input);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(374061, nbr);
        }

        [TestMethod]
        public void Exercice10_B()
        {
            string[] input = InputGetter.GetAsStringArray(Session, "2021/day/10/input");
            long nbr = SyntaxChecker.ComputeAutocompleteScore(input);

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(2116639949, nbr);
        }

        [TestMethod]
        public void Exercice11_A()
        {
            int[][] input = InputGetter.GetAsIntArraySingleDigit(Session, "2021/day/11/input");
            OctopusFlashAnalyzer analyzer = new OctopusFlashAnalyzer(input);
            int nbr = analyzer.ComputeFlashSteps(100); 

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(1757, nbr);
        }

        [TestMethod]
        public void Exercice11_B()
        {
            int[][] input = InputGetter.GetAsIntArraySingleDigit(Session, "2021/day/11/input");
            OctopusFlashAnalyzer analyzer = new OctopusFlashAnalyzer(input);
            int nbr = analyzer.ComputeSynchroneFlashSteps();

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(422, nbr);
        }

        [TestMethod]
        public void Exercice12_A()
        {
            IEnumerable<(string, string)> input = InputGetter.GetInputAndTreat(Session, "2021/day/12/input", i => i.Split("\n")
                    .Where(o => !string.IsNullOrWhiteSpace(o))
                    .Select(o => o.Split("-")
                        .Then(e => (e[0], e[1]))))
                .ToArray();
            CavePathAnalyzer analyzer = new CavePathAnalyzer(input);
            int nbr = analyzer.AnalyzePaths();
            
            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(5457, nbr);
        }

        [TestMethod]
        public void Exercice12_B()
        {
            IEnumerable<(string, string)> input = InputGetter.GetInputAndTreat(Session, "2021/day/12/input", i => i
                    .Split("\n")
                    .Where(o => !string.IsNullOrWhiteSpace(o))
                    .Select(o => o.Split("-")
                        .Then(e => (e[0], e[1]))))
                .ToArray();


            CavePathAnalyzer analyzer = new CavePathAnalyzer(input, true);
            int nbr = analyzer.AnalyzePaths();

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(128506, nbr);
        }

        [TestMethod]
        public void Exercice13_Example()
        {
            string data =
                "6,10\r\n0,14\r\n9,10\r\n0,3\r\n10,4\r\n4,11\r\n6,0\r\n6,12\r\n4,1\r\n0,13\r\n10,12\r\n3,4\r\n3,0\r\n8,4\r\n1,10\r\n2,14\r\n8,10\r\n9,0\r\n\r\nfold along y=7\r\nfold along x=5";

            (IEnumerable<(int, int)>, IEnumerable<(char, int)>) input = InputGetter.GetInputAndTreat(Session, "2021/day/13/input", i => data.Split("\r\n\r\n")
                .Where(o => !string.IsNullOrWhiteSpace(o))
                .Then(o => 
                (
                    o.First()
                        .Split("\r\n")
                        .Select(e => e.Split(",")
                            .Then(a => (int.Parse(a[0]), int.Parse(a[1])))),
                    o.Last()
                        .Split("\r\n")
                        .Where(e => !string.IsNullOrWhiteSpace(e))
                        .Select(e => e.Substring(e.IndexOf("=") - 1)
                            .Split("=")
                            .Then(a => (a[0][0], int.Parse(a[1]))))
                )));

            OrigamiEngine origami = new OrigamiEngine(input);

            origami.Debug(c => ConsoleOutput.Instance.Write(c, OutputLevel.Information),
                () => ConsoleOutput.Instance.WriteLine("", OutputLevel.Information));

            ConsoleOutput.Instance.WriteLine("------------------------", OutputLevel.Information);

            origami.FoldOnce();

            origami.Debug(c => ConsoleOutput.Instance.Write(c, OutputLevel.Information),
                () => ConsoleOutput.Instance.WriteLine("", OutputLevel.Information));

            ConsoleOutput.Instance.WriteLine("------------------------", OutputLevel.Information);

            int nbr = origami.GetDots();
            
            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(17, nbr);
        }

        [TestMethod]
        public void Exercice13_A()
        {
            (IEnumerable<(int, int)>, IEnumerable<(char, int)>) input = InputGetter.GetInputAndTreat(Session, "2021/day/13/input", i => i.Split("\n\n")
                .Where(o => !string.IsNullOrWhiteSpace(o))
                .Then(o =>
                (
                    o.First()
                        .Split("\n")
                        .Select(e => e.Split(",")
                            .Then(a => (int.Parse(a[0]), int.Parse(a[1])))),
                    o.Last()
                        .Split("\n")
                        .Where(e => !string.IsNullOrWhiteSpace(e))
                        .Select(e => e.Substring(e.IndexOf("=") - 1)
                            .Split("=")
                            .Then(a => (a[0][0], int.Parse(a[1]))))
                )));

            OrigamiEngine origami = new OrigamiEngine(input);

            origami.FoldOnce();

            int nbr = origami.GetDots();

            ConsoleOutput.Instance.WriteLine($"Result is {nbr}", OutputLevel.Information);
            Assert.AreEqual(753, nbr);
        }

        [TestMethod]
        public void Exercice13_B()
        {
            (IEnumerable<(int, int)>, IEnumerable<(char, int)>) input = InputGetter.GetInputAndTreat(Session, "2021/day/13/input", i => i.Split("\n\n")
                .Where(o => !string.IsNullOrWhiteSpace(o))
                .Then(o =>
                (
                    o.First()
                        .Split("\n")
                        .Select(e => e.Split(",")
                            .Then(a => (int.Parse(a[0]), int.Parse(a[1])))),
                    o.Last()
                        .Split("\n")
                        .Where(e => !string.IsNullOrWhiteSpace(e))
                        .Select(e => e.Substring(e.IndexOf("=") - 1)
                            .Split("=")
                            .Then(a => (a[0][0], int.Parse(a[1]))))
                )));

            OrigamiEngine origami = new OrigamiEngine(input);

            origami.Fold();
            origami.Debug(c => ConsoleOutput.Instance.Write(c, OutputLevel.Information),
                () => ConsoleOutput.Instance.WriteLine("", OutputLevel.Information));
        }

        [TestMethod]
        public void Exercice14_Example()
        {
            string data =
                "NNCB\r\n\r\nCH -> B\r\nHH -> N\r\nCB -> H\r\nNH -> C\r\nHB -> C\r\nHC -> B\r\nHN -> C\r\nNN -> C\r\nBH -> H\r\nNC -> B\r\nNB -> B\r\nBN -> B\r\nBB -> N\r\nBC -> B\r\nCC -> N\r\nCN -> C";

            (string, Dictionary<string, char>) input = InputGetter.GetInputAndTreat(Session, "2021/day/14/input", i => data.Split("\r\n\r\n")
                .Where(o => !string.IsNullOrWhiteSpace(o))
                .ToArray()
                .Then(o =>
                (
                    o.First(),
                    o.Last()
                        .Split("\r\n")
                        .Where(e => !string.IsNullOrWhiteSpace(e))
                        .Select(e => e.Split(" -> ")
                            .Then(a => (a.First(), a.Last().First())))
                        .ToDictionary()
                )));

            long nbr = Polymerizer.PolymerizeOpti(input.Item1, input.Item2, 10);
            
            Logger.WriteLine($"Result is {nbr}");
            Assert.AreEqual(1588, nbr);
        }

        [TestMethod]
        public void Exercice14_A()
        {
            (string, Dictionary<string, char>) input = InputGetter.GetInputAndTreat(Session, "2021/day/14/input", i => i.Split("\n\n")
                .Where(o => !string.IsNullOrWhiteSpace(o))
                .ToArray()
                .Then(o =>
                (
                    o.First(),
                    o.Last()
                        .Split("\n")
                        .Where(e => !string.IsNullOrWhiteSpace(e))
                        .Select(e => e.Split(" -> ")
                            .Then(a => (a.First(), a.Last().First())))
                        .ToDictionary()
                )));


            long nbr = Polymerizer.PolymerizeOpti(input.Item1, input.Item2, 10);

            Logger.WriteLine($"Result is {nbr}");
            Assert.AreEqual(3831, nbr);
        }

        [TestMethod]
        public void Exercice14_B()
        {
            (string, Dictionary<string, char>) input = InputGetter.GetInputAndTreat(Session, "2021/day/14/input", i => i.Split("\n\n")
                .Where(o => !string.IsNullOrWhiteSpace(o))
                .ToArray()
                .Then(o =>
                (
                    o.First(),
                    o.Last()
                        .Split("\n")
                        .Where(e => !string.IsNullOrWhiteSpace(e))
                        .Select(e => e.Split(" -> ")
                            .Then(a => (a.First(), a.Last().First())))
                        .ToDictionary()
                )));


            long nbr = Polymerizer.PolymerizeOpti(input.Item1, input.Item2, 40);

            Logger.WriteLine($"Result is {nbr}");
            Assert.AreEqual(5725739914282, nbr);
        }

        [TestMethod]
        public void Exercice15_A()
        {
            int[][] input = InputGetter.GetAsIntArraySingleDigit(Session, "2021/day/15/input");
            ChitonCave analyzer = new ChitonCave(input);

            int nbr = analyzer.GetPathDifficulty();

            Logger.WriteLine($"Result is {nbr}");
            Assert.AreEqual(3831, nbr);
        }
    }
}
