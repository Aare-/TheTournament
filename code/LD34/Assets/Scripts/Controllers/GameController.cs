using UnityEngine;
using System.Collections;

public partial class GameController : Singleton<GameController> {
    private int _LastGenId = -1;

    public int GetNewId() {
        return ++_LastGenId;
    }

	void Start () {
	
	}		
	void Update () {
	
	}    
}
