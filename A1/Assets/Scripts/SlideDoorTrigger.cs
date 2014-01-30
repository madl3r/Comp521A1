using UnityEngine;
using System.Collections;

public class SlideDoorTrigger : MonoBehaviour {
	
	public GameObject theDoor;
	public GameObject invisDoor;
	private Vector3 startScale = new Vector3 (1, 1, 1);
	private Vector3 endScale = new Vector3 (20, 1, 1);
	private float i;
	private bool entered;

	// Use this for initialization
	void Start () {
		i = 0.0f;
		entered = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (!entered)
		{
			entered = true;
			StartCoroutine(CloseDoor());
			invisDoor.collider.enabled = true;

		}
	}


	IEnumerator CloseDoor()
	{
		while(i < 1.0f)
		{
			i += Time.deltaTime;
			//Debug.Log(i);
			theDoor.transform.localScale = Vector3.Lerp(startScale, endScale, i);
			yield return new WaitForSeconds(0.0005f);
		}
		yield break;
	}
}
