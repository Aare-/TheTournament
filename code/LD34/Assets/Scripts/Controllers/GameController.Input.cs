using UnityEngine;
using System.Collections;
using TinyMessenger;

public partial class GameController : Singleton<GameController> {

    public int BlockInput = 0;

    private bool left;
    private bool right;
    private bool isPressed = false;

    void Update () {
        if (BlockInput > 1) {          
            return;
        }
        
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            TinyMessengerHub.Instance.Publish<Msg.ArrowClicked>(new Msg.ArrowClicked(-1));
            left = true;
            GameController.Instance.EnableTrigger(GameController.TRIGGER_LEFT);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            TinyMessengerHub.Instance.Publish<Msg.ArrowReleased>(new Msg.ArrowReleased(-1));
            left = false;            
            GameController.Instance.ClearAllTriggers();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            TinyMessengerHub.Instance.Publish<Msg.ArrowClicked>(new Msg.ArrowClicked(1));
            right = true;
            GameController.Instance.EnableTrigger(GameController.TRIGGER_RIGHT);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            TinyMessengerHub.Instance.Publish<Msg.ArrowReleased>(new Msg.ArrowReleased(1));
            right = false;
            GameController.Instance.ClearAllTriggers();
        }

        if (left && right) {
            if (!isPressed) {
                isPressed = true;
                GameController.Instance.EnableTrigger(GameController.TRIGGER_SELECT);
            }
        } else {
            isPressed = false;
        }

	}    
}
