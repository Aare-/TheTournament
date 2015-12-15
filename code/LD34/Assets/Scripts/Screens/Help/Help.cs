using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Help : MonoBehaviour {
		
	void Start () {
        GameController.Instance.SetStateBool(GameController.FIRST_GAME, false);
	}
	
	void Update () {
		
	}
}
