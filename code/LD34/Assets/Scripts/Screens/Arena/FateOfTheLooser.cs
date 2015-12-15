using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FateOfTheLooser : MonoBehaviour {

    public GameObject LooserContainer;
    public Text FreeSlot;

	// Use this for initialization
	void Start () {
        Gladiator g = GameController.Instance.player.Opponent;
        GladiatorController c = Instantiate(GameController.Instance.GetPrefabForGladiator(g)).GetComponent<GladiatorController>();
        c.gameObject.transform.position = new Vector3(0, 40, 0);
        c.Id = g._Id;
        if (g._Id == GameController.Instance.player.Opponent._Id) {
            c.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        c.transform.SetParent(LooserContainer.transform, false);
        c.SwitchState(GladiatorController.AnimationState.Kneeling);

        if (GameController.Instance.player.CanAddToParty()) {
            FreeSlot.gameObject.SetActive(false);
        } else {
            FreeSlot.gameObject.SetActive(true);
        }

        TinyTokenManager.Instance.Register<Msg.LeftPressed>("FATE_OF_THE_LOOSER" + GetInstanceID() + "LEFT",
            (m) => {
                if (GameController.Instance.player.CanAddToParty()) {
                    GameController.Instance.EnableTrigger(GameController.TRIGGER_FATE_SPARE);
                }
            });
        TinyTokenManager.Instance.Register<Msg.RightPressed>("FATE_OF_THE_LOOSER" + GetInstanceID() + "RIGHT",
            (m) => {
                GameController.Instance.EnableTrigger(GameController.TRIGGER_FATE_KILL);
            });
	}
    void OnDestroy() {
        TinyTokenManager.Instance.Unregister<Msg.LeftPressed>("FATE_OF_THE_LOOSER" + GetInstanceID() + "LEFT");
        TinyTokenManager.Instance.Unregister<Msg.RightPressed>("FATE_OF_THE_LOOSER" + GetInstanceID() + "RIGHT");
    }	
}
