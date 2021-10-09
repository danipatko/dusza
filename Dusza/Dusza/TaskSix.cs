using System;
using System.Collections.Generic;
using System.Linq;

namespace Dusza {
    class TaskSix {
        class Speeder {
            public string Region;
            public string License;
            public char ID1;
            public char ID2;
            public int AvgSpeed;
        }
        public List<Measure> Measures;
        public IEnumerable<string> Solve(int[] distances) {
            int[] Distances = distances; //the distances of the traffipaxes
            List<Speeder> AvgSpeeders = new List<Speeder>();
            int Distance = 0;
            for (int i = 0; i < Measures.Count() - 1; i++) //these 2 fors go through the list checking if a car went through at least two traffipaxes
            {
                for (int j = i + 1; j < Measures.Count(); j++) {
                    if (Measures[j].License == Measures[i].License && ((Measures[i].ID == 'A' && Measures[j].ID == 'B') || (Measures[i].ID == 'B' && Measures[j].ID == 'C')) && Measures[i].Type == "sz") //this checks if a car went through a second/third traffipax and if those traffipaxes are next to each other
                    {
                        TimeSpan TimeDifference = Measures[j].Time - Measures[i].Time; //this is the time it took the car to reach the next traffipax
                        switch (Measures[j].ID) //the distance between the two traffipaxes
                        {
                            case 'B':
                                Distance = Distances[1] - Distances[0];
                                break;
                            case 'C':
                                Distance = Distances[2] - Distances[1];
                                break;
                        }
                        int AvarageSpeed = (int)(Distance * 1000 / (int)TimeDifference.TotalSeconds * 3.6); //the cars avarage speed calculated with v=s/t
                        if (AvarageSpeed > 130) //checks if the avarage speed is greater than the maximum speed it can go with
                        {
                            AvgSpeeders.Add(new Speeder {
                                Region = Measures[i].Region,
                                License = Measures[i].License,
                                ID1 = Measures[i].ID,
                                ID2 = Measures[j].ID,
                                AvgSpeed = AvarageSpeed
                            });
                        }
                    }
                }
            }
            foreach (var item in AvgSpeeders) {
                string str = $"{item.Region} {item.License} {item.ID1} {item.ID2} {item.AvgSpeed}";
                Console.WriteLine(str);
                yield return str;
            }
        }
    }
}
