using UnityEngine;
using System.Collections;

public class SuppresedMusicBehaviour : StateMachineBehaviour
{
    public virtual void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        FindObjectOfType<AudioScript>().SetSuppresedPlaylist();
    }

    //public virtual void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    //{
    //    Debug.Log(this.name + ": OnStateMachineExit");
    //    FindObjectOfType<AudioScript>().SetMenuPlaylist();
    //}
}