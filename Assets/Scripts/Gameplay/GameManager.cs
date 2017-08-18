using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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

    public GUIText gameOverText;
    public GUIText restartText;

    public bool isWaterAreaExplored = false;
    public bool isFoodAreaExplored = false;
    public bool isShelterAreaExplored = false;
    private bool gameOver;
    private bool restart;
    private int score;

    public GUIStyle guiLabel;
    GameObject waterArea;
    GameObject foodArea;
    GameObject shelterArea;
    GameObject player;

    public Text clock;
    public float minutes, seconds;
    public Slider HealthBar; 
    public Slider WaterBar;
    private float max_health;
    private float max_water;
    private int temp;
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
        waterArea = GameObject.Find("Water_Area");
        foodArea = GameObject.Find("Food_Area");
        shelterArea = GameObject.Find("Final_Area");
        player = GameObject.Find("OVRPlayerController");
        distanceFromWater = Vector3.Distance(player.transform.position, waterArea.transform.position);
        distanceFromFood = Vector3.Distance(player.transform.position, foodArea.transform.position);
        distanceFromShelter = Vector3.Distance(player.transform.position, shelterArea.transform.position);

    }

    void Start()
    {
        max_health = 100;
        max_water = 100;
        health = 100;
        hydration = max_water;
        if(HealthBar != null)
        {
            HealthBar.value = health / max_health;
        }
        if(WaterBar !=null)
        {
            WaterBar.value = hydration / max_water;
        }
        temp = 1;

        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
    }

    //Update is called every frame.
    //Updating distnace between player and food,water,shelter
    void Update()
    {
		timePassed += Time.deltaTime;

		if(waterArea != null && player != null)
        distanceFromWater = Vector3.Distance(player.transform.position, waterArea.transform.position);

        if (foodArea != null && player != null)
        distanceFromFood = Vector3.Distance(player.transform.position, foodArea.transform.position);

        if (shelterArea != null && player != null)
        distanceFromShelter = Vector3.Distance(player.transform.position, shelterArea.transform.position);

        minutes = (int)(Time.time/60);
        seconds = (int)(Time.time%60);

        if(clock != null)
        clock.text = minutes.ToString("00") + ":" + seconds.ToString("00");

       if(minutes==temp)
        {
            temp+=1;
            hydration -= 10;
           
            if(hydration<=40)
            {
                health -= 10;
            }
            else
            {
                health -= 5;
            }  
        }
        if (WaterBar != null)
            WaterBar.value = hydration / max_water;
        if (HealthBar != null)
            HealthBar.value = health / max_health;
        if (health==0 || hydration==0)
        {
            Debug.Log("Game over :(");
        }
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        if (gameOver)
        {
            restartText.text = "Press 'R' for Restart";
            restart = true;
            
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
        public void NotifyUser(){
		//Do Something
		Debug.Log("Notified");

	}

}