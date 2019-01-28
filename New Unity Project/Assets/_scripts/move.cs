using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class randomPositions{
	public static Vector3 randomBackUp(Transform actor){
		return new Vector3(actor.position.x + (-14 + Random.Range(0,28)), 14+ Random.Range(3,8), actor.position.z + (-14 + Random.Range(0,28)));

	}
}

public class move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	float timer = 10;
	// Update is called once per frame
	void Update () {
		transform.LookAt (GameObject.FindGameObjectWithTag ("town").transform.position);
		transform.position =  Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag ("town").transform.position, Time.deltaTime*16);
		if (timer > 0)
			timer -= Time.deltaTime;
		else {
			timer = Random.Range (25, 200);
			transform.position = randomPositions.randomBackUp (GameObject.FindGameObjectWithTag ("Player").transform);
		}
	}
}
