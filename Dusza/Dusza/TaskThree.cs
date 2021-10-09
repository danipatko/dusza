using System;
using System.Collections.Generic;

namespace Dusza {
    class TaskThree {
        public List<Measure> Measures;

        private int FastestSpeed() {
            int n = int.MinValue;

            foreach (var Measure in Measures)
                if (Measure.Speed > n)
                    n = Measure.Speed;

            return n;
        }

        public string[] Solve() {
            int Fastest = FastestSpeed();
            List<string> sol = new List<string>();

            foreach (var Measure in Measures)
                if (Measure.ID == 'C' && Measure.Speed == Fastest) {
                    string str = $"{Measure.Speed} {(Shared.ExceededSpeedLimit(Measure) ? "túllépte" : "nem_lépte_túl")} {Measure.Type} {Measure.Region} {Measure.License} {Measure.Time.ToString("HH:mm:ss")}";
                    sol.Add(str);
                    Console.WriteLine(str);
                }

            return sol.ToArray();
        }
    }
}
