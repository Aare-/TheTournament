using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class PrefabBehaviour : StateMachineBehaviour {
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateEnter(animator, stateInfo, layerIndex);

    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateExit(animator, stateInfo, layerIndex);

    }

    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash) {
        base.OnStateMachineEnter(animator, stateMachinePathHash);

    }
    public override void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
        base.OnStateMachineExit(animator, stateMachinePathHash);

    }
}
