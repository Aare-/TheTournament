using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyMessenger;
using UnityEngine;

class FightMode : MonoBehaviour {

    public AttacksManager OpponentAttacksManager;
    public AttacksManager AllyAttacksManager;

    public void Awake() {

    }

    public void Start() {
        AllyAttacksManager.LoadAttacks(GameController.Instance.player.FightingGladiator);
        OpponentAttacksManager.LoadAttacks(GameController.Instance.player.Opponent);

        GameController.Instance.SetStateInt(GameController.FIGHT_RESOLVED, 0);


        TinyTokenManager.Instance.Register<Msg.RightPressed>("FIGHT_MODE" + GetInstanceID() + "RIGHT_PRESSED", (m) => { 
            StartCoroutine(DoFightStep()); 
        });
        TinyTokenManager.Instance.Register<Msg.LeftPressed>("FIGHT_MODE" + GetInstanceID() + "LEFT_PRESSED", (m) => {
            StartCoroutine(DoFightStep()); 
        });
        TinyMessengerHub.Instance.Publish<Msg.HideOneArrowKey>(new Msg.HideOneArrowKey(-1, true));
    }

    IEnumerator  DoFightStep() {
        TinyMessengerHub.Instance.Publish<Msg.PrepareToPerformAttack>(new Msg.PrepareToPerformAttack());
        TinyMessengerHub.Instance.Publish<Msg.PerformAttack>(new Msg.PerformAttack());        

        if (GameController.Instance.player.FightingGladiator.Life <= 0) {
            Unregister();

            yield return new WaitForSeconds(0.2f);

            TinyMessengerHub.Instance.Publish<Msg.GladiatorDefeated>(new Msg.GladiatorDefeated(GameController.Instance.player.FightingGladiator._Id));
            GameController.Instance.SetStateInt(GameController.FIGHT_RESOLVED, 1);
            
        } else if (GameController.Instance.player.Opponent.Life <= 0) {
            Unregister();

            yield return new WaitForSeconds(0.2f);

            TinyMessengerHub.Instance.Publish<Msg.GladiatorDefeated>(new Msg.GladiatorDefeated(GameController.Instance.player.Opponent._Id));
            GameController.Instance.SetStateInt(GameController.FIGHT_RESOLVED, 2);

            
        } else if (!OpponentAttacksManager.HasNextAttack() && !AllyAttacksManager.HasNextAttack()) {
            Unregister();

            yield return new WaitForSeconds(0.2f);
            
            GameController.Instance.SetStateInt(GameController.FIGHT_RESOLVED, 3);
        } else {
            yield return new WaitForSeconds(0.5f);
        }
    }

    void Unregister() {
        TinyTokenManager.Instance.Unregister<Msg.RightPressed>("FIGHT_MODE" + GetInstanceID() + "RIGHT_PRESSED");
        TinyTokenManager.Instance.Unregister<Msg.LeftPressed>("FIGHT_MODE" + GetInstanceID() + "LEFT_PRESSED");
    }
    public void OnDisable() {
        Unregister();
        TinyMessengerHub.Instance.Publish<Msg.HideOneArrowKey>(new Msg.HideOneArrowKey(-1, false));
    }
}
