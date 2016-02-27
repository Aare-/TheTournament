using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Fadeable : MonoBehaviour {
    [Header("Fade out/ in")]
    public Image BlackFade;
    public float FadeOutTime = 0.5f;
    public float FadeInTime = 0.5f;

    float _FadeOutTime = 0.0f;
    float _FadeInTime = 0.0f;

    protected virtual void Update() {
        if (_FadeOutTime > 0.0f) {
            if (!BlackFade.gameObject.activeSelf)
                BlackFade.gameObject.SetActive(true);
            _FadeOutTime -= Time.deltaTime;
            BlackFade.color = new Color(0, 0, 0, _FadeOutTime / FadeOutTime);
        } else if (_FadeInTime > 0.0f) {
            if (!BlackFade.gameObject.activeSelf)
                BlackFade.gameObject.SetActive(true);
            _FadeInTime -= Time.deltaTime;
            BlackFade.color = new Color(0, 0, 0, (1.0f - _FadeInTime / FadeInTime));
        } /*else {
            if (BlackFade.gameObject.activeSelf)
                BlackFade.gameObject.SetActive(false);
        }*/
    }
    protected void StartFadeIn() {
        _FadeInTime = FadeInTime;
    }
    protected void StartFadeOut() {
        _FadeOutTime = FadeOutTime;
    }
}

