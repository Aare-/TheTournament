using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChoosingTactics : MonoBehaviour {

    [Header("Links to the prefabs")]
    public ActionDetails _ActionDetailItem;

    public Text RerollsCounter;
    public Text Description;
    public GridLayoutGroup ListOfSkills;

    public float LaunchFightTime = 0.5f;

    int rerolled;
    bool roolInProgress = false;

    protected void OnAwake() {

    }
    protected void Start() {
        Description.text = "Press left or right to re-roll actions again.";
        rerolled = GameController.Instance.TacticRerolls;

        TinyTokenManager.Instance.Register<Msg.LeftPressed>("CHOOSING_TACTICS" + GetInstanceID() + "LEFT_PRESSED",
            (m) => {
                if (roolInProgress) return;
                Roll();
            });
        TinyTokenManager.Instance.Register<Msg.RightPressed>("CHOOSING_TACTICS" + GetInstanceID() + "RIGHT_PRESSED",
            (m) => {
                if (roolInProgress) return;
                Roll();
            });
        TinyTokenManager.Instance.Register<Msg.SelectPerformed>("CHOOSING_TACTICS" + GetInstanceID() + "SELECT_PERFORMED",
            (m) => {
                if (roolInProgress) return;
                roolInProgress = true;

                StartCoroutine(LaunchFight());
            });
        Roll();
        GameController.Instance.SetStateInt(GameController.FIGHT_RESOLVED, 4);
    }
    void OnDestroy() {
        Unsubscribe();
    }
    void Unsubscribe() {
        TinyTokenManager.Instance.Unregister<Msg.LeftPressed>("CHOOSING_TACTICS" + GetInstanceID() + "LEFT_PRESSED");
        TinyTokenManager.Instance.Unregister<Msg.RightPressed>("CHOOSING_TACTICS" + GetInstanceID() + "RIGHT_PRESSED");
        TinyTokenManager.Instance.Unregister<Msg.SelectPerformed>("CHOOSING_TACTICS" + GetInstanceID() + "SELECT_PERFORMED");
    }
    void Roll() {
        roolInProgress = true;
        rerolled--;
        RerollsCounter.text = (rerolled + 1) + "/" + GameController.Instance.TacticRerolls;

        GameController.Instance.player.FightingGladiator.GetNewAttackQueue();
        ListOfSkills.gameObject.DeleteAllChildreen();
        List<ActiveAbility> abilities = GameController.Instance.player.FightingGladiator.AttackQueue;

        int i = 0;
        foreach (ActiveAbility a in abilities) {
            ActionDetails c = (ActionDetails)Instantiate(_ActionDetailItem);
            c.SetAbility(a);
            c.transform.SetParent(ListOfSkills.transform, false);


            c.gameObject.SetActive(false);
            StartCoroutine(PopUp(c.gameObject, 0.25f + i * 0.05f, i >= abilities.Count - 1));

            i++;
        }
    }
    IEnumerator PopUp(GameObject what, float delta, bool enableInput) {
        yield return new WaitForSeconds(delta);
        what.SetActive(true);
        if (enableInput) {
            
            if (rerolled <= 0) {
                Unsubscribe();
                Description.text = "Starting fight...";
                RerollsCounter.gameObject.SetActive(false);

                yield return new WaitForSeconds(LaunchFightTime);

                roolInProgress = false;
                GameController.Instance.SetStateInt(GameController.FIGHT_RESOLVED, 0);
                GameController.Instance.EnableTrigger(GameController.TRIGGER_SELECT);
            } else {
                roolInProgress = false;
            }
        }
    }
    IEnumerator LaunchFight() {
        Unsubscribe();
        Description.text = "Starting fight...";
        RerollsCounter.gameObject.SetActive(false);

        yield return new WaitForSeconds(LaunchFightTime);        
        
        GameController.Instance.SetStateInt(GameController.FIGHT_RESOLVED, 0);
        GameController.Instance.EnableTrigger(GameController.TRIGGER_SELECT);
    }
    protected void OnDisable() {

    }

    protected void OnUpdate() {

    }
}
