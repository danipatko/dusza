using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Dusza {
    class Shared {
        // contains all the relevant speed limits
        public enum SpeedLimits : int {
            sz = 130, m = 130, b = 100, t = 80
        }

        public static bool ExceededSpeedLimit(Measure _Measure) {
            // Compare different types with their speed limits
            switch (_Measure.Type) {
                case "sz":
                    return _Measure.Speed > (int)SpeedLimits.sz;
                case "m":
                    return _Measure.Speed > (int)SpeedLimits.m;
                case "b":
                    return _Measure.Speed > (int)SpeedLimits.b;
                case "t":
                    return _Measure.Speed > (int)SpeedLimits.t;
                default:
                    return false;  // mk is default
            }
        }
    }

    class Measure {
        public string Region;
        public string License;
        public char ID;
        public string Type;
        public int Speed;
        public DateTime Time;
    }

    class Program {
        static void PrintMeasures(List<Measure> Measures) {
            for (int i = 0; i < Measures.Count; i++) {
                Console.WriteLine($"Region:{Measures[i].Region} License:{Measures[i].License} ID:{Measures[i].ID} Type:{Measures[i].Type} Speed:{Measures[i].Speed} Time:{Measures[i].Time} ");
            }
        }

        static void Main(string[] args) {
            // Read file contents and split then into lines
            string[] FileContents = File.ReadAllLines("D22.txt");
            int[] Distances = FileContents[0].Split(',').Select(x => int.Parse(x)).ToArray();

            // Convert lines to Measure objects and add them to the Measures list
            List<Measure> Measures = new List<Measure>();
            string[] Line;
            for (int i = 1; i < FileContents.Length; i++) {
                Line = FileContents[i].Split(',');
                Measures.Add(new Measure {
                    Region = Line[0],
                    License = Line[1],
                    ID = Line[2][0],
                    Type = Line[3],
                    Speed = int.Parse(Line[4]),
                    Time = DateTime.ParseExact(Line[5], "hh:mm:ss", CultureInfo.InvariantCulture)
                });
            }

            // print shit
            PrintMeasures(Measures);
            Console.WriteLine();

            // Tasks
            new TaskOne { Measures = Measures }.Solve();
            new TaskTwo { Measures = Measures }.Solve();
            new TaskThree { Measures = Measures }.Solve();
            new TaskFour { Measures = Measures }.Solve();
            new TaskFive { Measures = Measures }.Solve();
            new TaskSix { Measures = Measures }.Solve(Distances);
            new TaskSeven { Measures = Measures, MeasureDistances = Distances }.Solve();
            new TaskEight { Measures = Measures }.Solve();
            new TaskNine { Measures = Measures }.Solve();

            Console.ReadKey();
        }
    }
}
