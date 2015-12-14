using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

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

        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in AvatarContainer.transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));

        GameObject o = (GameObject)Instantiate(GameController.Instance.GetPrefabForGladiator(g));
        o.transform.SetParent(AvatarContainer.transform, false);
        RectTransform r = o.GetComponent<RectTransform>();
        o.transform.localPosition = new Vector3(-28, -32, 0);
    }
}
