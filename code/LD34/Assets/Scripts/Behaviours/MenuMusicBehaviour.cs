using UnityEngine;
using System.Collections;

public class MenuMusicBehaviour : StateMachineBehaviour
{
    public virtual void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Debug.Log("Started!");
        FindObjectOfType<AudioScript>().SetMenuPlaylist();
    }    
}