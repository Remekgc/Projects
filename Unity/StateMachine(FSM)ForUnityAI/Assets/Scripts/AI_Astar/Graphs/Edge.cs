using UnityEngine;
using System.Collections;

namespace AI_Astar
{
	public class Edge
	{
		public Node startNode;
		public Node endNode;

		public Edge(Node from, Node to)
		{
			startNode = from;
			endNode = to;
		}
	}

}
