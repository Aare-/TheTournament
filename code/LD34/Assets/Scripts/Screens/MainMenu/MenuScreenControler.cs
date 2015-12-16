using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TinyMessenger;

public class MenuScreenControler : Fadeable {
    
    public RectTransform rectGate;
    public GameObject stamp;    
    public Animator anim;
    bool started = false;

    void Awake() {
    }
    public void Start() {
        GameController.Instance.player = null;
        StartFadeOut();
    }

    public void OnDestroy() {        
    }

    protected void Update() {
        base.Update();

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)) {
            anim.SetBool("open_all", true);

            if (!started) {
                started = true;
                StartCoroutine(StartGame());
            }
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

    IEnumerator StartGame() {                            
        StartFadeIn();

        yield return new WaitForSeconds(0.5f);

        GameController.Instance.player = new Player();
        TinyMessengerHub.Instance.Publish<Msg.StartNewGame>(new Msg.StartNewGame());

        GameController.Instance.EnableTrigger("startGame");
        GameController.Instance.SetStateBool("game_over", false);
    }
}
