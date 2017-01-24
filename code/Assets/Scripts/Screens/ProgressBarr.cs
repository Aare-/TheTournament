using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarr : MonoBehaviour {
    public Image Background;
    public Image Foreground;
    public Text Nmr;

    private Vector2 _Value;

    public Vector2 Value {
        get {
            return _Value;
        }
        set {
            RectTransform t = Foreground.GetComponent<RectTransform>();

            Nmr.text = value.x + "/" + value.y;
            t.localScale = new Vector3(Mathf.Clamp01(value.x / value.y), 1.0f, 1.0f);

            _Value = value;
        }
    }
}
