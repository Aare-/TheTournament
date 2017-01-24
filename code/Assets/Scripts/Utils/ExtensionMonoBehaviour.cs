using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class ExtensionMonoBehaviour {
    public static GameObject GetGameObjectSafelly(this MonoBehaviour m, string path) {
        Transform t = m.transform.Find(path);
        if (t == null)
            throw new System.ArgumentException("Child not found", path);
        return t.gameObject;
    }
    public static GameObject GetFirstGameObjectStartingWithNameSafelly(this MonoBehaviour m, string prefix) {
        for (int i = 0; i < m.transform.childCount; i++) {
            Transform t = m.transform.GetChild(i);
            if (t.name.StartsWith(prefix))
                return t.gameObject;
        }

        throw new System.ArgumentException("Child not found", prefix);
    }
    public static List<GameObject> GetFirstGameObjectsStartingWithNameSafelly(this MonoBehaviour m, string prefix) {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < m.transform.childCount; i++) {
            Transform t = m.transform.GetChild(i);
            if (t.name.StartsWith(prefix))
                list.Add(t.gameObject);
        }

        if (list.Count == 0)
            throw new System.ArgumentException("Child not found", prefix);
        return list;
    }
}
