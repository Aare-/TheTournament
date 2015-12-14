using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class IntroPrefabBehaviour : PrefabBehaviour{
    public List<string> DisableOnEnter;
    GameObject controls;

    protected override void InitPrefabs() {
        base.InitPrefabs();

        controls = GameObject.FindGameObjectWithTag("Controls");
        controls.SetActive(false);
    }
    protected override void DestroyPrefabs() {
        base.DestroyPrefabs();
        controls.SetActive(true);
    }

    /*virtual void InitPrefabs() {
        Debug.Log("Initing Prefabs: ");
        _InstantiatedPrefabs = new List<GameObject>();
        foreach (string s in PrefabsToLoad) {
            Debug.Log(" - " + s);

            GameObject o = GameController.Instance.InstantiateResource(s);
            _InstantiatedPrefabs.Add(o);
        }
    }
    virtual void DestroyPrefabs() {
        Debug.Log("Destroying prefabs");
        foreach (GameObject o in _InstantiatedPrefabs) {
            GameController.Instance.DestroyResource(o);
        }
        _InstantiatedPrefabs.Clear();
    }*/
}
