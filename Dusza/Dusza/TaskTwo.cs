using System;
using System.Collections.Generic;
using System.IO;

namespace Dusza {
    class TaskTwo {
        public List<Measure> Measures;

        public int ExceedSpeedLimitBy(Measure _Measure) {
            switch (_Measure.Type) {
                case "sz":
                    return _Measure.Speed - (int)Shared.SpeedLimits.sz;
                case "m":
                    return _Measure.Speed - (int)Shared.SpeedLimits.m;
                case "b":
                    return _Measure.Speed - (int)Shared.SpeedLimits.b;
                case "t":
                    return _Measure.Speed - (int)Shared.SpeedLimits.t;
                default:
                    return 0;
            }
        }

        public void Solve() {
            string sol = "";

            foreach (var Measure in Measures)
                if (Measure.ID == 'B' && Shared.ExceededSpeedLimit(Measure))
                    sol += $"{Measure.Type} {Measure.Region} {Measure.License} {ExceedSpeedLimitBy(Measure)}" + Environment.NewLine;

            sol = sol.Trim();

            Console.WriteLine(sol);
            File.WriteAllText("TaskTwo.txt", sol);
        }
    }
}
