using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class PrefabBehaviour : StateMachineBehaviour {
    public List<string> PrefabsToLoad = new List<string>();
    List<GameObject> _InstantiatedPrefabs;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        InitPrefabs();
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateExit(animator, stateInfo, layerIndex);

        DestroyPrefabs();
    }

    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash) {
        base.OnStateMachineEnter(animator, stateMachinePathHash);

        InitPrefabs();
    }
    public override void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
        base.OnStateMachineExit(animator, stateMachinePathHash);

        DestroyPrefabs();
    }

    protected virtual void InitPrefabs() {
        Debug.Log("Initing Prefabs: ");
        _InstantiatedPrefabs = new List<GameObject>();
        foreach (string s in PrefabsToLoad) {
            Debug.Log(" - " + s);

            GameObject o = GameController.Instance.InstantiateResource(s);
            _InstantiatedPrefabs.Add(o);
        }
    }
    protected virtual void DestroyPrefabs() {
        Debug.Log("Destroying prefabs");
        foreach (GameObject o in _InstantiatedPrefabs) {
            GameController.Instance.DestroyResource(o);
        }
        _InstantiatedPrefabs.Clear();
    }
}
