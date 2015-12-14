using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class TacticsRerollsBehaviour : PrefabBehaviourFront {
    protected override void InitPrefabs() {
        base.InitPrefabs();
        
        if (GameController.Instance.GetStateInt(GameController.REROLLS_COUNT) < 0) {
            GameController.Instance.SetStateInt(GameController.REROLLS_COUNT, GameController.Instance.TacticRerolls);
        }

        GameController.Instance.SetStateInt(GameController.REROLLS_COUNT, GameController.Instance.GetStateInt(GameController.REROLLS_COUNT) - 1);        
    }

    protected override void DestroyPrefabs() {
        base.DestroyPrefabs();

    }
}
