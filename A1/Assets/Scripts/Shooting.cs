using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	
	public GameObject fireBall; 
	public float power;
	public Transform tCamera;
	
	// Use this for initialization
	void Start () {
		tCamera = GameObject.Find("Main Camera").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			//Create fireball
			
			
			GameObject g = Instantiate(fireBall,transform.position + tCamera.forward, transform.rotation) as GameObject; 
			
			
			
			g.GetComponent<Rigidbody>().velocity = tCamera.forward * power + tCamera.up * power * 0.1f;
			
			
		}
	}
}
