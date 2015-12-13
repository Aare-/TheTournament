using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Button arrowLeft;
    public Button arrowRight;
    public RectTransform rectGate;

	void Start () {
	
	}
		
	void Update () 
    {
	    if(Input.GetKey(KeyCode.LeftArrow)) 
        {
            OpenHalfGate();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            OpenHalfGate();
        }
	}

    public void OpenGate()
    {

    }

    public void OpenHalfGate()
    {

    }
}
