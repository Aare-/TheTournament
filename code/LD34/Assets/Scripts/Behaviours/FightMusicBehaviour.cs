using UnityEngine;
using System.Collections;

public class FightMusicBehaviour : StateMachineBehaviour
{
    public virtual void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        FindObjectOfType<AudioScript>().SetFightPlaylist();
    }

    public virtual void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        FindObjectOfType<AudioScript>().SetSuppresedPlaylist();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        //FindObjectOfType<AudioScript>().SetMenuPlaylist();
    }
}