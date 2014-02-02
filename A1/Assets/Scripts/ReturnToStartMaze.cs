using UnityEngine;
using System.Collections;

public class ReturnToStartMaze : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other)
	{
		other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, 8.0f, -7.5f);
	}
}
