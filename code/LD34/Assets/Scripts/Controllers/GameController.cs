using UnityEngine;
using System.Collections;
using TinyMessenger;

public partial class GameController : Singleton<GameController> {
    
    private int _LastGenId = -1;

    public Player player;
    GladiatorOpponentFactory _OpponentFactory;
    

    public int GetNewId() {
        return ++_LastGenId;
    }

    protected void Awake() {
        Screen.SetResolution(320, 568, false);

        _OpponentFactory = new GladiatorOpponentFactory();
        
        TinyTokenManager.Instance.Register<Msg.GameOver>(GetInstanceID() + "qweqweWGAME_OVER", (m) => {
            player = null;
        });
        TinyTokenManager.Instance.Register<Msg.GenerateNewOpponent>(GetInstanceID() + "qwewqeW_NEW_OPPONENT", (m) => {
            player.Opponent = _OpponentFactory.Generate();
        });
    }
	protected void Start () {
	
	}		
}
