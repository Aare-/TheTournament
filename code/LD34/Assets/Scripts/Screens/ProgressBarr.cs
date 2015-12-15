using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarr : MonoBehaviour {
    public Image Background;
    public Image Foreground;

    private float _Percent;

    public float Percent {
        get {
            return _Percent;
        }
        set {
            RectTransform t = Foreground.GetComponent<RectTransform>();
            RectTransform b = Background.GetComponent<RectTransform>();

            t.sizeDelta = new Vector2((float)b.sizeDelta.x * value, b.sizeDelta.y);

            _Percent = value;
        }
    }
}
