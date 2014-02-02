using UnityEngine;
using System.Collections;

public class ElevatorStart : MonoBehaviour {


	public GameObject elevator;
	private Vector3 startPos, endPos;

	// Use this for initialization
	void Start () {
		startPos = new Vector3 (elevator.transform.position.x, elevator.transform.position.y, elevator.transform.position.z);
		endPos = new Vector3 (startPos.x, -2f, startPos.z);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//When the player enters the foyer close the door behind them.
	void OnTriggerEnter(Collider other) {
		StartCoroutine(ElevatorDown());
	}
	
	//Using coroutine so that waits feel good.
	//Lerps the door closed.
	IEnumerator ElevatorDown()
	{
		float i = 0;
		while(i < 1.0f)
		{
			i += Time.deltaTime * 0.5f;
			//Debug.Log(i);
			elevator.transform.position = Vector3.Lerp(startPos, endPos, i);
			yield return new WaitForSeconds(0.005f);
		}
		yield break;
	}
}
