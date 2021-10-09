using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dusza.Measure;

namespace Dusza
{
    class TaskEight
    {
        public List<Measure> Measures;

        public string Result(string InvalidLicense)
        {
            string Exists = null;

            for (int i = 0; i < this.Measures.Count; i++) 
                // Check if vehicle with license exists in database
                if (this.Measures[i].License == InvalidLicense && this.Measures[i].Type == "mk")
                {
                    Exists = "szerepel nem_lépte_túl";
                    // Check if it exceeded the speed limit
                    if (Exists != null && this.Measures[i].Speed > 130)
                        return "szerepel";
                }

            Console.WriteLine(Exists);
            // if exists is still null, return "nem_szerepel"
            return Exists ?? "nem_szerepel";
        }

        public void Solve()
        {
            string InvalidLicense = Console.ReadLine();

            Console.WriteLine(Result(InvalidLicense.Trim()));
        }
    }
}
