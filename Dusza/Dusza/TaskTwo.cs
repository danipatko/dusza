using System;
using System.Collections.Generic;

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

        public string[] Solve() {
            List<string> sol = new List<string>();

            foreach (var Measure in Measures)
                if (Measure.ID == 'B' && Shared.ExceededSpeedLimit(Measure)) {
                    string str = $"{Measure.Type} {Measure.Region} {Measure.License} {ExceedSpeedLimitBy(Measure)}";
                    sol.Add(str);
                    Console.WriteLine(str);
                }

            return sol.ToArray();
        }
    }
}
