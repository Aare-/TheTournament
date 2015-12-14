using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Arrow : MonoBehaviour {

    public Sprite[] sprites;
    public int id;
    private Vector3 _defaultPosition;
    
    void Start()
    {
        TinyTokenManager.Instance.Register<Msg.ArrowClicked>("ARROW_" + id + "_PRESSED", OnArrowPressed);
        TinyTokenManager.Instance.Register<Msg.ArrowReleased>("ARROW_" + id + "_RELEASED", OnArrowReleased);
        TinyTokenManager.Instance.Register<Msg.ChangeArrowSprite>("ARROW_" + id + "_SPRITE_CHANGED", OnArrowSpriteChange);
        _defaultPosition = transform.position;
    }
	
    void OnArrowPressed(Msg.ArrowClicked m)
    {
        if (m.ArrowID == id)
        {
            gameObject.transform.position = _defaultPosition;
            iTween.Stop(gameObject, "MoveBy");
            iTween.MoveBy(gameObject, new Vector3(0, -0.1f, 0), 0.1f);
        }
    }

    void OnArrowReleased(Msg.ArrowReleased m)
    {
        if (m.ArrowID == id)
        {
            iTween.Stop(gameObject, "MoveBy");
            iTween.MoveTo(gameObject, _defaultPosition, 0.1f);
        }
    }

    void OnArrowSpriteChange(Msg.ChangeArrowSprite m)
    {
        if (m.ArrowID == id)
        {
            if (sprites != null)
                gameObject.GetComponent<Image>().sprite = sprites[m.IconID];
            else Debug.Log(gameObject.name + " no sprites");
        }
    }
}
