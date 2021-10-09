using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dusza.Measure;

namespace Dusza
{
    class TaskFive
    {
        public List<Measure> Measures;
        class Speeder
        {
            public char Region;
            public string License;
            public int Speed;
            public DateTime Time;
        }
        public void Solve()
        {
            List<Speeder> Speeders = new List<Speeder>();
            DateTime UpperBorder = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 0, 0); //the end of the roadworks 
            foreach (var item in Measures) //goes through the input list and checks if the ID is "C", the time is between the start and the end of the roadworks, the type is "személygépjármű" and if the car was going more than 110 km/h 
            {
                if (item.ID == 'C' && (item.Time.Hour >= 9 && item.Time <= UpperBorder) && item.Type == "sz" && item.Speed > 110)
                {
                    Speeders.Add(new Speeder
                    {
                        Region = item.Region[0],
                        License = item.License,
                        Speed = item.Speed,
                        Time = item.Time
                    });
                }                
            }
            foreach (var item in Speeders) //the output
            {
                Console.Write($"{item.Region} {item.License} {item.Speed} {item.Time.Hour}:{item.Time.Minute}:{item.Time.Second}");
                Console.WriteLine();
            }
        }
    }
}
