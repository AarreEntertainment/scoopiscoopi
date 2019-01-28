using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetAll : MonoBehaviour {
    public gameController gc;
    public string[] stickerNames;
    public void reset()
    {
        gc.sg.stickers = new List<sticker>().ToArray();
        
        foreach(string str in stickerNames)
        {
            PlayerPrefs.SetInt(str, 0);
        }
        saveLoad.Save(gc.sg);
        gc.loard();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
