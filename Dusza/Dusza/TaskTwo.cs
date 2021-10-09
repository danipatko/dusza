using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dusza {
    class TaskTwo {
        public List<Measure> Measures;

        // contains all the relevant speed limits
        enum SpeedLimits : int {
            sz = 130, m = 130, b = 100, t = 80
        }

        public bool ExceededSpeedLimit(Measure _Measure) {
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

        public int ExceedSpeedLimitBy(Measure _Measure) {
            switch (_Measure.Type) {
                case "sz":
                    return _Measure.Speed - (int)SpeedLimits.sz;
                case "m":
                    return _Measure.Speed - (int)SpeedLimits.m;
                case "b":
                    return _Measure.Speed - (int)SpeedLimits.b;
                case "t":
                    return _Measure.Speed - (int)SpeedLimits.t;
                default:
                    return 0;
            }
        }

        public void Solve() {
            string sol = "";

            foreach (var Measure in Measures)
                if (Measure.ID == 'B' && ExceededSpeedLimit(Measure))
                    sol += $"{Measure.Type} {Measure.Region} {Measure.License} {ExceedSpeedLimitBy(Measure)}" + Environment.NewLine;

            sol = sol.Trim();

            Console.WriteLine(sol);
            File.WriteAllText("TaskTwo.txt", sol);
        }
    }
}
