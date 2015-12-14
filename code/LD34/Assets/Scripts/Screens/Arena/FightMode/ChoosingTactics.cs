using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChoosingTactics : MonoBehaviour {

    public Text RerollsCounter;

    protected void OnAwake() {

    }
    protected void Start() {
        RerollsCounter.text = (GameController.Instance.GetStateInt(GameController.REROLLS_COUNT) + 1) + "/" + GameController.Instance.TacticRerolls;
    }
    protected void OnDisable() {

    }
}
