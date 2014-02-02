using UnityEngine;
using System.Collections;

public class ReturnToStartMaze : MonoBehaviour {


	public GameObject mazeGenerator;
	public GameObject elevatorTrigger;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other)
	{
		other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, 8.0f, -7.5f);
		mazeGenerator.SendMessage("restartMaze");
		elevatorTrigger.SendMessage("returnBlockToStart");
	}
}
