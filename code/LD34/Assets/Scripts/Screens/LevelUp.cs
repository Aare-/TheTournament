using UnityEngine;
using System.Collections;
using TinyMessenger;
using UnityEngine.UI;

public class LevelUp : Fadeable {

    [Header("Prefab Links")]
    public ActionDetails _AbilityHolder;

    [Header("GameObjects")]
    public GameObject CharacterHolder;
    public GridLayoutGroup NewSKill;
    public GridLayoutGroup OldSkills;

    GladiatorController oldGC;
    bool levelProgress = false;

	// Use this for initialization
	void Start () {        

        TinyTokenManager.Instance.Register<Msg.UpgradeFinished>("LEVEL_UP" + GetInstanceID() + "FIN", (m) => {
            TinyTokenManager.Instance.Unregister<Msg.UpgradeFinished>("LEVEL_UP" + GetInstanceID() + "FIN");

            Destroy(oldGC.gameObject);

            if (levelProgress) {
                GameController.Instance.player.FightingGladiator.Level++;

                Gladiator g2 = GameController.Instance.player.FightingGladiator;
                GladiatorController c = Instantiate(GameController.Instance.GetPrefabForGladiator(g2)).GetComponent<GladiatorController>();
                c.Id = g2._Id;
                c.gameObject.transform.position = new Vector3(0, 110, 0);

                c.transform.SetParent(CharacterHolder.transform, false);
                c.SwitchState(GladiatorController.AnimationState.Idle);
            }

            TinyMessengerHub.Instance.Publish<Msg.HideArrowKeys>(new Msg.HideArrowKeys(false));
            TinyTokenManager.Instance.Register<Msg.SelectPerformed>("LEVEL_UP" + GetInstanceID() + "SELECT", (msg) => {
                Unregister();
                StartCoroutine(Finish());
            });
        });

        if (GameController.Instance.player.FightingGladiator.LastLevelUpedAbility.Level > GameController.Instance.player.FightingGladiator.Level) {
            levelProgress = true;
        }

        #region Creating Gladiator
        Gladiator g = GameController.Instance.player.FightingGladiator;
        oldGC = Instantiate(GameController.Instance.GetPrefabForGladiator(g)).GetComponent<GladiatorController>();
        oldGC.gameObject.transform.position = new Vector3(0, 110, 0);
        oldGC.Id = g._Id;
        
        oldGC.transform.SetParent(CharacterHolder.transform, false);
        if (levelProgress) {
            oldGC.SwitchState(GladiatorController.AnimationState.Upgrade);
        } else {
            oldGC.SwitchState(GladiatorController.AnimationState.Idle);
        }
        #endregion

        ActionDetails ab = (ActionDetails)Instantiate(_AbilityHolder);
        ab.transform.SetParent(NewSKill.transform, false);
        ab.SetAbility(GameController.Instance.player.FightingGladiator.LastLevelUpedAbility);

        foreach (ActiveAbility a in GameController.Instance.player.FightingGladiator.EvolvedAbilities) {
            ActionDetails abb = (ActionDetails)Instantiate(_AbilityHolder);
            abb.transform.SetParent(OldSkills.transform, false);
            abb.SetAbility(a);
        }

        GameController.Instance.player.FightingGladiator.LastLevelUpedAbility = null;

        TinyMessengerHub.Instance.Publish<Msg.HideArrowKeys>(new Msg.HideArrowKeys(true));

        if (!levelProgress) {
            TinyMessengerHub.Instance.Publish<Msg.UpgradeFinished>(new Msg.UpgradeFinished());
        }
    }
    void Unregister() {
        TinyTokenManager.Instance.Unregister<Msg.UpgradeFinished>("LEVEL_UP" + GetInstanceID() + "FIN");
        TinyTokenManager.Instance.Unregister<Msg.SelectPerformed>("LEVEL_UP" + GetInstanceID() + "SELECT");
    }

    IEnumerator Finish() {        

        StartFadeIn();
        yield return new WaitForSeconds(0.5f);

        GameController.Instance.EnableTrigger("upgradeFinished");
    }
}
