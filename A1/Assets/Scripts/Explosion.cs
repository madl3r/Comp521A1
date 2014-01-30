using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	
	
	public GameObject theExplosion;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision c)
	{
		Debug.Log ("I'm dead");
		Destroy(gameObject);
	}
	
}


