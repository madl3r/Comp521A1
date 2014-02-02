﻿using UnityEngine;
using System.Collections;

public class GenSimpleMaze : MonoBehaviour {


	
//	1) Initialize a tree with a single vertex, chosen arbitrarily from the graph.
//	2) Grow the tree by one edge: Of the edges that connect the tree to vertices not yet in the tree, find the minimum-weight edge, and transfer it to the tree.
//	3) Repeat step 2 (until all vertices are in the tree).

	public GameObject[] theWalls;

	private ArrayList mazeRooms;
	private bool entered;

	// Use this for initialization
	void Start () {
		entered = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//When the player enters the foyer close the door behind them.
	void OnTriggerEnter(Collider other) {
		if (!entered)
		{
			entered = true;
			generateMaze();
		}
	}

	//Generate the maze, also chose 10 random walls to make destroyable.
	void generateMaze()
	{

	}

	//Set back to original state
	void restartMaze()
	{
		entered = false;
	}


//	//~~~ PRIMS ALGORITHM FROM THAT WEBSITE~~~
//	/*
//* An implementation of Prim's algorithm for generating a minimum spanning tree
//* given an edge weighted undirected graph G.
//* */
//		private Edge[] _edgeTo; //Keep track of the edges in our minimum spanning tree      
//		private double[] _distTo; //Keep track of the weights to each edge in our minimum spanning tree   
//		private Boolean[] _marked; //Keep track of which vertex we've looked
//		private IndexMinPriorityQueue<Double> _pq;  //the [vertex number]|[weight] key value pairs in our minimum spanning tree
//		
//		void PrimMST(EdgeWeightedGraph G)
//		{
//			//initialize the various arrays and the minimum priority queue
//			_edgeTo = new Edge[G.V()];
//			_distTo = new double[G.V()];
//			_marked = new Boolean[G.V()];
//			_pq = new IndexMinPriorityQueue<Double>(G.V());
//			//for each edge in the minimum spanning tree set the weight equal to infinity
//			for (int v = 0; v < G.V(); v++) _distTo[v] = Double.PositiveInfinity;
//			
//			for (int v = 0; v < G.V(); v++)      
//				if (!_marked[v]) Prim(G, v);      
//		}
//		
//		private void Prim(EdgeWeightedGraph G, int s)
//		{
//			//set the weight to source vertex s as 0
//			_distTo[s] = 0.0;
//			//insert the vertex into the priority queue as (vertex number, weight)
//			_pq.Insert(s, _distTo[s]);
//			while (!_pq.IsEmpty())
//			{
//				//remove a vertex from the top of the queue
//				int v = _pq.DeleteMin();
//				Scan(G, v);
//			}
//		}
//		
//		/*
//    * This method takes a vertex v, finds all the vertices connected to v and 
//    * compares their weights to the weights we've already found and determines if any of the weights
//    * are less than what we already have
//    * */
//		private void Scan(EdgeWeightedGraph G, int v)
//		{
//			//mark the vertex v, we only want one instance of each vertex in the mst
//			_marked[v] = true;
//			/*
//        * for each edge connected to v
//        *      -get the target vertex (w)
//        *      -compare the weight from s to w,
//        *      -if the weight from s to w is less than the weight from any other vertex to w
//        *       that we've already encountered 
//        *       -replace 
//        *          _distTo[w] with the new value 
//        *          _edgeTo[w] with the new edge
//        *          _pq[w] with the new distance or insert it into _distTo[] if a value
//        *          for_distTo[w] doesn't already exist
//        * */
//			foreach (Edge e in G.Adj(v))
//			{
//				int w = e.Target(v);
//				if (_marked[w]) continue;
//				if (e.Weight() < _distTo[w])
//				{
//					_distTo[w] = e.Weight();
//					_edgeTo[w] = e;
//					if (_pq.Contains(w)) _pq.ChangeKey(w, _distTo[w]);
//					else _pq.Insert(w, _distTo[w]);
//				}
//			}
//		}
//		
//		//Return all the edges in the MST
//		public IEnumerable<Edge> Edges()
//		{
//			Queue<Edge> mst = new Queue<Edge>();
//			for (int v = 0; v < _edgeTo.Length; v++)
//			{
//				Edge e = _edgeTo[v];
//				if (e != null)
//				{
//					mst.Enqueue(e);
//				}
//			}
//			return mst;
//		}
//		
//		/*
//    * Return the total weight of the of the minimum spanning tree.  The weight
//    * should be no larger than the weight of any other spanning tree.
//    * */
//		public double Weight()
//		{
//			double weight = 0.0;
//			foreach (Edge e in Edges())
//				weight += e.Weight();
//			return weight;
//		}


}