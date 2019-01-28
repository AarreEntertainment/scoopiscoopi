using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class saveLoad {
    public static void Save(saveGame sg)
    {
    
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, sg);
        file.Close();
        Debug.Log("saved");
    }
    public static saveGame Load()
    {
        saveGame sg = null;
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            sg = (saveGame)bf.Deserialize(file);
            file.Close();
           
        }
        Debug.Log("loaded");
        return sg;
    }
}
[System.Serializable]
public class saveGame {
    public sticker[] stickers;
}

[System.Serializable]
public class sticker {
    public int index;
    public float x;
    public float y;
}

public class stickerSaver : MonoBehaviour {
    public gameController gc;
    public IEnumerator saver() {
        yield return new WaitForSeconds(2);
        if (transform.gameObject.activeSelf)
        {
            List<sticker> sticklist = new List<sticker>();

            if (transform.childCount > 0)
            {
                foreach (Transform child in transform)
                {

                    sticklist.Add(new sticker()
                    {
                        index = child.GetComponent<multiplyOnDragDrop>().index,
                        x = child.GetComponent<RectTransform>().anchoredPosition.x,
                        y = child.GetComponent<RectTransform>().anchoredPosition.y
                    });
                }
            }
            gc.sg.stickers = sticklist.ToArray();
            saveLoad.Save(gc.sg);
        }
        StartCoroutine(saver());
    }
	// Use this for initialization
	void OnEnable () {

        StartCoroutine(saver());
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
