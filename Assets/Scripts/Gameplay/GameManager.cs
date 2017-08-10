using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager GM = null;              //Static instance of GameManager which allows it to be accessed by any other script.


    //How to reference these variable
    //Example-> GameManager.GM.distanceFromFood
    //Example included in TestScript.cs
    
    public float health = 0;
    public float hydration = 0;

    public float distanceFromWater = 0;
    public float distanceFromFood = 0;

    public float distanceFromShelter = 0;

    public float timePassed = 0;

    public bool isWaterAreaExplored = false;
    public bool isFoodAreaExplored = false;
    public bool isShelterAreaExplored = false;
	public GUIStyle guiLabel;
    GameObject waterArea;
    GameObject foodArea;
    GameObject shelterArea;
    GameObject player;
    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (GM == null)

            //if not, set instance to this
            GM = this;

        //If instance already exists and it's not this:
        else if (GM != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);


        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        health = 100;
        hydration = 100;
        waterArea = GameObject.Find("Water_Area");
        foodArea = GameObject.Find("Food_Area");
        shelterArea = GameObject.Find("Final_Area");
        player = GameObject.Find("OVRPlayerController");
        distanceFromWater = Vector3.Distance(player.transform.position, waterArea.transform.position);
        distanceFromFood = Vector3.Distance(player.transform.position, foodArea.transform.position);
        distanceFromShelter = Vector3.Distance(player.transform.position, shelterArea.transform.position);

    }



    //Update is called every frame.
	//Updating distnace between player and food,water,shelter
    void Update()
    {
		timePassed += Time.deltaTime;

		if(!isWaterAreaExplored)
        distanceFromWater = Vector3.Distance(player.transform.position, waterArea.transform.position);
        
		if(!isFoodAreaExplored)
		distanceFromFood = Vector3.Distance(player.transform.position, foodArea.transform.position);
        
		if(!isShelterAreaExplored)
		distanceFromShelter = Vector3.Distance(player.transform.position, shelterArea.transform.position);
    }


	public void NotifyUser(){
		//Do Something
		Debug.Log("Notified");

	}

}