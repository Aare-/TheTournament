using UnityEngine;
using System.Collections;
using TinyMessenger;

public partial class GameController : Singleton<GameController> {
    private int _LastGenId = -1;

    public int GetNewId() {
        return ++_LastGenId;
    }    

	void Start () {
	
	}		
	void Update () {
        
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            TinyMessengerHub.Instance.Publish<Msg.ArrowClicked>(new Msg.ArrowClicked(-1));
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            TinyMessengerHub.Instance.Publish<Msg.ArrowReleased>(new Msg.ArrowReleased(-1));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            TinyMessengerHub.Instance.Publish<Msg.ArrowClicked>(new Msg.ArrowClicked(1));
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            TinyMessengerHub.Instance.Publish<Msg.ArrowReleased>(new Msg.ArrowReleased(1));
        }

	}    
}
