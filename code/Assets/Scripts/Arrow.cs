using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Arrow : MonoBehaviour {

    public Image[] sprites;
    public int id;
    private Vector3 _defaultPosition;
    
    void Start() {
        TinyTokenManager.Instance.Register<Msg.ArrowClicked>("ARROW_" + GetInstanceID() + "_PRESSED", OnArrowPressed);
        TinyTokenManager.Instance.Register<Msg.ArrowReleased>("ARROW_" + GetInstanceID() + "_RELEASED", OnArrowReleased);
        TinyTokenManager.Instance.Register<Msg.HideArrowKeys>("ARROW_ " + GetInstanceID() + "HIDE", (m) => {
            foreach (Image o in sprites)
                o.color = new Color(1.0f, 1.0f, 1.0f, m.Hide ? 0.0f : 1.0f);
        });
        TinyTokenManager.Instance.Register<Msg.HideOneArrowKey>("ARROW_ " + GetInstanceID() + "HIDE_ONE", (m) => {
            if(m.ID == id)
                foreach (Image o in sprites)
                    o.color = new Color(1.0f, 1.0f, 1.0f, m.Hide ? 0.0f : 1.0f);
        });        
        _defaultPosition = transform.position;
    }
	
    void OnArrowPressed(Msg.ArrowClicked m)
    {
        if (m.ArrowID == id) {
            gameObject.transform.position = _defaultPosition;
            iTween.Stop(gameObject, "MoveBy");
            iTween.MoveBy(gameObject, new Vector3(0, -0.1f, 0), 0.1f);
        }
    }

    void OnArrowReleased(Msg.ArrowReleased m) {
        if (m.ArrowID == id) {
            iTween.Stop(gameObject, "MoveBy");
            iTween.MoveTo(gameObject, _defaultPosition, 0.1f);
        }
    }
}
