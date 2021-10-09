using System;
using System.Collections.Generic;
using System.Linq;

namespace Dusza {
    class TaskFour {
        public List<Measure> Measures;

        public void Solve() {
            List<string> Plates = new List<string>();
            //goes through the input file and checks if the region is "H" and if the Plates list contains it
            for (int i = 0; i < Measures.Count(); i++) {
                if (!Plates.Contains(Measures[i].License) && Measures[i].Region == "H") {
                    Plates.Add(Measures[i].License);
                }
            }
            //the answer
            Console.WriteLine(Plates.Count());
        }
    }
}
