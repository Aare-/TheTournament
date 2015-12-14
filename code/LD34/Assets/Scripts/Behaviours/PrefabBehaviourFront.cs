using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class PrefabBehaviourFront : PrefabBehaviour {
    protected override void InitPrefabs() {
        base.InitPrefabs();

        foreach (GameObject g in _InstantiatedPrefabs) {
            g.transform.SetAsLastSibling();
        }
    }

    protected override void DestroyPrefabs() {
        base.DestroyPrefabs();

    }
}
