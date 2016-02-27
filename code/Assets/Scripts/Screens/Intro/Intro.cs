using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;


public class Intro : MonoBehaviour {

	public List<Text> labels;
    public List<string> roles;	
	public List<string> twitters;	
	public float animationTime;
	private float animationProcess = 2.0f;

    char[] ALPHABET = new char[]{'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'y', 'z', '@', '%', '$', '&', '#'};

    [Header("Animation Times")]
    public float FadeInTime = 0.5f;
    public float RolesTime = 2.0f;
    public float AnimateTime = 1.0f;
    public float NamesTime = 3.0f;
    public float CharacterChangeTime = 0.25f;
    public float FadeOutTime = 1.0f;

    private bool finished = false;

    private float _FadeInTime;
    private float _RolesTime;
    private float _AnimateTime;
    private float _NamesTime;
    private float _FadeOutTime;

    private float _CharacterChangeTime;
	
	void Start () {
        _FadeInTime = FadeInTime;
        _RolesTime = RolesTime;
        _AnimateTime = AnimateTime;
        _NamesTime = NamesTime;
        _FadeOutTime = FadeOutTime;
	}

	void Update () {
        if (_FadeInTime > 0.0f) {
            _FadeInTime -= Time.deltaTime;
            int i =0 ;
            foreach (Text t in labels) {
                t.text = roles[i];
                t.color = new Color(1.0f, 1.0f, 1.0f, (1.0f - (_FadeInTime / FadeInTime)));
                i++;
            }

        } else if (_RolesTime > 0.0f) {
            _RolesTime -= Time.deltaTime;

        } else if (_AnimateTime > 0.0f) {
            _AnimateTime -= Time.deltaTime;
            _CharacterChangeTime += Time.deltaTime;

                     
            while (_CharacterChangeTime >= CharacterChangeTime) {
                _CharacterChangeTime -= CharacterChangeTime;
                int i = 0;   
                foreach (Text t in labels) {
                    t.text = AnimateText(roles[i], twitters[i], (1.0f - (_AnimateTime / AnimateTime)));
                    i++;
                }
            }

        } else if (_NamesTime > 0.0f) {
            _NamesTime -= Time.deltaTime;

            int i = 0;
            foreach (Text t in labels) {
                t.text = twitters[i];
                i++;
            }
        } else if (_FadeOutTime > 0.0f) {
            _FadeOutTime -= Time.deltaTime;
            int i = 0;
            foreach (Text t in labels) {
                t.text = twitters[i];
                t.color = new Color(1.0f, 1.0f, 1.0f, ((_FadeOutTime / FadeOutTime)));
                i++;
            }

        } else {
            if (!finished) {
                finished = true;
                GameController.Instance.EnableTrigger(GameController.TRIGGER_SELECT);
            }
        }
	}

    string AnimateText(string from, string to, float time) {
        time = Mathf.Clamp01(time);
        if (time == 0.0f)
            return from;
        if (time == 1.0f)
            return to;

        string result = "";
        int len = (int)Math.Round(from.Length + ((float)(to.Length - from.Length) * time));
        result = "";

        for (int i = 0; i < len; i++)
            result += ALPHABET[UnityEngine.Random.Range(0, ALPHABET.Length)];
            
        return result;
    }
}
