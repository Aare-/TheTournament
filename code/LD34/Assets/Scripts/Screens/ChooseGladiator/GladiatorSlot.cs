using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GladiatorSlot : MonoBehaviour {

    public bool isSelectedOnStart;
    public GameObject selectBackground;    

    public GameObject AvatarHolder;
    public Text name;

	// Use this for initialization
	void Start () {
        if (isSelectedOnStart)
            selectBackground.SetActive(true);
        else
            selectBackground.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SelectGladiator() {
        selectBackground.SetActive(true);
    }

    public void DeselectGladiator() {
        selectBackground.SetActive(false);
    }

    public void FillWithGladiatorDetails(Gladiator g) {
        if (g == null) {
            name.text = "";
            selectBackground.SetActive(false);
            foreach (Transform child in AvatarHolder.transform) {
                GameObject.Destroy(child.gameObject);
            }
        } else {
            name.text = g.Name;

            List<GameObject> children = new List<GameObject>();
            foreach (Transform child in AvatarHolder.transform) children.Add(child.gameObject);
            children.ForEach(child => Destroy(child));

            GameObject o = (GameObject)Instantiate(GameController.Instance.GetPrefabForGladiator(g));
            o.transform.SetParent(AvatarHolder.transform, false);            
            o.transform.localPosition = new Vector3(-4, 10, 0);
            o.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }
    }

}
