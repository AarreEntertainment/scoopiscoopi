using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stepControl : MonoBehaviour {
	Animator characterAnim;
	Image left;
	Image right;
	public Text fatigueText;
	public float fatigueMax;
	public bool distanceBetween = false;
	float startDistance = 0;
	float delay = 20;
	// Use this for initialization
	void Start () {
		characterAnim = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ();
		left = transform.GetChild (0).GetComponent<Image> ();
		right = transform.GetChild (1).GetComponent<Image> ();
	}
	bool leftStepped = false;
	bool leftHalfway = false;
	bool leftEnded = false;
	bool leftFalse = false;
	bool leftCorrect = false;

	bool rightStepped = false;
	bool rightHalfway = false;
	bool rightEnded = false;
	bool rightFalse = false;
	bool rightCorrect = false;


	float fatigue = 0;
	// Update is called once per frame
	void Update () {

		if (!distanceBetween && Vector3.Distance (GameObject.FindGameObjectWithTag ("Player").transform.position, GameObject.FindGameObjectWithTag ("town").transform.position) > 200) {
			distanceBetween = true;
			startDistance = Vector3.Distance (GameObject.FindGameObjectWithTag ("Player").transform.position, GameObject.FindGameObjectWithTag ("town").transform.position);
		}
		if (distanceBetween) {
			float num = Vector3.Distance (GameObject.FindGameObjectWithTag ("Player").transform.position, GameObject.FindGameObjectWithTag ("town").transform.position) / startDistance;
			fatigueText.text = ((1 - num) * 100).ToString ();
		}
		if (delay > 0) {
			delay -= Time.deltaTime;

		}
		else {
			if (!left.gameObject.activeSelf)
				left.gameObject.SetActive (true);
			if (!right.gameObject.activeSelf)
				right.gameObject.SetActive (true);
			
			if (Mathf.Abs (Input.GetAxis ("Horizontal")) > 0.2f) {
				GameObject.FindGameObjectWithTag ("Player").transform.Rotate (new Vector3 (0, Input.GetAxis ("Horizontal"), 0));
			}

			if (!leftStepped && !leftEnded)
				left.color = new Color (1, 1, 1, 0.2f + 0.8f * characterAnim.GetFloat ("leftFoot"));
			else if (leftStepped) {
				left.color = new Color (0, 1, 0, 0.2f + 0.8f * characterAnim.GetFloat ("leftFoot"));
				if (!leftCorrect) {
					leftCorrect = true;
					if (fatigue > 0)
						fatigue -= 0.5f;
				}
			}
			if (!rightStepped && !rightEnded)
				right.color = new Color (1, 1, 1, 0.2f + 0.8f * characterAnim.GetFloat ("rightFoot"));
			else if (rightStepped) {
				right.color = new Color (0, 1, 0, 0.2f + 0.8f * characterAnim.GetFloat ("rightFoot"));
				if (!rightCorrect) {
					rightCorrect = true;
					if (fatigue > 0)
						fatigue -= 0.5f;
				}
			}

			if (Input.GetButtonDown ("Fire1") && !leftStepped)
				leftStepped = true;
			if (Input.GetButtonDown ("Fire2") && !rightStepped)
				rightStepped = true;

			if (characterAnim.GetFloat ("leftFoot") < 0.001f)
				leftEnded = true;

			if (leftEnded && !leftStepped) {
				left.color = new Color (1, 0, 0, 0.2f + 0.8f * characterAnim.GetFloat ("leftFoot"));
				if (!leftFalse) {
					leftFalse = true;
					if (fatigue < fatigueMax)
						fatigue++;
					else
						failGame ();
				}
			}


			if (leftEnded && characterAnim.GetFloat ("leftFoot") > 0.001f) {
				leftEnded = false;
				leftStepped = false;
				leftCorrect = false;
				leftFalse = false;
			}


			if (characterAnim.GetFloat ("rightFoot") < 0.001f)
				rightEnded = true;
		
			if (rightEnded && !rightStepped) {
				right.color = new Color (1, 0, 0, 0.2f + 0.8f * characterAnim.GetFloat ("rightFoot"));
				if (!rightFalse) {
					rightFalse = true;
					if (fatigue < fatigueMax)
						fatigue++;
					else
						failGame ();
				}
			}

			if (rightEnded && characterAnim.GetFloat ("rightFoot") > 0.001f) {
				rightEnded = false;
				rightStepped = false;
				rightCorrect = false;
				rightFalse = false;
			}
		}
		//fatigueText.text = fatigue.ToString ();

	}


	void failGame()
	{
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<gameManagement> ().fail ();
	}
}
