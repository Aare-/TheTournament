using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyInfo : MonoBehaviour {

    public GameObject AvatarContainer;
    public Text Name;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetGladiatorInfo(Gladiator info) {
        Name.text = info.Name;
    }
}
