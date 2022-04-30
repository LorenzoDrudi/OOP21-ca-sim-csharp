using System;
using System.Collections.Generic;

namespace Drudi.Stats
{
    public class Stats<T>: IStats<T>
    {
        public int Iteration { get; }
        public Dictionary<T, int> CellStats { get; }
        public Stats(int iteration, Dictionary<T, int> cellStats)
        {
            this.Iteration = iteration;
            this.CellStats = cellStats;
        }

        public override string ToString()
        {
            return "Iterations: " + Iteration + Environment.NewLine + "States: " + CellStats;
        }
    }
}