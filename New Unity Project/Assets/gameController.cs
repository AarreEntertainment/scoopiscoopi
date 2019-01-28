using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {
    public saveGame sg;
    public Transform stickers;
    public Transform stickerMenu;
	// Use this for initialization
	void Start ()
    {
        loard();

    }
    public void loard()
    {/*
        sg = saveLoad.Load();
        if (sg == null)
        {
            sg = new saveGame();
            sg.stickers = new sticker[0];
        }

            foreach (Transform child in stickers)
            {
                Destroy(child.gameObject);
            }

        if (sg.stickers.Length > 0)
        {
          
            foreach (sticker stick in sg.stickers)
            {

                GameObject draggable = Instantiate(stickerMenu.GetChild(stick.index).gameObject, stickers);
                RectTransform rt = draggable.GetComponent(typeof(RectTransform)) as RectTransform;
                rt.sizeDelta = new Vector2(100, 100);
                draggable.GetComponent<multiplyOnDragDrop>().origin = false;
                draggable.GetComponent<multiplyOnDragDrop>().source = this.gameObject;
                rt.anchoredPosition = new Vector2(stick.x, stick.y);

            }
        }*/
    }
    // Update is called once per frame
    void Update () {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {

                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (hit.collider.GetComponent<touchCheck>() != null)
                    {
                        Debug.Log("hippo");
                        hit.collider.GetComponent<touchCheck>().touchThis();
                    }
                }
            }
        }
    }
}
