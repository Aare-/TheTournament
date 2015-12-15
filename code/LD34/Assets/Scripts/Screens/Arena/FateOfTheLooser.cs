using UnityEngine;
using System.Collections;

public class FateOfTheLooser : MonoBehaviour {

    public GameObject LooserContainer;

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
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
