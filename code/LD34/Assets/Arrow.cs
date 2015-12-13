using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Arrow : MonoBehaviour {

    public Sprite arrowReleased = null;
    public Sprite arrowPressed = null;
    public Vector3 defaultPosition;
    public int id;

    void Start()
    {
        TinyTokenManager.Instance.Register<Msg.ArrowClicked>("ARROW_" + id + "_PRESSED", OnArrowPressed);
        TinyTokenManager.Instance.Register<Msg.ArrowReleased>("ARROW_" + id + "_RELEASED", OnArrowReleased);
        defaultPosition = transform.position;
    }
	
    void OnArrowPressed(Msg.ArrowClicked m)
    {
        if (m.ArrowID == id)
        {
            iTween.MoveBy(gameObject, new Vector3(0, -0.1f, 0), 0.5f);
        }
    }

    void OnArrowReleased(Msg.ArrowReleased m)
    {
        if (m.ArrowID == id)
        {
            iTween.MoveTo(gameObject, defaultPosition, 0.5f);
        }
    }
}
