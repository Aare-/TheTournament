using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

        }
    }

}
