using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelerorotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = new Vector3(Input.acceleration.z/3, Input.acceleration.x, 0);
	}
}
