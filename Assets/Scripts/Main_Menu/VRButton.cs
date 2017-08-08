using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VRButton : MonoBehaviour {

	private Button changeScene;

	//Get current button attached
	void Start () {
		changeScene = gameObject.GetComponent<Button> ();
	}

	//When user looks at button
	public void OnGazeEnter() {
		Debug.Log ("Looking at Button");
	}

	//Change Scene to Hurricane One
	public void loadHurricaneScene() {
		SceneManager.LoadScene (1);
	}
}
