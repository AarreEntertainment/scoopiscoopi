using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class textrandomizer : MonoBehaviour {
	string[] reviews;
	public TextAsset revs;
	// Use this for initialization
	void Start () {
		reviews = revs.text.Split (';');
	}
	float timer = 60;
	float fadeTimer = 20;
	// Update is called once per frame
	void Update () {
		if (timer > 0)
			timer -= Time.deltaTime;
		else {
			GetComponent<Text> ().text = reviews [Random.Range (0, reviews.Length)];
			timer = 600;
		}
		if (GetComponent<Text> ().text.Length > 0 && fadeTimer > 0)
			fadeTimer -= Time.deltaTime;
		else if (GetComponent<Text> ().text.Length > 0 && fadeTimer <= 0) {
			GetComponent<Text> ().text = "";
			fadeTimer = 10;
		}
	}
}
