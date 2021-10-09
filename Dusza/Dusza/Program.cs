using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using static Dusza.TaskFive;

namespace Dusza
{
    class Measure
    {
        public string Region;
        public string License;
        public char ID;
        public string Type;
        public int Speed;
        public DateTime Time;
    }

    class Program
    {
        static void PrintMeasures(List<Measure> Measures)
        {
            for (int i = 0; i < Measures.Count; i++)
            {
                Console.WriteLine($"Region:{Measures[i].Region} License:{Measures[i].License} ID:{Measures[i].ID} Type:{Measures[i].Type} Speed:{Measures[i].Speed} Time:{Measures[i].Time} ");
            }
        }

        static void Main(string[] args)
        {
            // Read file contents and split then into lines
            string[] FileContents = File.ReadAllLines("D22.txt");
            int[] Distances = FileContents[0].Split(',').Select(x => int.Parse(x)).ToArray();

            // Convert lines to Measure objects and add them to the Measures list
            List<Measure> Measures = new List<Measure>();
            string[] Line;
            for (int i = 1; i < FileContents.Length; i++)
            {
                Line = FileContents[i].Split(',');
                Measures.Add(new Measure
                {
                    Region = Line[0],
                    License = Line[1],
                    ID = Line[2][0],
                    Type = Line[3],
                    Speed = int.Parse(Line[4]),
                    Time = DateTime.ParseExact(Line[5], "hh:mm:ss", CultureInfo.InvariantCulture)
                });
            }

            // print shit
            PrintMeasures(Measures);

        }
    }
}
