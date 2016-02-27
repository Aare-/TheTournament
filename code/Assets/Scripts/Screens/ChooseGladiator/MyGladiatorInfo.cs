using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MyGladiatorInfo : MonoBehaviour {

    [Header("Links to the prefabs")]
    public ActionDetails _ActionDetailItem;

    [Header("Game Objects")]
    public GameObject AvatarContainer;
    public GridLayoutGroup SkillsList;
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

        SkillsList.gameObject.DeleteAllChildreen();
        #region Loading Passive abilities list
        foreach (PassiveAbility p in g.PassiveAbilities) {
            ActionDetails c = (ActionDetails)Instantiate(_ActionDetailItem);
            c.SetAbility(p);
            c.transform.SetParent(SkillsList.transform, false);
        }
        #endregion

        #region Loading Active abilities list
        foreach (ActiveAbility ac in g.ActiveAbilities) {
            ActionDetails c = (ActionDetails)Instantiate(_ActionDetailItem);
            c.SetAbility(ac);
            c.transform.SetParent(SkillsList.transform, false);
        }
        #endregion
    }
}
