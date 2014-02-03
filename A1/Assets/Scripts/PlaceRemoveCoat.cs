using UnityEngine;
using System.Collections;

public class PlaceRemoveCoat : MonoBehaviour {

	//Game Objects.
	public GameObject theCloak;
	public GameObject placeText;
	public GameObject takeText;
	public GameObject cloakText;
	public GameObject emptyText;
	public GameObject spotLight;


	private bool byTheHanger;
	private bool hangerHasCloak;



	// Use this for initialization
	void Start () {
		byTheHanger = false;
		hangerHasCloak = false;
		spotLight.light.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		//Place the Cloak
		if (byTheHanger && !hangerHasCloak && Input.GetKeyDown("e"))
		{
			cloakText.guiText.enabled = false;
			emptyText.guiText.enabled = true;
			placeText.guiText.enabled = false;
			takeText.guiText.enabled = true;
			spotLight.light.enabled = true;
			hangerHasCloak = true;
			Instantiate(theCloak);
		}
		//Take the Cloak
		else if (byTheHanger && hangerHasCloak && Input.GetKeyDown("e"))
		{
			cloakText.guiText.enabled = true;
			emptyText.guiText.enabled = false;
			placeText.guiText.enabled = true;
			takeText.guiText.enabled = false;
			spotLight.light.enabled = false;
			hangerHasCloak = false;
			Destroy(GameObject.Find("CloakOfDarkness(Clone)"));
		}
	
	}

	// Display the GUI text, say that we're close to the hanger
	void OnTriggerEnter(Collider other) 
	{
		byTheHanger = true;

		if (hangerHasCloak)
		{
			takeText.guiText.enabled = true;
		}
		else
		{
			placeText.guiText.enabled = true;
		}

	}

	// set far away from hanger, get rid of the GUI text
	void OnTriggerExit(Collider other)
	{
		byTheHanger = false;


		takeText.guiText.enabled = false;
		placeText.guiText.enabled = false;
	}
}
