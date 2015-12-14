using UnityEngine;
using System.Collections;
using TinyMessenger;

public partial class GameController : Singleton<GameController> {
    
    private bool left;
    private bool right;
    private bool isPressed = false;

    void Update () {
        
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            TinyMessengerHub.Instance.Publish<Msg.ArrowClicked>(new Msg.ArrowClicked(-1));
            left = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            TinyMessengerHub.Instance.Publish<Msg.ArrowReleased>(new Msg.ArrowReleased(-1));
            left = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            TinyMessengerHub.Instance.Publish<Msg.ArrowClicked>(new Msg.ArrowClicked(1));
            right = true;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            TinyMessengerHub.Instance.Publish<Msg.ArrowReleased>(new Msg.ArrowReleased(1));
            right = false;
        }

        if (left && right)
        {
            if (!isPressed) {
                isPressed = true;
                GameController.Instance.EnableTrigger(GameController.TRIGGER_SELECT);
            }
        }
        else
        {
            isPressed = false;
        }

	}    
}
