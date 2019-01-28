using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class touchCheck : MonoBehaviour {
    public UnityEvent found;
    public UnityEvent[] actionEvents;
    public int action = 0;
    public string stickerID;
    public void activateSticker() {
        if (PlayerPrefs.GetInt(stickerID) == 0) { found.Invoke(); }
        PlayerPrefs.SetInt(stickerID, 1);
    }
    public void addtoAction() { action++; }
    public void animationAction() { GetComponent<Animator>().SetTrigger("action"); }
    public void touchThis() {

        actionEvents[action].Invoke();
        


    }
}

