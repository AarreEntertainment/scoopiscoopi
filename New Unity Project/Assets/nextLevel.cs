using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape))
			Application.Quit ();
		else if (Input.GetButton("Fire1"))
			UnityEngine.SceneManagement.SceneManager.LoadScene ("hefty");
	}
}
