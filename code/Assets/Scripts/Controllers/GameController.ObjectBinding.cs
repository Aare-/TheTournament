using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public partial class GameController : Singleton<GameController> {
    [Header("Object Bindings")]
    public GameObject PrefabsContainer;

    public GameObject InstantiateResource(string resourceId) {
        GameObject o = (GameObject)Instantiate(Resources.Load(resourceId));
        o.transform.SetParent(PrefabsContainer.transform, false);
        o.transform.localPosition = Vector3.zero;
        o.transform.SetAsFirstSibling();

        return o;
    }
    public void DestroyResource(GameObject o) {
        Destroy(o);
    }
}
