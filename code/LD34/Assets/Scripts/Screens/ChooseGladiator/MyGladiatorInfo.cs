using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyGladiatorInfo : MonoBehaviour {

    public GameObject AvatarContainer;
    public Text name;
    public Text level;
    public Text adrenaline;
    public Text health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FillWithGladiatorDetails(Gladiator g) {
        name.text = g.Name;
        level.text = "LVL: " + g.Level;
        adrenaline.text = "ADR: " + g.BaseAdrenaline;
        health.text = "HP: " + g.BaseLife;
    }
}
