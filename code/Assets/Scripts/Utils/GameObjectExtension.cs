using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public static class GameObjectExtension {
    public static void DeleteAllChildreen(this GameObject obj) {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in obj.transform) children.Add(child.gameObject);
        children.ForEach(child => GameObject.Destroy(child));
    }
}

