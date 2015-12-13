using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Arrow : MonoBehaviour {

    public Sprite arrowReleased = null;
    public Sprite arrowPressed = null;
    public int id;

    void Start()
    {
        TinyTokenManager.Instance.Register<Msg.ArrowClicked>("ARROW_" + id + "_PRESSED", OnArrowPressed);
        TinyTokenManager.Instance.Register<Msg.ArrowReleased>("ARROW_" + id + "_RELEASED", OnArrowReleased);
    }
	
    void OnArrowPressed(Msg.ArrowClicked m)
    {
        //GetComponent<Image>().sprite = arrowPressed;
        if(m.ArrowID == id)
            GetComponent<Image>().color = Color.red;
    }

    void OnArrowReleased(Msg.ArrowReleased m)
    {
        //GetComponent<Image>().sprite = arrowReleased;
        if (m.ArrowID == id)
            GetComponent<Image>().color = Color.white;
    }
}
