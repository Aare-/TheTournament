using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Help : Fadeable {

    public List<GameObject> _TutParts;
    int tutPos = 0;

    void Awake() {
        foreach (GameObject o in _TutParts) {
            o.SetActive(false);
        }
    }

	void Start () {
        
        GameController.Instance.SetStateBool(GameController.FIRST_GAME, false);

        TinyTokenManager.Instance.Register<Msg.SelectPerformed>("HALP_" + GetInstanceID(), (m) => {
            if (tutPos >= _TutParts.Count) {
                StartCoroutine(Finish());
                return;
            }

            _TutParts[tutPos].SetActive(true);
            tutPos++;            
        });

        StartFadeOut();
	}
    IEnumerator Finish() {
        StartFadeIn();
        yield return new WaitForSeconds(0.5f);

        GameController.Instance.EnableTrigger("tutFinished");
    }
    void OnDestroy() {
        
    }		
}
