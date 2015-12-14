using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChoosingTactics : MonoBehaviour {

    [Header("Links to the prefabs")]
    public ActionDetails _ActionDetailItem;

    public Text RerollsCounter;
    public GridLayoutGroup ListOfSkills;

    protected void OnAwake() {

    }
    protected void Start() {
        RerollsCounter.text = (GameController.Instance.GetStateInt(GameController.REROLLS_COUNT) + 1) + "/" + GameController.Instance.TacticRerolls;

        GameController.Instance.player.FightingGladiator.GetNewAttackQueue();
        ListOfSkills.gameObject.DeleteAllChildreen();
        List<ActiveAbility> abilities = GameController.Instance.player.FightingGladiator.AttackQueue;

        int i = 0;
        foreach (ActiveAbility a in abilities) {
            ActionDetails c = (ActionDetails)Instantiate(_ActionDetailItem);
            c.SetAbility(a);
            c.transform.SetParent(ListOfSkills.transform, false);


            c.gameObject.SetActive(false);
            StartCoroutine(PopUp(c.gameObject, 0.25f + i * 0.05f));
                
            i++;
        }
    }
    IEnumerator PopUp(GameObject what, float delta) {
        yield return new WaitForSeconds(delta);
        what.SetActive(true);
    }
    protected void OnDisable() {

    }

    protected void OnUpdate() {

    }
}
