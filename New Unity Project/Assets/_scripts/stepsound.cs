using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepsound : MonoBehaviour {
	AudioSource au;
	// Use this for initialization
	void Start () {
		au = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void sl()
	{
		au.panStereo = -0.3f;
		au.Play ();
	}
	public void sr()
	{
		au.panStereo = 0.3f;
		au.Play ();
	}
}
