using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour {

	private bool foodPicked;
	private GUIStyle guiLabel;
	private string notificationMessage;
	private GameObject food;
    public Text t1 = null;
    // Use this for initialization
    void Start () {
		guiLabel = GameManager.GM.guiLabel;
		foodPicked = false;
		food = GameObject.FindGameObjectWithTag("Food");
        t1.text = "Survive by picking resources";
		notificationMessage = "There is some food near. It's better that you collect quickly to sustain.";
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (GameManager.GM.distanceFromFood);

        if(GameManager.GM.distanceFromFood <= 300 && GameManager.GM.distanceFromFood >5)
        {
            if(!foodPicked)
            {
                t1.text = notificationMessage;
            }
            else
            {
                t1.text = "Survive by picking resources";
            }
        }
        else if(GameManager.GM.distanceFromFood <=5)
        {
            if(!foodPicked)
            {
                t1.text = "Press 'E' to pickup food";
            }
            else
            {
                t1.text = "Health has replenished, continue your journey";
            }
            if(Input.GetKeyDown(KeyCode.E))
            {
                t1.text = "Picking food item...";
                GameManager.GM.health = 100;
                foodPicked = true;
            }
        }
        else
        {
            t1.text = "Survive by picking resources";
        }


		/*if (GameManager.GM.distanceFromFood <= 300 && !foodPicked) {
            
                t1.text = notificationMessage;
            
			notify (notificationMessage); //notify user
		}

		else if (GameManager.GM.distanceFromFood <= 5 && !foodPicked) {
            t1.text = "Press E to pickup food";

            notify ("Press E to pickup food");
		}
		else if (GameManager.GM.distanceFromFood <= 5 && Input.GetKeyDown (KeyCode.E) && !foodPicked) {
			
			food.SetActive (false); //Hide the food Item
			updateStats (); //Update Stats
		}*/

	}

	//Notifying Player
	void notify (string message) {
		
		guiLabel.fontSize = 20;
		GUI.backgroundColor = Color.black;
		//Make GUI Label appear as a box
		GUI.Label (new Rect (450, 30, 800, 50), message, guiLabel);

	}

	void updateStats () {

		GameManager.GM.health = 100;
		foodPicked = true;
        t1.text = "Your health has been increased";

        notify ("Your health has been increased");
	}
}
