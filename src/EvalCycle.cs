﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3
{
	public static class EvalCycle
	{
        public static long[] EvaluatePopulation(Dictionary<int, (double x, double y)> Nodes, List<int[]> population)
		{
			var eval = new long[population.Count];

			for (int i = 0; i < population.Count; i++)
			{
				eval[i] = EvaluateCycle(Nodes, population[i]);
			}

			return eval;
		}
		public static long EvaluateCycle(Dictionary<int, (double x, double y)> Nodes, int[] permutation)
		{
			long cost = 0;

			for (int i = 0; i < permutation.Length - 1; i++)
			{
				cost += ComputeDistance(Nodes[permutation[i]], Nodes[permutation[i+1]]);
			}

			cost += ComputeDistance(Nodes[permutation[^1]], Nodes[permutation[0]]);

			return cost;
		}

		public static long ComputeDistance((double x, double y) node1, (double x, double y) node2)
		{
			return Convert.ToInt64(Math.Floor(Math.Sqrt(Math.Pow(node1.x - node2.x, 2) + Math.Pow(node1.y - node2.y, 2)) + 0.5));
		}
	}
}
