using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class IntroPrefabBehaviour : PrefabBehaviour {
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
}
