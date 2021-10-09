using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Dusza {
    class TaskNine {
        public List<Measure> Measures;

        public IEnumerable<string> GetInvalidHungarianLicenses() {
            // First 3 characters match A-Z, followed by a - and 3 digits
            Regex MatchHungarianLicense = new Regex(@"^[A-Z]{3}-\d{3}$");
            // Iterate through measures, return invalid ones
            for (int i = 0; i < Measures.Count; i++)
                if (this.Measures[i].Region == "H" && !MatchHungarianLicense.IsMatch(this.Measures[i].License))
                    yield return this.Measures[i].License;
        }

        public IEnumerable<string> Solve() {
            // Print out solution
            foreach (string InvalidLicense in GetInvalidHungarianLicenses().ToArray()) {
                Console.WriteLine(InvalidLicense);
                yield return InvalidLicense;
            }
        }
    }
}
