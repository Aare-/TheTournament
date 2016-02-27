using UnityEngine;
using System.Collections;

public class MenuMusicBehaviour : StateMachineBehaviour
{
    public virtual void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        FindObjectOfType<AudioScript>().SetMenuPlaylist();
    }    
}