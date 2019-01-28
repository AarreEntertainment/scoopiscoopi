using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiplyOnDragDrop : MonoBehaviour {
    public bool origin;
    public bool dragging;
    public Transform stickers;
    GameObject draggable;
    public GameObject source;
    public int index;
    public string stickerID;

    [ExecuteInEditMode]
    private void OnValidate()
    {
        if(origin)
        {
            index = transform.GetSiblingIndex();
        }
    }

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt(stickerID) == 1 || stickerID.Length==0)
        {
            GetComponent<UnityEngine.UI.Image>().color = Color.white;
        }
        else
        { GetComponent<UnityEngine.UI.Image>().color = Color.black; }
    }

    public void dragstart ()
    {
      
      if (GetComponent<UnityEngine.UI.Image>().color == Color.black)
            return;

        if (!dragging)
        {
            dragging = true;
            if (origin )
            {
                draggable = Instantiate(transform.gameObject, stickers);
                RectTransform rt = draggable.GetComponent(typeof(RectTransform)) as RectTransform;
                rt.sizeDelta = new Vector2(200, 200);
                draggable.GetComponent<multiplyOnDragDrop>().origin = false;
                draggable.GetComponent<multiplyOnDragDrop>().source = this.gameObject;
            }
            else
            {
                dragging = true;
            }
        }
        else {
            Debug.Log("dragging");
            if (origin)
            {

                    draggable.transform.position = Input.GetTouch(0).position;
            }
            else {
                transform.position = Input.GetTouch(0).position;
            }
        }
    }

    private void Update()
    {
        if(!origin&& Input.touchCount==0 && transform.position.x < 400)
            Destroy(transform.gameObject);
    }
    public void dragend() {
            dragging = false;
            if (origin)
            {
                draggable = null;
        }
        if (source != null) {
           source.GetComponent<multiplyOnDragDrop>().dragging = false;
            source.GetComponent<multiplyOnDragDrop>().draggable = null;
            source = null;
        }
        if (!origin && transform.position.x < 400)
        {
            Destroy(transform.gameObject);
        }
    }

}
