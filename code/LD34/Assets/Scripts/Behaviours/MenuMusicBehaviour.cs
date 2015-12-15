using UnityEngine;
using System.Collections;

public class MenuMusicBehaviour : StateMachineBehaviour
{
    public virtual void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        //FindObjectOfType<AudioScript>().SetMenuPlaylist();
    }
}