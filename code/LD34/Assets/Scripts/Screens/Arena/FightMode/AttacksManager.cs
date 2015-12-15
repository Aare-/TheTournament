using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using TinyMessenger;

public class AttacksManager : MonoBehaviour {

    [Header("Prefabs Connections")]
    public ActionSmallIcon _QueuedActions; 


    [Header("Game Objects")]
    public Text AttackName;
    public ActionSmallIcon AttackIcon;
    public GridLayoutGroup AttackQueue;

    List<ActiveAbility> _ActionsCache;
    int _MyId;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadAttacks(Gladiator g) {
        _ActionsCache = g.AttackQueue;
        _MyId = g._Id;

        PushActionToQueue(_ActionsCache);
    }
    void PushActionToQueue(List<ActiveAbility> cachedActiona) {
        AttackQueue.gameObject.DeleteAllChildreen();        

        foreach (ActiveAbility a in cachedActiona) {
            ActionSmallIcon action = Instantiate(_QueuedActions);
            action.SetAbility(a);

            action.transform.SetParent(AttackQueue.transform, false);
        }
    }
    public void PreparextAttack() {
        if (HasNextAttack()) {
            
        }
    }
    public void NextAttack() {
        if (HasNextAttack()) {
            AttackIcon.gameObject.SetActive(true);

            ActiveAbility a = _ActionsCache[0];
            _ActionsCache.Remove(a);
            Destroy(AttackQueue.transform.GetChild(0).gameObject);            

            AttackIcon.SetAbility(a);
            AttackName.text = a.Name;
            
        } else {
            AttackIcon.gameObject.SetActive(false);
        }
    }
    public bool HasNextAttack() {
        return _ActionsCache.Count > 0;
    }
}
