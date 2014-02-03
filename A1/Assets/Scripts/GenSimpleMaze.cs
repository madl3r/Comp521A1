using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenSimpleMaze : MonoBehaviour {

	
	public GameObject[] theWalls;

	private List<string> mazeRooms;
	private Hashtable baseRooms;
	private bool entered;

	// Use this for initialization
	void Start () {
		entered = false;

		//baseRooms is a hashtable that holds onto every room as the key
		//each key has a list of String represeneting the edges to the adjacent rooms
		baseRooms = new Hashtable();

		for (int i = 1; i <= 5; i++)
		{
			for (int j = 1; j <= 5; j++)
			{
				string tempI = i.ToString();
				string tempJ = j.ToString();

				string tempImin = (i-1).ToString();
				string tempIpl = (i+1).ToString();
				string tempJmin = (j-1).ToString();
				string tempJpl = (j+1).ToString();

				string temp = tempI + tempJ;

				if (i == 1 && j == 1) // top left
				{
					baseRooms.Add(temp, new GameObject [] {GameObject.Find(temp+"_"+tempIpl+tempJ), GameObject.Find(temp+"_"+tempI+tempJpl)} );
				}
				else if (i == 1 && j == 5) // top right
				{
					baseRooms.Add(temp, new GameObject [] {GameObject.Find(temp+"_"+tempIpl+tempJ), GameObject.Find(tempI+tempJmin+"_"+temp)} );
				}
				else if (i == 5 && j == 1) //bottom left
				{
					baseRooms.Add(temp, new GameObject [] {GameObject.Find(tempImin+tempJ+"_"+temp), GameObject.Find(temp+"_"+tempI+tempJpl)} );
				}
				else if (i == 5 && j == 5) // bottom right
				{
					baseRooms.Add(temp, new GameObject [] {GameObject.Find(tempImin+tempJ+"_"+temp), GameObject.Find(tempI+tempJmin+"_"+temp)} );
				}
				else if (i == 1) //top side (not corners)
				{
					//down, right, left
					baseRooms.Add(temp, new GameObject [] {GameObject.Find(temp+"_"+tempIpl+tempJ), GameObject.Find(temp+"_"+tempI+tempJpl),
						GameObject.Find(tempI+tempJmin+"_"+temp)});
				}
				else if (j == 1) // left side
				{
					//up, down, right
					baseRooms.Add(temp, new GameObject [] {GameObject.Find(tempImin+tempJ+"_"+temp), GameObject.Find(temp+"_"+tempIpl+tempJ),
						GameObject.Find(temp+"_"+tempI+tempJpl)});
				}
				else if (j == 5)// right side
				{
					//up, down, left
					baseRooms.Add(temp, new GameObject [] {GameObject.Find(tempImin+tempJ+"_"+temp), GameObject.Find(temp+"_"+tempIpl+tempJ),
						GameObject.Find(tempI+tempJmin+"_"+temp)});
				}
				else if (i == 5)//bottom
				{
					//up, right, left
					baseRooms.Add(temp, new GameObject [] {GameObject.Find(tempImin+tempJ+"_"+temp), GameObject.Find(temp+"_"+tempI+tempJpl),
						GameObject.Find(tempI+tempJmin+"_"+temp)});
				}
				else //middle ppls
				{
					//up, down, right, left
					baseRooms.Add(temp, new GameObject [] {GameObject.Find(tempImin+tempJ+"_"+temp), GameObject.Find(temp+"_"+tempIpl+tempJ),
						GameObject.Find(temp+"_"+tempI+tempJpl), GameObject.Find(tempI+tempJmin+"_"+temp)});
				}

				Debug.Log("~~~~~~~~~~~~~" + temp + "'s value is: ");

				GameObject[] theVal = (GameObject[])baseRooms[temp];

				for(int k = 0; k < theVal.Length; k++)
				{
					Debug.Log(theVal[k].name);
				}

			}
		}
		Debug.Log(baseRooms.Count);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//reset errthang, and then generate a new maze.
	void OnTriggerEnter(Collider other) {
		if (!entered)
		{
			entered = true;
			mazeRooms = new List<string>();
			mazeRooms.Add("13");

			//Resetting the maze to have everything enabled.
			for (int i = 0; i < theWalls.Length; i++)
			{
				theWalls[i].renderer.enabled = true;
				theWalls[i].collider.enabled = true;
				theWalls[i].tag = "DynamicMaze";
			}

			generateMaze(mazeRooms);
			setDestroyableWalls();
		}
	}

	//	1) Initialize a tree with a single vertex, chosen arbitrarily from the graph.
	//	2) Grow the tree by one edge: Of the edges that connect the tree to vertices not yet in the tree, find the minimum-weight edge, and transfer it to the tree.
	//	3) Repeat step 2 (until all vertices are in the tree).

	//Generate the maze, also chose 10 random walls to make destroyable.
	void generateMaze(List<string> mazeSoFar)
	{


		//Choose a random room to branch off of
		int toBranchFrom = Random.Range(0, mazeRooms.Count);

		//Try to branch off of that by choosing a random edge.
		GameObject[] theEdges = (GameObject[]) baseRooms[mazeSoFar[toBranchFrom]];
		int edgeToTake = Random.Range(0, theEdges.Length);
		string theEdgeName = theEdges[edgeToTake].name;
		string[] roomsOnEdge = theEdgeName.Split('_');


		//Once mazeSoFar islength 25 then return.
		if (mazeSoFar.Count == 25)
		{
			return;
		}
		//If that edge IS ALREADY ON THE LIST do nothing and call this method again.
		else if (mazeSoFar.Contains(roomsOnEdge[0]) && mazeSoFar.Contains(roomsOnEdge[1]))
		{
			generateMaze(mazeSoFar);
		}
		//If that edge leads to a room not on the list already, add it and make that edge invisible/no collisiosn
		else if (mazeSoFar[toBranchFrom] == roomsOnEdge[0])
		{
			mazeSoFar.Add(roomsOnEdge[1]);
			theEdges[edgeToTake].renderer.enabled = false;
			theEdges[edgeToTake].collider.enabled = false;
			generateMaze(mazeSoFar);
		}
		else if (mazeSoFar[toBranchFrom] == roomsOnEdge[1])
		{
			mazeSoFar.Add(roomsOnEdge[0]);
			theEdges[edgeToTake].renderer.enabled = false;
			theEdges[edgeToTake].collider.enabled = false;
			generateMaze(mazeSoFar);
		}
	

	}

	//Choose from the remaining walls randomly ones that can be destroyed.
	//Set their tag to "Destroyable"
	void setDestroyableWalls()
	{
		int numDestroyable = Random.Range(5, 11);
		List<GameObject> candidateWalls = new List<GameObject>();
		List<GameObject> destroyableWalls = new List<GameObject>();
		int indexToAdd;

		Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~There are: " + numDestroyable + " destroyable walls");

		for (int i = 0; i < theWalls.Length; i++)
		{
			if (theWalls[i].collider.enabled && theWalls[i].renderer.enabled && theWalls[i].tag == "DynamicMaze")
			{
				candidateWalls.Add(theWalls[i]);
			}
		}

		while(destroyableWalls.Count < numDestroyable)
		{
			indexToAdd = Random.Range(0, candidateWalls.Count);
			if (!destroyableWalls.Contains(candidateWalls[indexToAdd]))
			{
				destroyableWalls.Add(candidateWalls[indexToAdd]);
				candidateWalls[indexToAdd].tag = "Destroyable";
			}
		}



	}

	//Set back to original state
	void restartMaze()
	{
		entered = false;
	}


}
