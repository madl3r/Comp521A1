using UnityEngine;
using System.Collections;

public class PlaceRemoveCoat : MonoBehaviour {

	public GameObject theCloak;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Instantiate(theCloak);
	}
}
