using System;
using System.Collections.Generic;
using System.Linq;

namespace Dusza {
    class TaskSeven {
        public List<Measure> Measures;
        public int[] MeasureDistances;

        public bool ExceededSpeedLimit(string Type, double Speed) {
            // Compare different types with their speed limits
            switch (Type) {
                case "sz":
                    return Speed > 130;
                case "m":
                    return Speed > 130;
                case "b":
                    return Speed > 100;
                case "t":
                    return Speed > 80;
                default:
                    return false;  // mk is default
            }
        }

        public double AverageSpeed(DateTime[] Times) {
            // V = S/T
            // Calculate Average speed by Distance/Time
            return (this.MeasureDistances[2] - this.MeasureDistances[0]) / (Times[2] - Times[0]).TotalHours;
        }

        public string[] VehiclesAtAllPoints() {
            // Get vehicles that passed all 3 points
            var PassedAllPoints = this.Measures
                .Where(x => this.Measures
                .Count(y => y.License == x.License) == 3)
                .GroupBy(x => x.License);

            // Create string to be printed out
            return PassedAllPoints
                .Select(x => $"{ (ExceededSpeedLimit(x.ToArray()[0].Type, AverageSpeed(x.Select(y => y.Time).ToArray())) ? "nem" : "igen") } {x.ToArray()[0].Region} {x.Key}").ToArray();
        }

        public void Solve() {
            foreach (var item in VehiclesAtAllPoints())
                Console.WriteLine(item);

        }
    }
}
