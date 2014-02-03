using UnityEngine;
using System.Collections;

public class EnterBar : MonoBehaviour {

	public GameObject spotLight;
	public GameObject youText;
	public GameObject haveText;
	public GameObject wonText;
	public GameObject lostText;

	private int enterRoomCounter;
	private bool gameLost;
	private bool gameWon;


	// Use this for initialization
	void Start () {
		enterRoomCounter = 0;
		gameLost = false;
		gameWon = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider other) 
	{
		// Lose the game if too many times
		if (spotLight.light.enabled == false)
		{
			enterRoomCounter++;
			if (enterRoomCounter >= 3)
			{
				gameLost = true;
			}
		}
		//Win game
		else if (spotLight.light.enabled == true && !gameLost)
		{
			youText.renderer.enabled = true;
			haveText.renderer.enabled = true;
			wonText.renderer.enabled = true;
			gameWon = true;
		}

		// If the game is won you always see win
		if (gameWon)
		{
			youText.renderer.enabled = true;
			haveText.renderer.enabled = true;
			wonText.renderer.enabled = true;
		}

		// If the game is lost you always see lose
		else if (gameLost)
		{
			youText.renderer.enabled = true;
			haveText.renderer.enabled = true;
			lostText.renderer.enabled = true;
		}
		
	}

	//Hide the 3d Text
	void OnTriggerExit(Collider other)
	{
		youText.renderer.enabled = false;
		haveText.renderer.enabled = false;
		wonText.renderer.enabled = false;
		lostText.renderer.enabled = false;
	}
}
