using UnityEngine;
using System.Collections;
using TinyMessenger;

public partial class GameController : Singleton<GameController> {
    
    private int _LastGenId = -1;

    public Player player;

    public int GetNewId() {
        return ++_LastGenId;
    }

    protected void Awake() {
        TinyTokenManager.Instance.Register<Msg.StartNewGame>(GetInstanceID() + "NEW_GAME", (m) => {            
            player = new Player();
            Debug.Log("New player created!");
        });
    }
	protected void Start () {
	
	}		
}
