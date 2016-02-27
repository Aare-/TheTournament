using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyMessenger;
using UnityEngine;
using UnityEngine.UI;

public class Defeat : Fadeable {    

    [Header("Object bindings")]
    public GameObject LooserContainer;    
    public Text Stats;

    public Image CrusherLeft;
    public Image CrusherRight;    

    void Awake() {}
    void Start() {

        #region Loading character prefab
        Gladiator g = GameController.Instance.player.FightingGladiator;
        GladiatorController c = Instantiate(GameController.Instance.GetPrefabForGladiator(g)).GetComponent<GladiatorController>();
        c.gameObject.transform.position = new Vector3(0, 40, 0);
        c.Id = g._Id;
        if (g._Id == GameController.Instance.player.Opponent._Id) {
            c.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        c.transform.SetParent(LooserContainer.transform, false);
        c.SwitchState(GladiatorController.AnimationState.Kneeling);
        #endregion               
        
        Stats.text = "";

        TinyMessengerHub.Instance.Publish<Msg.HideArrowKeys>(new Msg.HideArrowKeys(true));        
        StartCoroutine(FateKill());
    }
    void Unregister() {
        TinyTokenManager.Instance.Unregister<Msg.LeftPressed>("DEFEAT" + GetInstanceID() + "LEFT");
        TinyTokenManager.Instance.Unregister<Msg.RightPressed>("DEFEAT" + GetInstanceID() + "RIGHT");
        TinyTokenManager.Instance.Unregister<Msg.SelectPerformed>("DEFEAT" + GetInstanceID() + "SELECTED");
    }
    void Crush() {

        iTween.MoveBy(CrusherRight.gameObject, new Vector3(-2.82f, 0), 0.5f);
        iTween.MoveBy(CrusherLeft.gameObject, new Vector3(2.82f, 0), 0.5f);
    }
    IEnumerator FateKill() {                

        yield return new WaitForSeconds(0.5f);
        Crush();
        yield return new WaitForSeconds(0.45f);
        Destroy(LooserContainer);
        yield return new WaitForSeconds(0.5f);

        GameController.Instance.player.RemoveFromParty(GameController.Instance.player.FightingGladiator);

        if (GameController.Instance.player.GetPartyLength() == 0) {
            Stats.text = "Game Over\nDefeated Opponents: " + GameController.Instance.player.NumberOfVictories;
            GameController.Instance.SetStateBool("game_over", true);

            TinyMessengerHub.Instance.Publish<Msg.GameOver>(new Msg.GameOver());            
        } else {
            Stats.text = "Gladiators left in party: " + GameController.Instance.player.GetPartyLength();
            GameController.Instance.SetStateBool("game_over", false);
        }

        yield return new WaitForSeconds(0.5f);
        TinyMessengerHub.Instance.Publish<Msg.HideArrowKeys>(new Msg.HideArrowKeys(false));

        TinyTokenManager.Instance.Register<Msg.SelectPerformed>("DEFEAT" + GetInstanceID() + "LEFT",
            (m) => {
                Unregister();
                StartCoroutine(EndScreen());
            });
    }
    IEnumerator EndScreen() {
        StartFadeIn();
        yield return new WaitForSeconds(0.5f);

        GameController.Instance.EnableTrigger("confirmedDefeat");
    }   
}