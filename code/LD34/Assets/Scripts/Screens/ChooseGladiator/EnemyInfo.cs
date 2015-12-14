using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

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

        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in AvatarContainer.transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));

        GameObject o = (GameObject)Instantiate(GameController.Instance.GetPrefabForGladiator(info));
        o.transform.SetParent(AvatarContainer.transform, false);
        RectTransform r = o.GetComponent<RectTransform>();
        o.transform.localPosition = new Vector3(-28, -32, 0);
        
    }
}
