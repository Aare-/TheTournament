using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class EnemyInfo : MonoBehaviour {

    [Header("Link to the prefabs")]
    public ActionSmallIcon AbilityIconPrefab;

    [Header("Link to the gameobjects")]
    public GameObject AbilityPrefabContainer;
    public GameObject AvatarContainer;
    public GameObject AbilitiesList;
    public Text Name;
    public Text Health;
    public Text Adr;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetGladiatorInfo(Gladiator info) {
        Name.text = info.Name;
        Health.text = "HP: " + info.BaseLife;
        Adr.text = "ADR: " + info.BaseAdrenaline;

        #region Setting Avatar
        AvatarContainer.DeleteAllChildreen();

        GameObject o = (GameObject)Instantiate(GameController.Instance.GetPrefabForGladiator(info));
        o.transform.SetParent(AvatarContainer.transform, false);
        RectTransform r = o.GetComponent<RectTransform>();
        o.transform.localPosition = new Vector3(-28, -32, 0);
        #endregion

        #region Setting ability list
        AbilitiesList.DeleteAllChildreen();

        foreach (PassiveAbility p in info.PassiveAbilities) {
            ActionSmallIcon c = (ActionSmallIcon)Instantiate(AbilityIconPrefab);
            c.SetAbility(p);
            c.transform.SetParent(AbilitiesList.transform, false);            
        }
        foreach (ActiveAbility a in info.ActiveAbilities) {
            ActionSmallIcon c = (ActionSmallIcon)Instantiate(AbilityIconPrefab);
            c.SetAbility(a);
            c.transform.SetParent(AbilitiesList.transform, false);            
        }

        #endregion

    }
}
