using UnityEngine;
using System.Collections;

public class FightMusicBehaviour : StateMachineBehaviour
{
    public virtual void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        Debug.Log("OnStateMachineEnter");
        FindObjectOfType<AudioScript>().SetFightPlaylist();
    }

    public virtual void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        Debug.Log("OnStateMachineExit");
        FindObjectOfType<AudioScript>().SetMenuPlaylist();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        //FindObjectOfType<AudioScript>().SetMenuPlaylist();
    }
}