﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dusza.Measure;

namespace Dusza
{
    class TaskSix
    {
        class Speeder
        {
            public string Region;
            public string License;
            public char ID1;
            public char ID2;
            public int AvgSpeed;
        }
        public List<Measure> Measures;
        public void Solve(int[] distances)
        {
            int[] Distances = distances;
            List<Speeder> AvgSpeeders = new List<Speeder>();
            int Distance = 0;
            for (int i = 0; i < Measures.Count()-1; i++)
            {
                for (int j = i+1; j < Measures.Count(); j++)
                {
                    if (Measures[j].License == Measures[i].License && ((Measures[i].ID == 'A' && Measures[j].ID == 'B') || (Measures[i].ID == 'B' && Measures[j].ID == 'C')))
                    {
                        TimeSpan TimeDifference = Measures[j].Time - Measures[i].Time;
                        switch (Measures[j].ID)
                        {
                            case 'B':
                                Distance = Distances[1] - Distances[0];
                                break;
                            case 'C':
                                Distance = Distances[2] - Distances[1];
                                break;
                        }
                        int AvarageSpeed = (int)(Distance*1000 / (int)TimeDifference.TotalSeconds * 3.6);
                        AvgSpeeders.Add(new Speeder
                        {
                            Region = Measures[i].Region,
                            License = Measures[i].License,
                            ID1 = Measures[i].ID,
                            ID2 = Measures[j].ID,
                            AvgSpeed = AvarageSpeed
                        });
                    }
                }
            }
            foreach (var item in AvgSpeeders)
            {
                Console.Write($"{item.Region} {item.License} {item.ID1} {item.ID2} {item.AvgSpeed}");
                Console.WriteLine();
            }
        }
    }
}