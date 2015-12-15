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
    public void Start() {
        Debug.Log("ARENA START!!!");
        TinyTokenManager.Instance.Register<Msg.GladiatorDefeated>("ARENA_MANAGER" + GetInstanceID() + "DEFEATED",
            (m) => {
                Debug.Log("ZWIJAM ZABAWKI");
                Destroy(AllyGladiatorHolder.gameObject);
                Destroy(OpponenetGladiatorHolder.gameObject);
            });
    }
    public void OnDestroy() {
        TinyTokenManager.Instance.Unregister<Msg.GladiatorDefeated>("ARENA_MANAGER" + GetInstanceID() + "DEFEATED");
    }
}
