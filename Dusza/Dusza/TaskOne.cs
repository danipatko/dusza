using System;
using System.Collections.Generic;
using System.IO;

namespace Dusza {
    class TaskOne {
        public List<Measure> Measures;

        public string[] Solve() {
            int n = 0;

            foreach (var Measure in Measures)
                if (Measure.Type == "m" && Measure.Speed > 130)
                    n++;

            Console.WriteLine(n);
            File.WriteAllText("TaskOne.txt", $"{n}");
            return new string[] { n.ToString() };
        }
    }
}
