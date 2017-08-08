using UnityEngine;

public class TriggerStay: MonoBehaviour {
	
	void Start () {	
	}
	
	void Update () {
	}

    private void OnTriggerStay (Collider player)
    {
        Debug.Log("player is within the trigger");
    }   
}
