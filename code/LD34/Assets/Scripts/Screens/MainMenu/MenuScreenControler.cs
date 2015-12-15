using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TinyMessenger;

public class MenuScreenControler : MonoBehaviour {
    
    public RectTransform rectGate;
    public GameObject stamp;
    public Image BlackFade;
    public Animator anim;

    public float FadeInTime = 1.0f;
    float _FadeInTime = 1.0f;

    void OnAwake() {
        BlackFade.gameObject.SetActive(true);
        BlackFade.color = new Color(0, 0, 0, 1.0f);
    }
    public void OnStart() {
        GameController.Instance.player = null;
        _FadeInTime = FadeInTime;
    }

    public void OnDestroy() {        
    }

    void Update(){

        if (_FadeInTime > 0) {
            if (!BlackFade.IsActive())
                BlackFade.gameObject.SetActive(true);
            BlackFade.color = new Color(0, 0, 0, _FadeInTime / FadeInTime);
            _FadeInTime -= Time.deltaTime;
        } else {
            if(BlackFade.IsActive())
                BlackFade.gameObject.SetActive(false);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)) {
            anim.SetBool("open_all", true);
        }
        else
        {
            anim.SetBool("open_all", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("open_half", true);
        }
        else
        {
            anim.SetBool("open_half", false);
        }

    }

    public void ShowStamp() {
        stamp.SetActive(true);
    }

}
