using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.tag == "Destroyable")
		{
			c.gameObject.collider.enabled = false;
			c.gameObject.renderer.enabled = false;
		}

		Destroy(gameObject); //remove from the scene the gameobject
		
	}
}
