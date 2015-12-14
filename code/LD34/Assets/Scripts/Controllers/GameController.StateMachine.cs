using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public partial class GameController : Singleton<GameController> {
    #region Triggers
    public const string TRIGGER_SELECT = "select_performed";
    public const string TRIGGER_REROLL = "reroll";
    public const string TRIGGER_LEFT = "left";
    public const string TRIGGER_RIGHT = "right"; 
    #endregion

    [Header("State Machine")]
    public Animator UIStateMachine;

    public void EnableTrigger(string triggerName) {
        UIStateMachine.SetTrigger(triggerName);
    }
    public void ClearAllTriggers() {
        UIStateMachine.ResetTrigger(TRIGGER_SELECT);
        UIStateMachine.ResetTrigger(TRIGGER_REROLL);
        UIStateMachine.ResetTrigger(TRIGGER_LEFT);
        UIStateMachine.ResetTrigger(TRIGGER_RIGHT);
    }
}
