using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuScreenControler : MonoBehaviour {
    
    public Button leftArrow;
    public Button rightArrow;
    public RectTransform rectGate;
    public Animator anim;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("open_all", true);
        }
        else
        {
            anim.SetBool("open_all", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("open_half", true);
        }
        else
        {
            anim.SetBool("open_half", false);
        }
    }

}
