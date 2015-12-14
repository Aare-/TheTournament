using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class ArenaManager : MonoBehaviour {

    [Header("Game Objecct Link")]
    public GladiatorHolder AllyGladiatorHolder;
    public GladiatorHolder OpponenetGladiatorHolder;

    public void Awake() {
        AllyGladiatorHolder.LoadGladiator(GameController.Instance.player.FightingGladiator);
        OpponenetGladiatorHolder.LoadGladiator(GameController.Instance.player.Opponent);
    }
    public void OnStart() {

    }
    public void OnDestroy() {

    }
}
