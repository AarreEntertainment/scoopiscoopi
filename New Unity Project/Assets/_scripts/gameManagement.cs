using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameManagement : MonoBehaviour {
	public GameObject failMenu;
	public GameObject successMenu;
	public GameObject exitMenu;

	public void fail(){
		failMenu.SetActive (true);
		Time.timeScale = 0;
	}
	public void success(){
		successMenu.SetActive (true);
		Time.timeScale = 0;
	}

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if ((failMenu.activeSelf || successMenu.activeSelf) && Input.GetKey (KeyCode.Escape))
			UnityEngine.SceneManagement.SceneManager.LoadScene ("titleScreen");
		else if (failMenu.activeSelf && Input.GetButton ("Fire1"))
			UnityEngine.SceneManagement.SceneManager.LoadScene ("hefty");
		else if(Input.GetKey(KeyCode.Escape)){
			Time.timeScale=0;
			exitMenu.SetActive (true);
		}

	}
	public void normalTimescale()
	{
		Time.timeScale = 1;
	}
	public void exit()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("titleScreen");
	}
}
