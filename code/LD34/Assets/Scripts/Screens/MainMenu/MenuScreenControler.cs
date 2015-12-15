using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TinyMessenger;

public class MenuScreenControler : Fadeable {
    
    public RectTransform rectGate;
    public GameObject stamp;    
    public Animator anim;    

    void OnAwake() {
    }
    public void OnStart() {
        GameController.Instance.player = null;
        StartFadeOut();
    }

    public void OnDestroy() {        
    }

    protected void Update() {
        base.Update();

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)) {
            anim.SetBool("open_all", true);

            StartFadeIn();
        } else {
            anim.SetBool("open_all", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {
            anim.SetBool("open_half", true);
        } else {
            anim.SetBool("open_half", false);
        }
    }

    public void ShowStamp() {
        stamp.SetActive(true);
    }

}
