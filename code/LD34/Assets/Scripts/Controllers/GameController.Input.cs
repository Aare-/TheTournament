using UnityEngine;
using System.Collections;
using TinyMessenger;

public partial class GameController : Singleton<GameController> {

    public int BlockInput = 0;

    public bool left;
    public bool right;
    public bool isPressed = false;

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
            TinyMessengerHub.Instance.Publish<Msg.LeftPressed>(new Msg.LeftPressed());
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
            TinyMessengerHub.Instance.Publish<Msg.RightPressed>(new Msg.RightPressed());
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
