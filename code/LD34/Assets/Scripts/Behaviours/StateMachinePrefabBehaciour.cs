using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class StateMachinePrefabBehaciour : PrefabBehaviour {
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {        
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {          
    }

    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash) {        
        InitPrefabs();
        
    }

    public override void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
        Debug.Log("MACHINE_EXIT");
        DestroyPrefabs();
    }
}

