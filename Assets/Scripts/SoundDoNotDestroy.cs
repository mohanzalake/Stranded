using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDoNotDestroy : MonoBehaviour {

	private static SoundDoNotDestroy current = null;
	//Returns current instance of sound gameObject
	public static SoundDoNotDestroy Instance {
		get {
			return current;
		}
	}

	void Start () {
		//If there is an instance but is not current then destroy
		if (current != null && current != this) {
			Destroy (this.gameObject);
			return;
		}
		//If there is no current instance 
		else {
			current = this;
		}
		//When switching scenes the SoundManager Game Object will not be destroyed
		DontDestroyOnLoad (this.gameObject);
	}

}
