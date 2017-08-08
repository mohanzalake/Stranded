using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Attach to player 
public class Player_Water_Notification : MonoBehaviour {

	private Rigidbody rb;
	private int timesDisplayed;
	private bool showing;
	private string waterMessage;
	private float distanceFromWaterContainer;
	private bool collectedWater;
	private bool showWater;
	private string waterPickUpMessage;

	public GUIStyle guiLabel;
	private GameObject waterContainer;

	void Start () {
		
		//Get Player Rigidbody TODO: Not Used
		rb = gameObject.GetComponent<Rigidbody> ();
		//To make sure the message only appears once
		timesDisplayed = 0;
		//Boolean if message is displaying
		showing = false;
		//Message to display when in Water Area
		waterMessage = "There is some water near, I better collect it quickly to hydrate myself.";
		//Find water container
		waterContainer = GameObject.FindGameObjectWithTag("Water_Container");
		//Initial distance from the Water Container
		distanceFromWaterContainer = Vector3.Distance(gameObject.transform.position, waterContainer.transform.position);
		//Boolean that says whether player has collected water container
		collectedWater = false;
		//Boolean that displays GUI Message to pick up water
		showWater = false;
		//Message to display to pickup water
		waterPickUpMessage = "Press E to Pick Up the Water.";
	}

	void Update () {
		//If they are in the range then start the coroutine
		if (GameManager.GM.distanceFromWater <= 300 && timesDisplayed == 0) {
			Debug.Log ("Notification Showed");
			timesDisplayed++;
			StartCoroutine (ShowMessage(10f));
			GameManager.GM.isWaterAreaExplored = true;
		}
		//If they are in the water area and have not collected the water
		if (GameManager.GM.isWaterAreaExplored == true && collectedWater == false)
			distanceFromWaterContainer = Vector3.Distance (gameObject.transform.position, waterContainer.transform.position);
		
		//If they are near the water container and press a button they can pick the water up and put in inventory
		//TODO: Make an inventory system to put items in 
		//For now will just add points to hydration in Game Manager by pressing E
		if (distanceFromWaterContainer <= 2 && Input.GetKeyDown (KeyCode.E) && collectedWater == false) {
			GameManager.GM.hydration = 100;
			collectedWater = true;
			Debug.Log ("picked up");
		} else if (distanceFromWaterContainer <= 2 && collectedWater == false) {
			showWater = true;
		} else {
			showWater = false;
		}

	}
		
	//Shows the notification for a limited time 
	IEnumerator ShowMessage(float timeToDisplay) {
		showing = true;
		yield return new WaitForSeconds (timeToDisplay);
		showing = false;
	
	}


	//Show GUI Label to notify the player that they are near the water area
	//TODO: Oculus UI match, then change background color.
	void OnGUI() {
		if (showing) {
			//Change style of GUI Label
			guiLabel.fontSize = 20;
			GUI.backgroundColor = Color.black;
			//Make GUI Label appear as a box
			GUI.Label (new Rect (250, 30, 800, 50), waterMessage, guiLabel);
		}

		if (showWater) {
			//Change style of GUI Label
			guiLabel.fontSize = 20;
			GUI.backgroundColor = Color.black;
			//Make GUI Label appear as a box
			GUI.Label (new Rect (450, 30, 800, 50), waterPickUpMessage, guiLabel);
		}
	}
}
