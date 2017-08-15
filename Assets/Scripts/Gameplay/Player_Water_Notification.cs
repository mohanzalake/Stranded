using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Player_Water_Notification : MonoBehaviour {

	private Rigidbody rb;
	private int timesDisplayed;
	private bool showing;
	public string waterMessage;
	private float distanceFromWaterContainer;
	private bool collectedWater;
	private bool showWater;
	private string waterPickUpMessage;

	public GUIStyle guiLabel;
	private GameObject waterContainer;
    public Text t1=null;

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

        t1.text = "Survive by picking resources";
      
    }

	void Update () {
		//If they are in the range then start the coroutine
		if (GameManager.GM.distanceFromWater <= 300 && timesDisplayed == 0) {
            distanceFromWaterContainer = Vector3.Distance(gameObject.transform.position, waterContainer.transform.position);
            Debug.Log ("Notification Showed");
			//timesDisplayed++;
			StartCoroutine (ShowMessage(10f));
            if(!collectedWater)
            {
                t1.text = waterMessage;
            }
			GameManager.GM.isWaterAreaExplored = true;
		}
        else
        {
            t1.text= "Survive by picking resources";
        }
		//If they are in the water area and have not collected the water
		/*if (GameManager.GM.isWaterAreaExplored == true && collectedWater == false)
			distanceFromWaterContainer = Vector3.Distance (gameObject.transform.position, waterContainer.transform.position);*/
		
		//If they are near the water container and press a button they can pick the water up and put in inventory
		//TODO: Make an inventory system to put items in 
		//For now will just add points to hydration in Game Manager by pressing E
        if(distanceFromWaterContainer <= 2)
        {
            if(GameManager.GM.hydration<100)
            {
                t1.text = "Water container is nearby, press 'E' to collect water";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameManager.GM.hydration = 100;
                    
                    collectedWater = true;
                    t1.text = "Collecting water...";
                    Debug.Log("picked up");
                }
            }
            else           
            {
                t1.text = "Hydration is complete, continue your journey";
            }
        }
        else if(collectedWater)
        {
            t1.text = "Survive by picking resources";
        }

		/*if (distanceFromWaterContainer <= 2 && Input.GetKeyDown (KeyCode.E) && collectedWater == false) {
			GameManager.GM.hydration = 100;
			collectedWater = true;
			Debug.Log ("picked up");
		} else if (distanceFromWaterContainer <= 2 && collectedWater == false) {
			showWater = true;
		} else {
			showWater = false;
		}*/

	}
		
	//Shows the notification for a limited time 
	IEnumerator ShowMessage(float timeToDisplay) {
		showing = true;
		yield return new WaitForSeconds (timeToDisplay);
		showing = false;
	
	}


	//Show GUI Label to notify the player that they are near the water area
	//TODO: Oculus UI match, then change background color.
	/*void OnGUI() {
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
        
	}*/
}
