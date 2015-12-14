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
        _OpponentFactory = new GladiatorOpponentFactory();

        TinyTokenManager.Instance.Register<Msg.StartNewGame>(GetInstanceID() + "NEW_GAME", (m) => {            
            player = new Player();            
        });
        TinyTokenManager.Instance.Register<Msg.GenerateNewOpponent>(GetInstanceID() + "_NEW_OPPONENT", (m) => {
            player.Opponent = _OpponentFactory.Generate();
        });
    }
	protected void Start () {
	
	}		
}
