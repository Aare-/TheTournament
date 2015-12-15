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
        TinyTokenManager.Instance.Register<Msg.PrepareToPerformAttack>("ATTACKS_MANAGER_" + GetInstanceID() + "PREPARE_TO_ATTACK",
            (m) => {
                if (HasNextAttack()) {
                    AttackIcon.gameObject.SetActive(true);
                    ActiveAbility a = _ActionsCache[0];
                    AttackIcon.SetAbility(a);
                    AttackName.text = a.Name;

                    Destroy(AttackQueue.transform.GetChild(0).gameObject);                    
                } else {
                    AttackIcon.gameObject.SetActive(false);
                }
            });
        TinyTokenManager.Instance.Register<Msg.PerformAttack>("ATTACKS_MANAGER_" + GetInstanceID() + "PERFORM_ATTACK",
            (m) => {
                
            });
	}
    void OnDestroy() {
        TinyTokenManager.Instance.Unregister<Msg.PrepareToPerformAttack>("ATTACKS_MANAGER_" + GetInstanceID() + "PREPARE_TO_ATTACK");
        TinyTokenManager.Instance.Unregister<Msg.PerformAttack>("ATTACKS_MANAGER_" + GetInstanceID() + "PERFORM_ATTACK");
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
    public bool HasNextAttack() {
        return _ActionsCache.Count > 0;
    }
}