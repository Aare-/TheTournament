using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PrefabBehaviour : StateMachineBehaviour {
    public List<string> PrefabsToLoad = new List<string>();
    protected List<GameObject> _InstantiatedPrefabs;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        //Debug.Log("ENTER!");
        GameController.Instance.BlockInput++;
        InitPrefabs();
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateExit(animator, stateInfo, layerIndex);

        //Debug.Log("EXIT!");
        GameController.Instance.BlockInput--;
        DestroyPrefabs();
    }  

    protected virtual void InitPrefabs() {
        DestroyPrefabs();

        _InstantiatedPrefabs = new List<GameObject>();
        foreach (string s in PrefabsToLoad) {

            GameObject o = GameController.Instance.InstantiateResource(s);
            _InstantiatedPrefabs.Add(o);            
        }        
    }
    protected virtual void DestroyPrefabs() {        

        GameController.Instance.ClearAllTriggers();

        if (_InstantiatedPrefabs != null) {
            foreach (GameObject o in _InstantiatedPrefabs) {
                GameObject.Destroy(o);
            }
            _InstantiatedPrefabs.Clear();
        }
    }
}
