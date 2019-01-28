using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class townPosition : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
		transform.Rotate(new Vector3(0,Random.Range(0,360),0));
		Ray ray = new Ray (transform.position, transform.forward);
		transform.position = ray.GetPoint (3500);
		transform.rotation = Quaternion.Euler (0, 0, 0);
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<gameManagement> ().success ();
		else if(col.tag=="bird")
			col.transform.position = randomPositions.randomBackUp (GameObject.FindGameObjectWithTag ("Player").transform);
	}

	// Update is called once per frame
	void Update () {


	}
}
