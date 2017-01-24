using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class ArenaManager : MonoBehaviour {
    public static int RoundCounter;

    [Header("Game Objecct Link")]
    public GladiatorHolder AllyGladiatorHolder;
    public GladiatorHolder OpponenetGladiatorHolder;

    public void Awake() {
        RoundCounter = 0;

        AllyGladiatorHolder.LoadGladiator(GameController.Instance.player.FightingGladiator);
        OpponenetGladiatorHolder.LoadGladiator(GameController.Instance.player.Opponent);
    }
    public void Start() {
        
        TinyTokenManager.Instance.Register<Msg.GladiatorDefeated>("ARENA_MANAGER" + GetInstanceID() + "DEFEATED",
            (m) => {                
                Destroy(AllyGladiatorHolder.gameObject);
                Destroy(OpponenetGladiatorHolder.gameObject);
            });
    }
    public void OnDestroy() {
        TinyTokenManager.Instance.Unregister<Msg.GladiatorDefeated>("ARENA_MANAGER" + GetInstanceID() + "DEFEATED");
    }
}
