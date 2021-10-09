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

        public void Solve() {
            int Fastest = FastestSpeed();
            string sol = "";

            foreach (var Measure in Measures)
                if (Measure.ID == 'C' && Measure.Speed == Fastest)
                    sol += $"{Measure.Speed} {(Shared.ExceededSpeedLimit(Measure) ? "túllépte" : "nem_lépte_túl")} {Measure.Type} {Measure.Region} {Measure.License} {Measure.Time.ToString("HH:mm:ss")}" + Environment.NewLine;


            sol = sol.Trim();

            Console.WriteLine(sol);
        }
    }
}
