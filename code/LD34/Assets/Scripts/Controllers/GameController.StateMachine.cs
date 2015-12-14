using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public partial class GameController : Singleton<GameController> {
    #region Triggers
    public const string TRIGGER_SELECT = "select_performed";
    public const string REROLLS_COUNT = "tactics_rereolls";
    public const string TRIGGER_LEFT = "left";
    public const string TRIGGER_RIGHT = "right"; 
    #endregion

    [Header("State Machine")]
    public Animator UIStateMachine;

    public void EnableTrigger(string triggerName) {
        UIStateMachine.SetTrigger(triggerName);
    }
    public int GetStateInt(string stateName) {
        return UIStateMachine.GetInteger(stateName);
    }
    public void SetStateInt(string stateName, int value) {
        UIStateMachine.SetInteger(stateName, value);
    }    
    public void ClearAllTriggers() {
        left = false;
        right = false;

        UIStateMachine.ResetTrigger(TRIGGER_SELECT);        
        UIStateMachine.ResetTrigger(TRIGGER_LEFT);
        UIStateMachine.ResetTrigger(TRIGGER_RIGHT);
    }
}
