using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GladiatorSlot : MonoBehaviour {

    public bool isSelectedOnStart;
    public GameObject selectBackground;
    public int gladiatorID;

    public Image avatar;
    public Text name;

	// Use this for initialization
	void Start () {
        if (isSelectedOnStart)
            selectBackground.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SelectGladiator()
    {
        selectBackground.SetActive(true);
    }

    public void DeselectGladiator()
    {
        selectBackground.SetActive(false);
    }

}
