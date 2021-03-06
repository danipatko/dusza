using System;
using System.Collections.Generic;

namespace Dusza {
    class TaskEight {
        public List<Measure> Measures;

        public string Result(string InvalidLicense) {
            string Exists = null;

            for (int i = 0; i < this.Measures.Count; i++)
                // Check if vehicle with license exists in database
                if (this.Measures[i].License == InvalidLicense && this.Measures[i].Type == "mk") {
                    Exists = "szerepel nem_lépte_túl";
                    // Check if it exceeded the speed limit
                    if (Exists != null && this.Measures[i].Speed > 130)
                        return "szerepel";
                }

            Console.WriteLine(Exists);
            // if exists is still null, return "nem_szerepel"
            return Exists ?? "nem_szerepel";
        }

        public string[] Solve() {
            string InvalidLicense = Console.ReadLine();
            string str = Result(InvalidLicense.Trim());
            Console.WriteLine(str);
            return new string[] { str };
        }
    }
}
