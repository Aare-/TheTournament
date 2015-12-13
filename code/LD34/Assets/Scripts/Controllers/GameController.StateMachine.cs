using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public partial class GameController : Singleton<GameController> {
    #region Triggers
    public const string TRIGGER_SELECT = "select_performed";
    public const string TRIGGER_REROLL = "reroll"; 
    #endregion

    [Header("State Machine")]
    public Animator UIStateMachine;

    public void EnableTrigger(string triggerName) {
        UIStateMachine.SetTrigger(triggerName);
    }
}
