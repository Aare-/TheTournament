using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        StartCoroutine(ResolvingFight());
    }

    public void OnDisable() {

    }

    IEnumerator ResolvingFight() {        

        while (true) {            
            OpponentAttacksManager.PreparextAttack();
            AllyAttacksManager.PreparextAttack();

            yield return new WaitForSeconds(0.1f);
            
            OpponentAttacksManager.NextAttack();
            AllyAttacksManager.NextAttack();

            yield return new WaitForSeconds(0.7f);

            if (GameController.Instance.player.FightingGladiator.Life <= 0) {
                GameController.Instance.SetStateInt(GameController.FIGHT_RESOLVED, 1);

                break;
            }
            if (GameController.Instance.player.Opponent.Life <= 0) {
                GameController.Instance.SetStateInt(GameController.FIGHT_RESOLVED, 2);

                break;
            }
            if (!OpponentAttacksManager.HasNextAttack() && !AllyAttacksManager.HasNextAttack()) {
                GameController.Instance.SetStateInt(GameController.FIGHT_RESOLVED, 3);

                break;
            }
        }

    }
}
